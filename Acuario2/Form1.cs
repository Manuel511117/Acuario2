using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Ventana principal: dashboard + inventario conectados a la BD MySQL (Aiven).
    /// Estilo replicado del mockup (sidebar navy, tarjetas KPI, gráficas y grilla).
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>Usuario que inició sesión (se muestra en la barra superior).</summary>
        public string Usuario = "";

        private const string Placeholder = "Buscar producto...";

        private static readonly Color ColorMenuActivo = Color.FromArgb(1, 112, 137);
        private static readonly Color ColorMenuInactivo = Color.FromArgb(2, 74, 108);

        private List<Producto> _productos = new List<Producto>();
        private bool _placeholderActivo;
        private int _hoverFila = -1;
        private int _hoverColumna = -1;

        public Form1()
        {
            InitializeComponent();
        }

        // ============================================================
        //  Carga inicial
        // ============================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            RedondearControles();
            CargarImagenes();

            if (string.IsNullOrWhiteSpace(Usuario)) Usuario = "admin";
            lblUsuario.Text = Usuario;

            _placeholderActivo = true;
            txtBuscar.Text = Placeholder;
            txtBuscar.ForeColor = Color.FromArgb(150, 165, 178);
            cboFiltro.SelectedIndex = 0;

            IrA(true);
        }

        private void RedondearControles()
        {
            UiUtil.Redondear(btnInicio, 27);
            UiUtil.Redondear(btnInventario, 27);
            UiUtil.Redondear(btnReportes, 27);
            UiUtil.Redondear(btnConfig, 27);
            UiUtil.Redondear(btnSalir, 27);
            UiUtil.Redondear(btnAgregar, 24);
            UiUtil.Redondear(btnActualizar, 24);
            UiUtil.Redondear(panUsuario, 21);
            UiUtil.Redondear(picKpi1, 23);
            UiUtil.Redondear(picKpi2, 23);
            UiUtil.Redondear(picKpi3, 23);
            UiUtil.Redondear(picKpi4, 23);
        }

        private void CargarImagenes()
        {
            picLogo.Image = UiUtil.Imagen("logo.png");

            btnInicio.Image = UiUtil.Escalar(UiUtil.Imagen("ic_dashboard.png"), 30, 30);
            btnInventario.Image = UiUtil.Escalar(UiUtil.Imagen("ic_inventario.png"), 30, 30);
            btnReportes.Image = UiUtil.Escalar(UiUtil.Imagen("ic_reportes.png"), 30, 30);
            btnConfig.Image = UiUtil.Escalar(UiUtil.Imagen("ic_config.png"), 30, 30);
            btnSalir.Image = UiUtil.Escalar(UiUtil.Imagen("ic_salir.png"), 30, 30);

            picKpi1.Image = UiUtil.Escalar(UiUtil.Imagen("ic_kpi1.png"), 26, 26);
            picKpi2.Image = UiUtil.Escalar(UiUtil.Imagen("ic_kpi2.png"), 26, 26);
            picKpi3.Image = UiUtil.Escalar(UiUtil.Imagen("ic_kpi3.png"), 26, 26);
            picKpi4.Image = UiUtil.Escalar(UiUtil.Imagen("ic_kpi4.png"), 26, 26);

            picLupa.Image = UiUtil.Escalar(UiUtil.Imagen("ic_lupa.png"), 20, 20);
            picFiltro.Image = UiUtil.Escalar(UiUtil.Imagen("ic_filtro.png"), 20, 20);
            btnAgregar.Image = UiUtil.Escalar(UiUtil.Imagen("ic_plus.png"), 22, 22);
            btnActualizar.Image = UiUtil.Escalar(UiUtil.Imagen("ic_refresh.png"), 22, 22);
        }

        // ============================================================
        //  Navegación del menú lateral
        // ============================================================

        private void IrA(bool dashboard)
        {
            panDashboard.Visible = dashboard;
            panInventario.Visible = !dashboard;
            lblTitulo.Text = dashboard ? "DASHBOARD" : "INVENTARIO";

            btnInicio.BackColor = dashboard ? ColorMenuActivo : ColorMenuInactivo;
            btnInventario.BackColor = dashboard ? ColorMenuInactivo : ColorMenuActivo;
            btnInicio.FlatAppearance.MouseOverBackColor = dashboard ? Color.FromArgb(2, 133, 161) : Color.FromArgb(3, 92, 131);
            btnInventario.FlatAppearance.MouseOverBackColor = dashboard ? Color.FromArgb(3, 92, 131) : Color.FromArgb(2, 133, 161);

            if (dashboard) CargarDashboard();
            else CargarInventario();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            IrA(true);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            IrA(false);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "El módulo de Reportes estará disponible en una próxima versión.",
                "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "El módulo de Configuración estará disponible en una próxima versión.",
                "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Bienvenida bienvenida = new Bienvenida();
            bienvenida.Show();
            Close();
        }

        // ============================================================
        //  Dashboard
        // ============================================================

        private void CargarDashboard()
        {
            lblKpi1Valor.Text = ConexionDB.TotalProductos().ToString();
            lblKpi2Valor.Text = ConexionDB.TotalUnidades().ToString("N0");
            lblKpi3Valor.Text = "$" + ConexionDB.ValorInventario().ToString("N0");
            lblKpi4Valor.Text = ConexionDB.ProductosAgotados().ToString("N0");

            grafEspecie.Formato = "N0";
            grafEspecie.Asignar(ConexionDB.ProductosPorEspecie());

            grafTop5.Formato = "\"$\"#,##0";
            grafTop5.Asignar(ConexionDB.Top5Precios());

            grafValor.Formato = "\"$\"#,##0";
            grafValor.Asignar(ConexionDB.ValorPorEspecie());

            CargarAlertas();
        }

        private void CargarAlertas()
        {
            flpAlertas.SuspendLayout();
            flpAlertas.Controls.Clear();

            string mensaje;
            List<Producto> bajos = ConexionDB.InventarioBajo(out mensaje);

            if (bajos.Count == 0)
            {
                Label ok = new Label();
                ok.Text = "✓  Sin alertas de inventario.\r\nTodos los productos tienen stock suficiente.";
                ok.Font = UiUtil.Fuente(10f, FontStyle.Regular);
                ok.ForeColor = Color.FromArgb(4, 113, 122);
                ok.Size = new Size(250, 56);
                ok.Margin = new Padding(3, 8, 3, 0);
                flpAlertas.Controls.Add(ok);
            }
            else
            {
                foreach (Producto p in bajos) flpAlertas.Controls.Add(CrearFilaAlerta(p));
            }

            flpAlertas.ResumeLayout();
        }

        private Control CrearFilaAlerta(Producto p)
        {
            Panel fila = new Panel();
            fila.Size = new Size(250, 58);
            fila.Margin = new Padding(3, 6, 3, 0);
            fila.BackColor = Color.FromArgb(248, 250, 252);
            UiUtil.Redondear(fila, 10);

            Label nombre = new Label();
            nombre.Text = p.Nombre;
            nombre.Font = UiUtil.Fuente(10.5f, FontStyle.Bold);
            nombre.ForeColor = Color.FromArgb(3, 50, 90);
            nombre.Location = new Point(12, 6);
            nombre.Size = new Size(164, 24);
            nombre.TextAlign = ContentAlignment.MiddleLeft;
            nombre.AutoEllipsis = true;

            Label stock = new Label();
            stock.Text = "Stock: " + p.Cantidad + (p.Cantidad == 1 ? " unidad" : " unidades");
            stock.Font = UiUtil.Fuente(9f, FontStyle.Regular);
            stock.ForeColor = Color.FromArgb(110, 128, 145);
            stock.Location = new Point(12, 30);
            stock.Size = new Size(164, 22);
            stock.TextAlign = ContentAlignment.MiddleLeft;

            Label badge = new Label();
            badge.Text = "Agotado";
            badge.Font = UiUtil.Fuente(8.75f, FontStyle.Bold);
            badge.BackColor = Color.FromArgb(249, 214, 209);
            badge.ForeColor = Color.FromArgb(178, 58, 44);
            badge.TextAlign = ContentAlignment.MiddleCenter;
            badge.Location = new Point(178, 17);
            badge.Size = new Size(62, 24);
            UiUtil.Redondear(badge, 12);

            fila.Controls.Add(nombre);
            fila.Controls.Add(stock);
            fila.Controls.Add(badge);
            return fila;
        }

        // ============================================================
        //  Inventario
        // ============================================================

        private void CargarInventario()
        {
            string mensaje;
            _productos = ConexionDB.ListarProductos(out mensaje);
            AplicarFiltros();

            if (!string.IsNullOrEmpty(mensaje))
            {
                lblAviso.ForeColor = Color.FromArgb(192, 57, 43);
                lblAviso.Text = mensaje;
            }
        }

        private void AplicarFiltros()
        {
            string texto = _placeholderActivo ? "" : (txtBuscar.Text ?? "").Trim();
            string especie = (cboFiltro.SelectedItem as string) ?? "";

            List<Producto> filtrados = new List<Producto>();
            foreach (Producto p in _productos)
            {
                bool okTexto = texto.Length == 0 ||
                    (!string.IsNullOrEmpty(p.Nombre) && p.Nombre.IndexOf(texto, StringComparison.CurrentCultureIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(p.Especie) && p.Especie.IndexOf(texto, StringComparison.CurrentCultureIgnoreCase) >= 0);

                bool okEspecie = especie.Length == 0 || especie == "Todas las especies" ||
                    string.Equals(p.Especie, especie, StringComparison.CurrentCultureIgnoreCase);

                if (okTexto && okEspecie) filtrados.Add(p);
            }

            dgvProductos.Rows.Clear();
            foreach (Producto p in filtrados)
            {
                int i = dgvProductos.Rows.Add(
                    p.Id,
                    p.Nombre,
                    p.Especie,
                    p.Cantidad,
                    p.Precio,
                    UiUtil.Minatura(p.Imagen, 40),
                    p.Cantidad <= 3 ? "Agotado" : "Disponible",
                    "",
                    "");
                dgvProductos.Rows[i].Tag = p;
            }

            lblAviso.ForeColor = Color.FromArgb(95, 115, 135);
            lblAviso.Text = "Mostrando " + filtrados.Count + " de " + _productos.Count + " productos";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == Placeholder) return;
            _placeholderActivo = false;
            AplicarFiltros();
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (!_placeholderActivo) return;
            _placeholderActivo = false;
            txtBuscar.Text = "";
            txtBuscar.ForeColor = Color.FromArgb(20, 64, 95);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (_placeholderActivo) return;
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            _placeholderActivo = true;
            txtBuscar.Text = Placeholder;
            txtBuscar.ForeColor = Color.FromArgb(150, 165, 178);
            AplicarFiltros();
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;
            AplicarFiltros();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (AgregarProducto f = new AgregarProducto())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    CargarInventario();
                    lblAviso.ForeColor = Color.FromArgb(4, 113, 122);
                    lblAviso.Text = "Producto agregado correctamente.";
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            btnActualizar.Enabled = false;
            btnActualizar.Text = "Actualizado";
            CargarInventario();

            Timer t = new Timer();
            t.Interval = 1300;
            t.Tick += delegate
            {
                t.Stop();
                t.Dispose();
                btnActualizar.Text = "Actualizar";
                btnActualizar.Enabled = true;
            };
            t.Start();
        }

        private void EditarProducto(Producto p)
        {
            using (AgregarProducto f = new AgregarProducto())
            {
                f.Editando = p;
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    UiUtil.InvalidarImagen(p.Imagen);
                    CargarInventario();
                    lblAviso.ForeColor = Color.FromArgb(4, 113, 122);
                    lblAviso.Text = "Producto actualizado correctamente.";
                }
            }
        }

        private void EliminarProducto(Producto p)
        {
            DialogResult r = MessageBox.Show(this,
                "¿Desea eliminar el producto «" + p.Nombre + "» del inventario?",
                "Eliminar producto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (r != DialogResult.Yes) return;

            string mensaje;
            if (ConexionDB.EliminarProducto(p.Id, out mensaje))
            {
                UiUtil.EliminarImagen(p.Imagen);   // limpia caché y borra el archivo
                CargarInventario();
                lblAviso.ForeColor = Color.FromArgb(4, 113, 122);
                lblAviso.Text = "Producto eliminado correctamente.";
            }
            else
            {
                MessageBox.Show(this, string.IsNullOrEmpty(mensaje) ? "No se pudo eliminar el producto." : mensaje,
                    "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ============================================================
        //  Grilla
        // ============================================================

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            Producto p = fila.Tag as Producto;
            if (p == null) return;

            if (e.ColumnIndex == colVer.Index)
            {
                using (VisorImagen v = new VisorImagen(p.Nombre, p.Imagen)) v.ShowDialog(this);
            }
            else if (e.ColumnIndex == colEditar.Index)
            {
                EditarProducto(p);
            }
            else if (e.ColumnIndex == colEliminar.Index)
            {
                EliminarProducto(p);
            }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == colPrecio.Index && e.Value is decimal)
            {
                e.Value = "$" + ((decimal)e.Value).ToString("N2");
                e.FormattingApplied = true;
            }
        }

        private void dgvProductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // ---- badge de Estado
            if (e.ColumnIndex == colEstado.Index && e.Value != null)
            {
                e.PaintBackground(e.ClipBounds, true);

                string texto = e.Value.ToString();
                bool disponible = texto == "Disponible";
                Color fondo = disponible ? Color.FromArgb(191, 231, 234) : Color.FromArgb(249, 214, 209);
                Color tinta = disponible ? Color.FromArgb(4, 113, 122) : Color.FromArgb(178, 58, 44);

                Rectangle r = new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y + (e.CellBounds.Height - 24) / 2,
                                            e.CellBounds.Width - 32, 24);
                using (GraphicsPath ruta = UiUtil.RutaRedondeada(r, 12))
                using (SolidBrush b = new SolidBrush(fondo)) e.Graphics.FillPath(b, ruta);

                TextRenderer.DrawText(e.Graphics, texto, UiUtil.Fuente(9f, FontStyle.Bold), r, tinta,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                e.Handled = true;
                return;
            }

            // ---- botones planos Editar / Eliminar
            bool editar = e.ColumnIndex == colEditar.Index;
            bool eliminar = e.ColumnIndex == colEliminar.Index;
            if (!editar && !eliminar) return;

            e.PaintBackground(e.ClipBounds, true);

            bool hover = (_hoverFila == e.RowIndex && _hoverColumna == e.ColumnIndex);
            if (hover)
            {
                Color resaltado = editar ? Color.FromArgb(231, 243, 251) : Color.FromArgb(253, 237, 235);
                Rectangle rh = new Rectangle(e.CellBounds.X + 5, e.CellBounds.Y + 6,
                                             e.CellBounds.Width - 10, e.CellBounds.Height - 12);
                using (GraphicsPath ruta = UiUtil.RutaRedondeada(rh, 8))
                using (SolidBrush b = new SolidBrush(resaltado)) e.Graphics.FillPath(b, ruta);
            }

            Color tintaBtn;
            if (editar) tintaBtn = hover ? Color.FromArgb(10, 150, 214) : Color.FromArgb(14, 136, 200);
            else tintaBtn = hover ? Color.FromArgb(214, 69, 54) : Color.FromArgb(192, 57, 43);

            TextRenderer.DrawText(e.Graphics, editar ? "Editar" : "Eliminar",
                UiUtil.Fuente(9.5f, FontStyle.Bold), e.CellBounds, tintaBtn,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
            e.Handled = true;
        }

        private void dgvProductos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == _hoverFila && e.ColumnIndex == _hoverColumna) return;

            int filaAnt = _hoverFila;
            int colAnt = _hoverColumna;
            _hoverFila = e.RowIndex;
            _hoverColumna = e.ColumnIndex;

            bool eraBoton = EsColumnaBoton(colAnt);
            bool esBoton = EsColumnaBoton(_hoverColumna);

            if (eraBoton && filaAnt >= 0) dgvProductos.InvalidateCell(colAnt, filaAnt);
            if (esBoton && _hoverFila >= 0) dgvProductos.InvalidateCell(_hoverColumna, _hoverFila);
        }

        private void dgvProductos_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int filaAnt = _hoverFila;
            int colAnt = _hoverColumna;
            _hoverFila = -1;
            _hoverColumna = -1;
            if (EsColumnaBoton(colAnt) && filaAnt >= 0) dgvProductos.InvalidateCell(colAnt, filaAnt);
        }

        private bool EsColumnaBoton(int indice)
        {
            return indice >= 0 && (indice == colEditar.Index || indice == colEliminar.Index);
        }
    }
}
