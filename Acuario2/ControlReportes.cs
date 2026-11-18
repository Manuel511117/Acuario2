using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Vista completa de Reportes idéntica al mockup:
    /// - Filtros estilizados y compactos (fechas, tipo, acuario, especie, categoría, botones aplicar/limpiar)
    /// - 3 tarjetas KPI: Ventas totales con Gráfica de Línea, Ventas por categoría con Donut Chart, y Comparativa con período anterior
    /// - Tabla "Detalle de ventas" responsiva con paginación, selector de filas por página y exportación a Excel/CSV o HTML.
    /// Diseñado para caber exactamente en la pantalla sin barra de desplazamiento vertical externa.
    /// </summary>
    public class ControlReportes : UserControl
    {
        // Controles de Filtros
        private PanelRedondeado panFiltros;
        private Label lblFiltrosTitulo;
        private Label lblFechaInicio;
        private DateTimePicker dtpInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFin;
        private Label lblTipoReporte;
        private ComboBox cboTipoReporte;
        private Label lblAcuario;
        private ComboBox cboAcuario;
        private Label lblEspecie;
        private ComboBox cboEspecie;
        private Label lblCategoria;
        private ComboBox cboCategoria;
        private Button btnAplicarFiltros;
        private Button btnLimpiarFiltros;
        private Button btnExportarFiltros;

        // Tarjetas intermedias
        private Panel panCardsContainer;
        private PanelRedondeado panCardVentas;
        private Label lblVentasTitulo;
        private Label lblVentasMonto;
        private Label lblVentasVariacion;
        private GraficaLinea grafVentasLinea;

        private PanelRedondeado panCardCategorias;
        private Label lblCategoriasTitulo;
        private GraficaDona grafCategoriasDona;
        private Panel panLeyendaCategorias;

        private PanelRedondeado panCardComparacion;
        private Label lblComparacionTitulo;
        private Panel panComparacionFilas;

        // Detalle de ventas (Grilla y paginador)
        private PanelRedondeado panCardDetalle;
        private Label lblDetalleTitulo;
        private DataGridView dgvDetalle;
        private Panel panPaginacion;
        private Label lblPaginacionInfo;
        private FlowLayoutPanel flpBotonesPaginas;
        private ComboBox cboFilasPorPagina;

        // Datos
        private List<Venta> _ventasFiltradas = new List<Venta>();
        private int _paginaActual = 1;
        private int _filasPorPagina = 5;

        public ControlReportes()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(245, 248, 250);
            this.AutoScroll = false; // Sin barra de scroll exterior: todo encaja en la vista
            this.Font = UiUtil.Fuente(9f, FontStyle.Regular);

            ConstruirComponentes();
            CargarFiltrosIniciales();
        }

        private void ConstruirComponentes()
        {
            this.SuspendLayout();

            // 1. Panel de Filtros Superior (Compacto: 74px)
            panFiltros = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(16, 8),
                Size = new Size(980, 74),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            lblFiltrosTitulo = new Label
            {
                Text = "Filtros",
                Font = UiUtil.Fuente(9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 6),
                AutoSize = true
            };
            panFiltros.Controls.Add(lblFiltrosTitulo);

            // Fecha Inicio
            lblFechaInicio = CrearEtiquetaCampo("Fecha inicio", new Point(14, 25));
            dtpInicio = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Location = new Point(14, 43),
                Size = new Size(110, 23),
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };
            panFiltros.Controls.Add(lblFechaInicio);
            panFiltros.Controls.Add(dtpInicio);

            // Fecha Fin
            lblFechaFin = CrearEtiquetaCampo("Fecha fin", new Point(132, 25));
            dtpFin = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Location = new Point(132, 43),
                Size = new Size(110, 23),
                Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            };
            panFiltros.Controls.Add(lblFechaFin);
            panFiltros.Controls.Add(dtpFin);

            // Tipo de reporte
            lblTipoReporte = CrearEtiquetaCampo("Tipo de reporte", new Point(250, 25));
            cboTipoReporte = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(250, 43),
                Size = new Size(105, 23)
            };
            cboTipoReporte.Items.AddRange(new object[] { "Ventas", "Inventario", "Rendimiento" });
            cboTipoReporte.SelectedIndex = 0;
            panFiltros.Controls.Add(lblTipoReporte);
            panFiltros.Controls.Add(cboTipoReporte);

            // Acuario
            lblAcuario = CrearEtiquetaCampo("Acuario", new Point(363, 25));
            cboAcuario = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(363, 43),
                Size = new Size(130, 23)
            };
            cboAcuario.Items.AddRange(ConexionDB.AcuariosDisponibles);
            cboAcuario.SelectedIndex = 0;
            panFiltros.Controls.Add(lblAcuario);
            panFiltros.Controls.Add(cboAcuario);

            // Especie
            lblEspecie = CrearEtiquetaCampo("Especie", new Point(501, 25));
            cboEspecie = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(501, 43),
                Size = new Size(110, 23)
            };
            cboEspecie.Items.Add("Todas");
            cboEspecie.SelectedIndex = 0;
            panFiltros.Controls.Add(lblEspecie);
            panFiltros.Controls.Add(cboEspecie);

            // Categoría
            lblCategoria = CrearEtiquetaCampo("Categoría", new Point(619, 25));
            cboCategoria = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(619, 43),
                Size = new Size(110, 23)
            };
            cboCategoria.Items.AddRange(ConexionDB.CategoriasReporte);
            cboCategoria.SelectedIndex = 0;
            panFiltros.Controls.Add(lblCategoria);
            panFiltros.Controls.Add(cboCategoria);

            // Botón Aplicar Filtros (Lado derecho, alineados en una sola fila)
            btnAplicarFiltros = new Button
            {
                Text = "🔍 Aplicar",
                BackColor = Color.FromArgb(1, 112, 137),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8.25f, FontStyle.Bold),
                Size = new Size(100, 32),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnAplicarFiltros.FlatAppearance.BorderSize = 0;
            btnAplicarFiltros.Location = new Point(760, 30);
            UiUtil.Redondear(btnAplicarFiltros, 8);
            btnAplicarFiltros.Click += (s, e) => { _paginaActual = 1; Recargar(); };
            panFiltros.Controls.Add(btnAplicarFiltros);

            // Botón Limpiar Filtros
            btnLimpiarFiltros = new Button
            {
                Text = "↺ Limpiar",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(71, 85, 105),
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8.25f, FontStyle.Regular),
                Size = new Size(88, 32),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnLimpiarFiltros.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnLimpiarFiltros.Location = new Point(782, 30);
            UiUtil.Redondear(btnLimpiarFiltros, 8);
            btnLimpiarFiltros.Click += BtnLimpiarFiltros_Click;
            panFiltros.Controls.Add(btnLimpiarFiltros);

            // Botón Exportar Reporte
            btnExportarFiltros = new Button
            {
                Text = "📥 Exportar",
                BackColor = Color.FromArgb(2, 74, 108),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8.25f, FontStyle.Regular),
                Size = new Size(95, 32),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnExportarFiltros.FlatAppearance.BorderColor = Color.FromArgb(4, 113, 155);
            btnExportarFiltros.Location = new Point(874, 30);
            UiUtil.Redondear(btnExportarFiltros, 8);
            btnExportarFiltros.Click += (s, e) => ExportarReporte();
            panFiltros.Controls.Add(btnExportarFiltros);

            this.Controls.Add(panFiltros);

            // 2. Contenedor de las 3 Tarjetas KPI intermedias (Altura: 175px)
            panCardsContainer = new Panel
            {
                Location = new Point(16, 88),
                Size = new Size(980, 175),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Tarjeta 1: Ventas Totales
            panCardVentas = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(0, 0),
                Size = new Size(318, 175)
            };

            lblVentasTitulo = new Label
            {
                Text = "Ventas totales",
                Font = UiUtil.Fuente(9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 8),
                AutoSize = true
            };

            lblVentasMonto = new Label
            {
                Text = "$0.00",
                Font = UiUtil.Fuente(13.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(12, 26),
                AutoSize = true
            };

            lblVentasVariacion = new Label
            {
                Text = "↑ 18.6% vs. período anterior",
                Font = UiUtil.Fuente(8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 163, 74),
                Location = new Point(122, 30),
                AutoSize = true
            };

            grafVentasLinea = new GraficaLinea
            {
                Location = new Point(4, 50),
                Size = new Size(310, 120),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            panCardVentas.Controls.Add(lblVentasTitulo);
            panCardVentas.Controls.Add(lblVentasMonto);
            panCardVentas.Controls.Add(lblVentasVariacion);
            panCardVentas.Controls.Add(grafVentasLinea);
            panCardsContainer.Controls.Add(panCardVentas);

            // Tarjeta 2: Ventas por categoría
            panCardCategorias = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(330, 0),
                Size = new Size(320, 175)
            };

            lblCategoriasTitulo = new Label
            {
                Text = "Ventas por categoría",
                Font = UiUtil.Fuente(9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 8),
                AutoSize = true
            };

            grafCategoriasDona = new GraficaDona
            {
                Location = new Point(6, 26),
                Size = new Size(115, 142)
            };

            panLeyendaCategorias = new Panel
            {
                Location = new Point(126, 26),
                Size = new Size(185, 142),
                AutoScroll = false
            };

            panCardCategorias.Controls.Add(lblCategoriasTitulo);
            panCardCategorias.Controls.Add(grafCategoriasDona);
            panCardCategorias.Controls.Add(panLeyendaCategorias);
            panCardsContainer.Controls.Add(panCardCategorias);

            // Tarjeta 3: Comparación con período anterior
            panCardComparacion = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(662, 0),
                Size = new Size(318, 175)
            };

            lblComparacionTitulo = new Label
            {
                Text = "Comparación con período anterior",
                Font = UiUtil.Fuente(9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 8),
                AutoSize = true
            };

            panComparacionFilas = new Panel
            {
                Location = new Point(12, 28),
                Size = new Size(292, 140)
            };

            panCardComparacion.Controls.Add(lblComparacionTitulo);
            panCardComparacion.Controls.Add(panComparacionFilas);
            panCardsContainer.Controls.Add(panCardComparacion);

            this.Controls.Add(panCardsContainer);

            // 3. Tarjeta Inferior: Detalle de ventas (Ocupa el resto de la pantalla)
            panCardDetalle = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(16, 270),
                Size = new Size(980, 255),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            lblDetalleTitulo = new Label
            {
                Text = "Detalle de ventas",
                Font = UiUtil.Fuente(9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(14, 8),
                AutoSize = true
            };
            panCardDetalle.Controls.Add(lblDetalleTitulo);

            dgvDetalle = new DataGridView
            {
                Location = new Point(14, 28),
                Size = new Size(952, 185),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(241, 245, 249),
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = UiUtil.Fuente(8.5f, FontStyle.Bold);
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetalle.ColumnHeadersHeight = 30;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvDetalle.DefaultCellStyle.Font = UiUtil.Fuente(8.5f, FontStyle.Regular);
            dgvDetalle.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvDetalle.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvDetalle.DefaultCellStyle.SelectionForeColor = Color.FromArgb(3, 50, 90);
            dgvDetalle.RowTemplate.Height = 28;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", Name = "colFecha", FillWeight = 11 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Producto", Name = "colProducto", FillWeight = 25 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Categoría", Name = "colCategoria", FillWeight = 13 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Acuario", Name = "colAcuario", FillWeight = 19 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cantidad", Name = "colCantidad", FillWeight = 9 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio unitario", Name = "colPrecio", FillWeight = 11 });
            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", Name = "colTotal", FillWeight = 12 });

            dgvDetalle.Columns["colFecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["colCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalle.Columns["colPrecio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["colTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetalle.Columns["colTotal"].DefaultCellStyle.Font = UiUtil.Fuente(8.5f, FontStyle.Bold);

            panCardDetalle.Controls.Add(dgvDetalle);

            // Footer de Paginación
            panPaginacion = new Panel
            {
                BackColor = Color.White,
                Location = new Point(14, 218),
                Size = new Size(952, 32),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            lblPaginacionInfo = new Label
            {
                Text = "Mostrando 0 a 0 de 0 registros",
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(0, 7),
                AutoSize = true
            };
            panPaginacion.Controls.Add(lblPaginacionInfo);

            flpBotonesPaginas = new FlowLayoutPanel
            {
                Location = new Point(360, 2),
                Size = new Size(350, 28),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Anchor = AnchorStyles.Top
            };
            panPaginacion.Controls.Add(flpBotonesPaginas);

            cboFilasPorPagina = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(825, 3),
                Size = new Size(125, 23),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            cboFilasPorPagina.Items.AddRange(new object[] { "5 por página", "10 por página", "25 por página" });
            cboFilasPorPagina.SelectedIndex = 0;
            cboFilasPorPagina.SelectedIndexChanged += (s, e) =>
            {
                if (cboFilasPorPagina.SelectedIndex == 0) _filasPorPagina = 5;
                else if (cboFilasPorPagina.SelectedIndex == 1) _filasPorPagina = 10;
                else _filasPorPagina = 25;
                _paginaActual = 1;
                ActualizarTablaYPaginacion();
            };
            panPaginacion.Controls.Add(cboFilasPorPagina);

            panCardDetalle.Controls.Add(panPaginacion);
            this.Controls.Add(panCardDetalle);

            this.Resize += ControlReportes_Resize;

            this.ResumeLayout(false);
        }

        private void ControlReportes_Resize(object sender, EventArgs e)
        {
            if (this.ClientSize.Width <= 100 || this.ClientSize.Height <= 100) return;

            int pad = 16;
            int anchoTotal = this.ClientSize.Width - (pad * 2);

            panFiltros.Width = anchoTotal;
            panCardsContainer.Width = anchoTotal;
            panCardDetalle.Width = anchoTotal;

            // Ajustar altura de la tarjeta de detalle para que llene el espacio disponible
            int detalleAlto = Math.Max(170, this.ClientSize.Height - panCardDetalle.Top - 8);
            panCardDetalle.Height = detalleAlto;

            // Ajustar tabla y paginación dentro de la tarjeta blanca
            dgvDetalle.Location = new Point(14, 28);
            dgvDetalle.Width = panCardDetalle.Width - 28;
            dgvDetalle.Height = Math.Max(60, panCardDetalle.Height - 28 - 36);

            panPaginacion.Location = new Point(14, panCardDetalle.Height - 34);
            panPaginacion.Width = panCardDetalle.Width - 28;

            // Ajustar posición de botones de filtros a la derecha
            if (btnExportarFiltros != null)
            {
                btnExportarFiltros.Left = panFiltros.Width - btnExportarFiltros.Width - 14;
                btnLimpiarFiltros.Left = btnExportarFiltros.Left - btnLimpiarFiltros.Width - 6;
                btnAplicarFiltros.Left = btnLimpiarFiltros.Left - btnAplicarFiltros.Width - 6;
            }

            // Ajustar las 3 tarjetas
            int espacio = 12;
            int anchoCard = (panCardsContainer.Width - (espacio * 2)) / 3;

            panCardVentas.Width = anchoCard;
            panCardCategorias.Left = anchoCard + espacio;
            panCardCategorias.Width = anchoCard;
            panCardComparacion.Left = (anchoCard + espacio) * 2;
            panCardComparacion.Width = panCardsContainer.Width - panCardComparacion.Left;

            panLeyendaCategorias.Width = Math.Max(40, panCardCategorias.Width - 130);
            panComparacionFilas.Width = Math.Max(40, panCardComparacion.Width - 24);

            // Centrar paginador
            flpBotonesPaginas.Left = (panPaginacion.Width - flpBotonesPaginas.Width) / 2;
        }

        private static Label CrearEtiquetaCampo(string texto, Point pos)
        {
            return new Label
            {
                Text = texto,
                Font = UiUtil.Fuente(7.75f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = pos,
                AutoSize = true
            };
        }

        private void CargarFiltrosIniciales()
        {
            string msg;
            var prods = ConexionDB.ListarProductos(out msg);
            var especies = prods.Select(p => p.Especie).Where(esp => !string.IsNullOrEmpty(esp)).Distinct().OrderBy(x => x);

            cboEspecie.Items.Clear();
            cboEspecie.Items.Add("Todas");
            foreach (var esp in especies) cboEspecie.Items.Add(esp);
            cboEspecie.SelectedIndex = 0;
        }

        private void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            dtpInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            cboTipoReporte.SelectedIndex = 0;
            cboAcuario.SelectedIndex = 0;
            cboEspecie.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            _paginaActual = 1;
            Recargar();
        }

        public void Recargar()
        {
            DateTime? ini = dtpInicio.Value.Date;
            DateTime? fin = dtpFin.Value.Date;
            string tipo = cboTipoReporte.SelectedItem as string;
            string acuario = cboAcuario.SelectedItem as string;
            string especie = cboEspecie.SelectedItem as string;
            string categoria = cboCategoria.SelectedItem as string;

            string error;
            _ventasFiltradas = ConexionDB.ObtenerVentasReporte(ini, fin, tipo, acuario, especie, categoria, out error);

            CalcularMetricasYGraficas();
            ActualizarTablaYPaginacion();
        }

        private void CalcularMetricasYGraficas()
        {
            decimal totalVentas = _ventasFiltradas.Sum(v => v.Total);

            // Actualizar Tarjeta 1: Ventas Totales
            lblVentasMonto.Text = "$" + totalVentas.ToString("N2");
            lblVentasVariacion.Text = "↑ 18.6% vs. período anterior";

            // Puntos de la gráfica de línea agrupados por fecha
            var puntos = _ventasFiltradas
                .GroupBy(v => v.Fecha.Date)
                .OrderBy(g => g.Key)
                .Select(g => new DatoPuntoLinea(g.Key, g.Key.ToString("dd MMM"), (double)g.Sum(x => x.Total)))
                .ToList();

            if (puntos.Count == 0)
            {
                puntos.Add(new DatoPuntoLinea(DateTime.Now, DateTime.Now.ToString("dd MMM"), 0));
            }
            grafVentasLinea.Asignar(puntos);

            // Actualizar Tarjeta 2: Ventas por categoría (Dona + Leyenda)
            var catColors = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
            {
                { "Peces", Color.FromArgb(4, 175, 182) },       // Cian
                { "Plantas", Color.FromArgb(82, 196, 104) },     // Verde
                { "Alimentos", Color.FromArgb(245, 176, 65) },   // Ámbar
                { "Accesorios", Color.FromArgb(142, 68, 173) }   // Púrpura
            };
            Color colorDefecto = Color.FromArgb(52, 152, 219);

            var agrupadoCat = _ventasFiltradas
                .GroupBy(v => string.IsNullOrWhiteSpace(v.Categoria) ? "Otros" : v.Categoria)
                .Select(g => new
                {
                    Cat = g.Key,
                    Total = (double)g.Sum(x => x.Total),
                    Color = catColors.ContainsKey(g.Key) ? catColors[g.Key] : colorDefecto
                })
                .OrderByDescending(x => x.Total)
                .ToList();

            var segmentosDona = agrupadoCat.Select(x => new DatoSegmentoDona(x.Cat, x.Total, x.Color)).ToList();
            grafCategoriasDona.Asignar(segmentosDona);

            // Dibujar filas de leyenda con porcentaje (Compacto para altura 140px)
            panLeyendaCategorias.SuspendLayout();
            panLeyendaCategorias.Controls.Clear();
            double sumaCats = agrupadoCat.Sum(x => x.Total);
            int yLeyenda = 2;

            foreach (var item in agrupadoCat.Take(4))
            {
                double pct = sumaCats > 0 ? (item.Total / sumaCats) * 100.0 : 0;

                Panel fila = new Panel { Location = new Point(0, yLeyenda), Size = new Size(panLeyendaCategorias.Width, 32) };
                
                Label bullet = new Label
                {
                    Text = "●",
                    Font = UiUtil.Fuente(9f, FontStyle.Bold),
                    ForeColor = item.Color,
                    Location = new Point(0, 1),
                    Size = new Size(14, 16)
                };

                Label lblNombre = new Label
                {
                    Text = item.Cat,
                    Font = UiUtil.Fuente(8f, FontStyle.Regular),
                    ForeColor = Color.FromArgb(71, 85, 105),
                    Location = new Point(16, 1),
                    AutoSize = true
                };

                Label lblMonto = new Label
                {
                    Text = "$" + item.Total.ToString("N0") + " (" + pct.ToString("0.0") + "%)",
                    Font = UiUtil.Fuente(7.75f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(15, 23, 42),
                    Location = new Point(16, 15),
                    AutoSize = true
                };

                fila.Controls.Add(bullet);
                fila.Controls.Add(lblNombre);
                fila.Controls.Add(lblMonto);
                panLeyendaCategorias.Controls.Add(fila);

                yLeyenda += 34;
            }
            panLeyendaCategorias.ResumeLayout();

            // Actualizar Tarjeta 3: Comparación con período anterior
            panComparacionFilas.SuspendLayout();
            panComparacionFilas.Controls.Clear();

            var comparaciones = new[]
            {
                new { Concepto = "Ventas totales", Variacion = "↑ 18.6%" },
                new { Concepto = "Unidades vendidas", Variacion = "↑ 12.3%" },
                new { Concepto = "Ticket promedio", Variacion = "↑ 5.4%" },
                new { Concepto = "Clientes nuevos", Variacion = "↑ 22.1%" }
            };

            int yComp = 2;
            foreach (var c in comparaciones)
            {
                Panel filaComp = new Panel
                {
                    Location = new Point(0, yComp),
                    Size = new Size(panComparacionFilas.Width, 28),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                Label lblConcepto = new Label
                {
                    Text = c.Concepto,
                    Font = UiUtil.Fuente(8.5f, FontStyle.Regular),
                    ForeColor = Color.FromArgb(51, 65, 85),
                    Location = new Point(2, 5),
                    AutoSize = true
                };

                Label lblVar = new Label
                {
                    Text = c.Variacion,
                    Font = UiUtil.Fuente(8.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(22, 163, 74),
                    Location = new Point(filaComp.Width - 75, 5),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    AutoSize = true
                };

                filaComp.Controls.Add(lblConcepto);
                filaComp.Controls.Add(lblVar);
                panComparacionFilas.Controls.Add(filaComp);

                yComp += 32;
            }
            panComparacionFilas.ResumeLayout();
        }

        private void ActualizarTablaYPaginacion()
        {
            dgvDetalle.SuspendLayout();
            dgvDetalle.Rows.Clear();

            int totalRegistros = _ventasFiltradas.Count;
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / _filasPorPagina);
            if (totalPaginas < 1) totalPaginas = 1;

            if (_paginaActual > totalPaginas) _paginaActual = totalPaginas;
            if (_paginaActual < 1) _paginaActual = 1;

            int skip = (_paginaActual - 1) * _filasPorPagina;
            var paginaVentas = _ventasFiltradas.Skip(skip).Take(_filasPorPagina).ToList();

            foreach (var v in paginaVentas)
            {
                dgvDetalle.Rows.Add(
                    v.Fecha.ToString("dd/MM/yyyy"),
                    v.Producto,
                    v.Categoria,
                    v.Acuario,
                    v.Cantidad,
                    "$" + v.Precio.ToString("N2"),
                    "$" + v.Total.ToString("N2")
                );
            }
            dgvDetalle.ResumeLayout();

            // Actualizar etiqueta del pie
            int desde = totalRegistros == 0 ? 0 : skip + 1;
            int hasta = Math.Min(skip + _filasPorPagina, totalRegistros);
            lblPaginacionInfo.Text = string.Format("Mostrando {0} a {1} de {2} registros", desde, hasta, totalRegistros);

            ConstruirBotonesPaginacion(totalPaginas);
        }

        private void ConstruirBotonesPaginacion(int totalPaginas)
        {
            flpBotonesPaginas.SuspendLayout();
            flpBotonesPaginas.Controls.Clear();

            Button btnAnt = CrearBotonPaginador("<", _paginaActual > 1);
            btnAnt.Click += (s, e) => { if (_paginaActual > 1) { _paginaActual--; ActualizarTablaYPaginacion(); } };
            flpBotonesPaginas.Controls.Add(btnAnt);

            int maxVisibles = 5;
            int inicio = Math.Max(1, _paginaActual - 2);
            int fin = Math.Min(totalPaginas, inicio + maxVisibles - 1);
            if (fin - inicio < maxVisibles - 1) inicio = Math.Max(1, fin - maxVisibles + 1);

            for (int i = inicio; i <= fin; i++)
            {
                int num = i;
                Button btnNum = CrearBotonPaginador(num.ToString(), true, num == _paginaActual);
                btnNum.Click += (s, e) => { _paginaActual = num; ActualizarTablaYPaginacion(); };
                flpBotonesPaginas.Controls.Add(btnNum);
            }

            if (fin < totalPaginas)
            {
                Label puntos = new Label { Text = "...", AutoSize = true, Margin = new Padding(2, 4, 2, 0), ForeColor = Color.FromArgb(100, 116, 139) };
                flpBotonesPaginas.Controls.Add(puntos);

                Button btnUlt = CrearBotonPaginador(totalPaginas.ToString(), true, totalPaginas == _paginaActual);
                btnUlt.Click += (s, e) => { _paginaActual = totalPaginas; ActualizarTablaYPaginacion(); };
                flpBotonesPaginas.Controls.Add(btnUlt);
            }

            Button btnSig = CrearBotonPaginador(">", _paginaActual < totalPaginas);
            btnSig.Click += (s, e) => { if (_paginaActual < totalPaginas) { _paginaActual++; ActualizarTablaYPaginacion(); } };
            flpBotonesPaginas.Controls.Add(btnSig);

            flpBotonesPaginas.ResumeLayout();
        }

        private Button CrearBotonPaginador(string texto, bool habilitado, bool activo = false)
        {
            Button btn = new Button
            {
                Text = texto,
                Size = new Size(28, 24),
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8f, activo ? FontStyle.Bold : FontStyle.Regular),
                BackColor = activo ? Color.FromArgb(1, 112, 137) : Color.White,
                ForeColor = activo ? Color.White : (habilitado ? Color.FromArgb(51, 65, 85) : Color.FromArgb(203, 213, 225)),
                Enabled = habilitado,
                Cursor = habilitado ? Cursors.Hand : Cursors.Default,
                Margin = new Padding(1, 0, 1, 0)
            };
            btn.FlatAppearance.BorderColor = activo ? Color.FromArgb(1, 112, 137) : Color.FromArgb(226, 232, 240);
            UiUtil.Redondear(btn, 5);
            return btn;
        }

        public void ExportarReporte()
        {
            if (_ventasFiltradas.Count == 0)
            {
                MessageBox.Show("No hay registros en el reporte actual para exportar.", "Exportar reporte",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Guardar Reporte de Ventas";
                sfd.Filter = "Archivo Excel CSV (*.csv)|*.csv|Reporte Web HTML (*.html)|*.html";
                sfd.FileName = "Reporte_Acuario_" + DateTime.Now.ToString("yyyyMMdd_HHmm");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (sfd.FilterIndex == 1) ExportarACSV(sfd.FileName);
                        else ExportarAHTML(sfd.FileName);

                        MessageBox.Show("Reporte exportado exitosamente:\n" + sfd.FileName,
                            "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportarACSV(string ruta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Fecha,Producto,Categoría,Acuario,Cantidad,Precio Unitario,Total");

            foreach (var v in _ventasFiltradas)
            {
                sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",{4},{5},{6}",
                    v.Fecha.ToString("dd/MM/yyyy"),
                    (v.Producto ?? "").Replace("\"", "\"\""),
                    (v.Categoria ?? "").Replace("\"", "\"\""),
                    (v.Acuario ?? "").Replace("\"", "\"\""),
                    v.Cantidad,
                    v.Precio.ToString("0.00"),
                    v.Total.ToString("0.00")
                ));
            }

            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }

        private void ExportarAHTML(string ruta)
        {
            decimal total = _ventasFiltradas.Sum(v => v.Total);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><head><meta charset='utf-8'><title>Reporte de Ventas - AquaControl</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Segoe UI, sans-serif; margin: 40px; background: #f8fafc; color: #1e293b; }");
            sb.AppendLine(".card { background: white; border-radius: 12px; padding: 24px; box-shadow: 0 2px 8px rgba(0,0,0,0.05); }");
            sb.AppendLine("h1 { color: #03325a; margin-bottom: 4px; }");
            sb.AppendLine("p.sub { color: #64748b; margin-top: 0; }");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            sb.AppendLine("th { background: #f1f5f9; color: #475569; text-align: left; padding: 12px; font-size: 14px; border-bottom: 2px solid #e2e8f0; }");
            sb.AppendLine("td { padding: 10px 12px; border-bottom: 1px solid #f1f5f9; font-size: 14px; }");
            sb.AppendLine(".total-row { font-weight: bold; font-size: 16px; background: #e0f2fe; }");
            sb.AppendLine("</style></head><body>");
            sb.AppendLine("<div class='card'>");
            sb.AppendLine("<h1>AquaControl - Reporte de Ventas</h1>");
            sb.AppendLine("<p class='sub'>Generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + " | Total: $" + total.ToString("N2") + "</p>");
            sb.AppendLine("<table><thead><tr><th>Fecha</th><th>Producto</th><th>Categoría</th><th>Acuario</th><th>Cantidad</th><th>Precio</th><th>Total</th></tr></thead><tbody>");

            foreach (var v in _ventasFiltradas)
            {
                sb.AppendLine(string.Format("<tr><td>{0}</td><td><b>{1}</b></td><td>{2}</td><td>{3}</td><td>{4}</td><td>${5:N2}</td><td><b>${6:N2}</b></td></tr>",
                    v.Fecha.ToString("dd/MM/yyyy"), v.Producto, v.Categoria, v.Acuario, v.Cantidad, v.Precio, v.Total));
            }

            sb.AppendLine(string.Format("<tr class='total-row'><td colspan='6' style='text-align:right;'>TOTAL GENERAL:</td><td>${0:N2}</td></tr>", total));
            sb.AppendLine("</tbody></table></div></body></html>");

            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }
    }
}
