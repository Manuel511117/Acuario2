using System;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Vista Híbrida de Configuración:
    /// - Tarjeta 1: Perfil y Seguridad (Cambio de contraseña del usuario activo)
    /// - Tarjeta 2: Preferencias del Sistema y Conexión (Nombre del negocio, moneda, stock bajo, prueba de BD)
    /// - Tarjeta 3: Acerca de Nosotros (Logo, versión, créditos y equipo de desarrollo)
    /// </summary>
    public class ControlConfiguracion : UserControl
    {
        // Tarjeta 1: Perfil y Seguridad
        private PanelRedondeado panSeguridad;
        private Label lblSeguridadTitulo;
        private Label lblUsuarioInfo;
        private Label lblClaveActual;
        private TextBox txtClaveActual;
        private Label lblClaveNueva;
        private TextBox txtClaveNueva;
        private Label lblClaveConfirmar;
        private TextBox txtClaveConfirmar;
        private Button btnGuardarClave;
        private Label lblAvisoSeguridad;

        // Tarjeta 2: Parámetros del Sistema
        private PanelRedondeado panParametros;
        private Label lblParametrosTitulo;
        private Label lblNombreNegocio;
        private TextBox txtNombreNegocio;
        private Label lblMoneda;
        private ComboBox cboMoneda;
        private Label lblStockBajo;
        private NumericUpDown nudStockBajo;
        private Label lblEstadoBdTitulo;
        private Label lblEstadoBd;
        private Button btnProbarBd;
        private Button btnGuardarAjustes;
        private Label lblAvisoAjustes;

        // Tarjeta 3: Acerca de Nosotros y Equipo
        private PanelRedondeado panNosotros;
        private PictureBox picLogoNosotros;
        private Label lblNosotrosTitulo;
        private Label lblNosotrosSubtitulo;
        private Label lblNosotrosDesc;
        private Label lblVersionBadge;
        private Label lblEquipoTitulo;
        private Panel panEquipoLista;
        private Label lblTecnologias;

        public string UsuarioActual { get; set; } = "admin";

        public ControlConfiguracion()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(245, 248, 250);
            this.AutoScroll = false;
            this.Font = UiUtil.Fuente(9f, FontStyle.Regular);

            ConstruirComponentes();
            CargarValoresIniciales();
        }

        private void ConstruirComponentes()
        {
            this.SuspendLayout();

            // ============================================================
            // 1. Tarjeta: Perfil y Seguridad (Arriba Izquierda)
            // ============================================================
            panSeguridad = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(16, 12),
                Size = new Size(470, 240)
            };

            lblSeguridadTitulo = new Label
            {
                Text = "👤  Perfil y Seguridad",
                Font = UiUtil.Fuente(10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(16, 12),
                AutoSize = true
            };

            lblUsuarioInfo = new Label
            {
                Text = "Usuario activo: admin  ·  Rol: Administrador",
                Font = UiUtil.Fuente(8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(18, 36),
                AutoSize = true
            };

            lblClaveActual = CrearEtiqueta("Contraseña actual:", new Point(18, 62));
            txtClaveActual = new TextBox
            {
                UseSystemPasswordChar = true,
                Location = new Point(18, 80),
                Size = new Size(205, 24)
            };

            lblClaveNueva = CrearEtiqueta("Nueva contraseña:", new Point(238, 62));
            txtClaveNueva = new TextBox
            {
                UseSystemPasswordChar = true,
                Location = new Point(238, 80),
                Size = new Size(205, 24)
            };

            lblClaveConfirmar = CrearEtiqueta("Confirmar nueva contraseña:", new Point(18, 114));
            txtClaveConfirmar = new TextBox
            {
                UseSystemPasswordChar = true,
                Location = new Point(18, 132),
                Size = new Size(205, 24)
            };

            btnGuardarClave = new Button
            {
                Text = "🔒  Actualizar contraseña",
                BackColor = Color.FromArgb(1, 112, 137),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8.5f, FontStyle.Bold),
                Size = new Size(180, 32),
                Location = new Point(18, 172),
                Cursor = Cursors.Hand
            };
            btnGuardarClave.FlatAppearance.BorderSize = 0;
            UiUtil.Redondear(btnGuardarClave, 8);
            btnGuardarClave.Click += BtnGuardarClave_Click;

            lblAvisoSeguridad = new Label
            {
                Text = "",
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                Location = new Point(210, 178),
                Size = new Size(240, 22),
                TextAlign = ContentAlignment.MiddleLeft
            };

            panSeguridad.Controls.Add(lblSeguridadTitulo);
            panSeguridad.Controls.Add(lblUsuarioInfo);
            panSeguridad.Controls.Add(lblClaveActual);
            panSeguridad.Controls.Add(txtClaveActual);
            panSeguridad.Controls.Add(lblClaveNueva);
            panSeguridad.Controls.Add(txtClaveNueva);
            panSeguridad.Controls.Add(lblClaveConfirmar);
            panSeguridad.Controls.Add(txtClaveConfirmar);
            panSeguridad.Controls.Add(btnGuardarClave);
            panSeguridad.Controls.Add(lblAvisoSeguridad);
            this.Controls.Add(panSeguridad);

            // ============================================================
            // 2. Tarjeta: Parámetros del Sistema (Abajo Izquierda)
            // ============================================================
            panParametros = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(16, 262),
                Size = new Size(470, 255)
            };

            lblParametrosTitulo = new Label
            {
                Text = "⚙️  Parámetros del Sistema y Base de Datos",
                Font = UiUtil.Fuente(10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(16, 12),
                AutoSize = true
            };

            lblNombreNegocio = CrearEtiqueta("Nombre del negocio / Acuario:", new Point(18, 40));
            txtNombreNegocio = new TextBox
            {
                Text = "AquaControl Acuarios",
                Location = new Point(18, 58),
                Size = new Size(240, 24)
            };

            lblMoneda = CrearEtiqueta("Moneda:", new Point(275, 40));
            cboMoneda = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(275, 58),
                Size = new Size(168, 24)
            };
            cboMoneda.Items.AddRange(new object[] { "$ MXN (Peso Mexicano)", "$ USD (Dólar)", "€ EUR (Euro)" });
            cboMoneda.SelectedIndex = 0;

            lblStockBajo = CrearEtiqueta("Alerta de stock bajo (unidades):", new Point(18, 92));
            nudStockBajo = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 50,
                Value = 3,
                Location = new Point(18, 110),
                Size = new Size(100, 24)
            };

            lblEstadoBdTitulo = CrearEtiqueta("Estado de conexión a base de datos:", new Point(200, 92));
            lblEstadoBd = new Label
            {
                Text = ConexionDB.EstaConfiguradaCadena() ? "🟢  En línea (MySQL Aiven)" : "🟡  Modo local / Demostración",
                Font = UiUtil.Fuente(8.5f, FontStyle.Bold),
                ForeColor = ConexionDB.EstaConfiguradaCadena() ? Color.FromArgb(22, 163, 74) : Color.FromArgb(202, 138, 4),
                Location = new Point(200, 112),
                AutoSize = true
            };

            btnProbarBd = new Button
            {
                Text = "⚡ Probar conexión",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(3, 50, 90),
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8.25f, FontStyle.Regular),
                Size = new Size(130, 30),
                Location = new Point(18, 150),
                Cursor = Cursors.Hand
            };
            btnProbarBd.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            UiUtil.Redondear(btnProbarBd, 8);
            btnProbarBd.Click += BtnProbarBd_Click;

            btnGuardarAjustes = new Button
            {
                Text = "💾  Guardar preferencias",
                BackColor = Color.FromArgb(2, 74, 108),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(8.5f, FontStyle.Bold),
                Size = new Size(165, 30),
                Location = new Point(160, 150),
                Cursor = Cursors.Hand
            };
            btnGuardarAjustes.FlatAppearance.BorderSize = 0;
            UiUtil.Redondear(btnGuardarAjustes, 8);
            btnGuardarAjustes.Click += (s, e) =>
            {
                bool okNegocio = ConexionDB.GuardarAjuste("negocio", txtNombreNegocio.Text.Trim());
                bool okMoneda = ConexionDB.GuardarAjuste("moneda", cboMoneda.Text);
                bool okStock = ConexionDB.GuardarAjuste("stock_bajo", ((int)nudStockBajo.Value).ToString());

                if (okNegocio && okMoneda && okStock)
                {
                    lblAvisoAjustes.ForeColor = Color.FromArgb(22, 163, 74);
                    lblAvisoAjustes.Text = "✓ Preferencias guardadas correctamente.";
                }
                else
                {
                    lblAvisoAjustes.ForeColor = Color.FromArgb(220, 38, 38);
                    lblAvisoAjustes.Text = "No se pudieron guardar las preferencias: sin conexión a la base de datos.";
                }
            };

            lblAvisoAjustes = new Label
            {
                Text = "",
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                Location = new Point(18, 190),
                Size = new Size(420, 22)
            };

            panParametros.Controls.Add(lblParametrosTitulo);
            panParametros.Controls.Add(lblNombreNegocio);
            panParametros.Controls.Add(txtNombreNegocio);
            panParametros.Controls.Add(lblMoneda);
            panParametros.Controls.Add(cboMoneda);
            panParametros.Controls.Add(lblStockBajo);
            panParametros.Controls.Add(nudStockBajo);
            panParametros.Controls.Add(lblEstadoBdTitulo);
            panParametros.Controls.Add(lblEstadoBd);
            panParametros.Controls.Add(btnProbarBd);
            panParametros.Controls.Add(btnGuardarAjustes);
            panParametros.Controls.Add(lblAvisoAjustes);
            this.Controls.Add(panParametros);

            // ============================================================
            // 3. Tarjeta: Acerca de Nosotros y Equipo (Columna Derecha)
            // ============================================================
            panNosotros = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(226, 232, 240),
                BackColor = Color.White,
                Location = new Point(500, 12),
                Size = new Size(495, 505),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            picLogoNosotros = new PictureBox
            {
                Image = UiUtil.Imagen("logo.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(54, 54),
                Location = new Point(24, 18)
            };

            lblNosotrosTitulo = new Label
            {
                Text = "AquaControl",
                Font = UiUtil.Fuente(14f, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 50, 90),
                Location = new Point(88, 16),
                AutoSize = true
            };

            lblNosotrosSubtitulo = new Label
            {
                Text = "Sistema de Gestión y Analítica para Acuarios",
                Font = UiUtil.Fuente(9f, FontStyle.Regular),
                ForeColor = Color.FromArgb(1, 112, 137),
                Location = new Point(89, 42),
                AutoSize = true
            };

            lblVersionBadge = new Label
            {
                Text = "Versión 1.0.0 (Release 2026)",
                Font = UiUtil.Fuente(8f, FontStyle.Bold),
                BackColor = Color.FromArgb(224, 242, 254),
                ForeColor = Color.FromArgb(3, 105, 161),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(24, 82),
                Size = new Size(180, 24)
            };
            UiUtil.Redondear(lblVersionBadge, 8);

            lblNosotrosDesc = new Label
            {
                Text = "AquaControl es una plataforma de software creada para simplificar y optimizar la administración diaria de acuarios comerciales y tiendas de acuarismo. Integra control de inventario de especies vivas y accesorios, punto de venta ágil con cálculo de totales y un módulo de reportes analíticos para la toma de decisiones estratégicas.",
                Font = UiUtil.Fuente(8.75f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(24, 116),
                Size = new Size(445, 75)
            };

            lblEquipoTitulo = new Label
            {
                Text = "👥  Equipo de Desarrollo",
                Font = UiUtil.Fuente(10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(24, 200),
                AutoSize = true
            };

            panEquipoLista = new Panel
            {
                Location = new Point(24, 226),
                Size = new Size(445, 210),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoScroll = false
            };

            ConstruirTarjetasEquipo();

            lblTecnologias = new Label
            {
                Text = "Tecnologías: C# · .NET Framework 4.7.2 · MySQL Cloud (Aiven) · GDI+ Antialias\n© 2026 AquaControl. Todos los derechos reservados.",
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(24, 448),
                Size = new Size(445, 42),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            panNosotros.Controls.Add(picLogoNosotros);
            panNosotros.Controls.Add(lblNosotrosTitulo);
            panNosotros.Controls.Add(lblNosotrosSubtitulo);
            panNosotros.Controls.Add(lblVersionBadge);
            panNosotros.Controls.Add(lblNosotrosDesc);
            panNosotros.Controls.Add(lblEquipoTitulo);
            panNosotros.Controls.Add(panEquipoLista);
            panNosotros.Controls.Add(lblTecnologias);
            this.Controls.Add(panNosotros);

            this.Resize += ControlConfiguracion_Resize;
            this.ResumeLayout(false);
        }

        private void ConstruirTarjetasEquipo()
        {
            panEquipoLista.Controls.Clear();

            var integrantes = new[]
            {
                new { Nombre = "Diego / Banze", Rol = "Líder de Proyecto & Arquitectura de Software", Iniciales = "DB", Color = Color.FromArgb(1, 112, 137) },
                new { Nombre = "Equipo de Desarrollo", Rol = "Desarrollo de Módulos (Inventario, Ventas y Reportes)", Iniciales = "ED", Color = Color.FromArgb(4, 175, 182) },
                new { Nombre = "Diseño de Interfaz & Base de Datos", Rol = "Modelado MySQL, Experiencia de Usuario y GDI+", Iniciales = "UI", Color = Color.FromArgb(2, 74, 108) }
            };

            int y = 0;
            foreach (var m in integrantes)
            {
                Panel card = new Panel
                {
                    Location = new Point(0, y),
                    Size = new Size(panEquipoLista.Width, 54),
                    BackColor = Color.FromArgb(248, 250, 252),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                UiUtil.Redondear(card, 8);

                Label avatar = new Label
                {
                    Text = m.Iniciales,
                    Font = UiUtil.Fuente(9f, FontStyle.Bold),
                    BackColor = m.Color,
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(10, 9),
                    Size = new Size(36, 36)
                };
                UiUtil.Redondear(avatar, 18);

                Label lblNombre = new Label
                {
                    Text = m.Nombre,
                    Font = UiUtil.Fuente(9.25f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(15, 23, 42),
                    Location = new Point(54, 8),
                    AutoSize = true
                };

                Label lblRol = new Label
                {
                    Text = m.Rol,
                    Font = UiUtil.Fuente(8f, FontStyle.Regular),
                    ForeColor = Color.FromArgb(100, 116, 139),
                    Location = new Point(54, 28),
                    AutoSize = true
                };

                card.Controls.Add(avatar);
                card.Controls.Add(lblNombre);
                card.Controls.Add(lblRol);
                panEquipoLista.Controls.Add(card);

                y += 62;
            }
        }

        private void ControlConfiguracion_Resize(object sender, EventArgs e)
        {
            if (this.ClientSize.Width <= 100 || this.ClientSize.Height <= 100) return;

            int pad = 16;
            int gap = 14;
            int anchoMitad = (this.ClientSize.Width - (pad * 2) - gap) / 2;

            panSeguridad.Width = anchoMitad;
            panParametros.Width = anchoMitad;

            panNosotros.Left = pad + anchoMitad + gap;
            panNosotros.Width = this.ClientSize.Width - panNosotros.Left - pad;
            panNosotros.Height = this.ClientSize.Height - (pad * 2);

            panParametros.Height = Math.Max(220, this.ClientSize.Height - panParametros.Top - pad);
            lblNosotrosDesc.Width = panNosotros.Width - 48;
            panEquipoLista.Width = panNosotros.Width - 48;
        }

        private static Label CrearEtiqueta(string texto, Point pos)
        {
            return new Label
            {
                Text = texto,
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = pos,
                AutoSize = true
            };
        }

        private void CargarValoresIniciales()
        {
            lblUsuarioInfo.Text = "Usuario activo: " + UsuarioActual + "  ·  Rol: Administrador";

            // Preferencias guardadas en la base de datos
            txtNombreNegocio.Text = ConexionDB.LeerAjuste("negocio", txtNombreNegocio.Text);

            string moneda = ConexionDB.LeerAjuste("moneda", cboMoneda.Text);
            if (cboMoneda.Items.Contains(moneda)) cboMoneda.SelectedItem = moneda;
            else cboMoneda.SelectedIndex = 0;

            int stockBajo;
            if (int.TryParse(ConexionDB.LeerAjuste("stock_bajo", ((int)nudStockBajo.Value).ToString()), out stockBajo))
            {
                nudStockBajo.Value = Math.Min(Math.Max(stockBajo, (int)nudStockBajo.Minimum), (int)nudStockBajo.Maximum);
            }
        }

        public void Recargar(string usuario)
        {
            if (!string.IsNullOrEmpty(usuario)) UsuarioActual = usuario;
            CargarValoresIniciales();

            lblEstadoBd.Text = ConexionDB.EstaConfiguradaCadena() ? "🟢  En línea (MySQL Aiven)" : "🟡  Modo local / Demostración";
            lblEstadoBd.ForeColor = ConexionDB.EstaConfiguradaCadena() ? Color.FromArgb(22, 163, 74) : Color.FromArgb(202, 138, 4);

            txtClaveActual.Text = "";
            txtClaveNueva.Text = "";
            txtClaveConfirmar.Text = "";
            lblAvisoSeguridad.Text = "";
            lblAvisoAjustes.Text = "";
        }

        private void BtnGuardarClave_Click(object sender, EventArgs e)
        {
            string actual = txtClaveActual.Text;
            string nueva = txtClaveNueva.Text;
            string confirmar = txtClaveConfirmar.Text;

            if (string.IsNullOrEmpty(actual))
            {
                lblAvisoSeguridad.ForeColor = Color.FromArgb(220, 38, 38);
                lblAvisoSeguridad.Text = "Ingrese la contraseña actual.";
                return;
            }

            if (string.IsNullOrEmpty(nueva))
            {
                lblAvisoSeguridad.ForeColor = Color.FromArgb(220, 38, 38);
                lblAvisoSeguridad.Text = "Ingrese la nueva contraseña.";
                return;
            }

            if (nueva != confirmar)
            {
                lblAvisoSeguridad.ForeColor = Color.FromArgb(220, 38, 38);
                lblAvisoSeguridad.Text = "Las contraseñas no coinciden.";
                return;
            }

            string msg;
            bool ok = ConexionDB.CambiarClave(UsuarioActual, actual, nueva, out msg);

            if (ok)
            {
                lblAvisoSeguridad.ForeColor = Color.FromArgb(22, 163, 74);
                lblAvisoSeguridad.Text = "✓ " + (string.IsNullOrEmpty(msg) ? "Contraseña actualizada." : msg);
                txtClaveActual.Text = "";
                txtClaveNueva.Text = "";
                txtClaveConfirmar.Text = "";
            }
            else
            {
                lblAvisoSeguridad.ForeColor = Color.FromArgb(220, 38, 38);
                lblAvisoSeguridad.Text = string.IsNullOrEmpty(msg) ? "Error al cambiar contraseña." : msg;
            }
        }

        private void BtnProbarBd_Click(object sender, EventArgs e)
        {
            string resultado = ConexionDB.ProbarConexion();
            MessageBox.Show(resultado, "Diagnóstico de Base de Datos", MessageBoxButtons.OK,
                resultado.Contains("exitosa") ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            lblEstadoBd.Text = ConexionDB.EstaConfiguradaCadena() ? "🟢  En línea (MySQL Aiven)" : "🟡  Modo local / Demostración";
            lblEstadoBd.ForeColor = ConexionDB.EstaConfiguradaCadena() ? Color.FromArgb(22, 163, 74) : Color.FromArgb(202, 138, 4);
        }
    }
}
