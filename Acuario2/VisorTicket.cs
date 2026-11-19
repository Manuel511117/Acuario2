using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Ventana modal con vista previa e impresión de Ticket de Venta térmico.
    /// No requiere software externo: utiliza el motor de impresión nativo de Windows (impresoras físicas o Microsoft Print to PDF).
    /// </summary>
    public class VisorTicket : Form
    {
        private readonly List<ItemCarrito> _items;
        private readonly decimal _total;
        private readonly string _usuario;
        private readonly string _folio;
        private readonly string _negocio;
        private readonly DateTime _fecha;

        private PanelRedondeado panTicket;
        private PictureBox picLogo;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblFolio;
        private Label lblFecha;
        private Label lblCajero;
        private Panel panLineas;
        private Label lblTotalTexto;
        private Label lblMensajeGracias;
        private Button btnImprimir;
        private Button btnCerrar;

        public VisorTicket(List<ItemCarrito> items, decimal total, string usuario)
        {
            _items = items != null ? new List<ItemCarrito>(items) : new List<ItemCarrito>();
            _total = total;
            _usuario = string.IsNullOrEmpty(usuario) ? "admin" : usuario;
            _fecha = DateTime.Now;
            _folio = "TK-" + _fecha.ToString("yyyyMMdd") + "-" + (new Random().Next(100, 999));
            _negocio = ConexionDB.LeerAjuste("negocio", "AquaControl");

            InicializarVentana();
            ConstruirTicketVisual();
        }

        private void InicializarVentana()
        {
            this.Text = "Ticket de Venta - " + _negocio;
            this.Size = new Size(430, 680);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(241, 245, 249);
            this.Font = UiUtil.Fuente(9f, FontStyle.Regular);
        }

        private void ConstruirTicketVisual()
        {
            this.SuspendLayout();

            // Contenedor blanco con forma de ticket térmico
            panTicket = new PanelRedondeado
            {
                Radio = 12,
                ColorBorde = Color.FromArgb(203, 213, 225),
                BackColor = Color.White,
                Location = new Point(24, 16),
                Size = new Size(365, 550),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            // Logo
            picLogo = new PictureBox
            {
                Image = UiUtil.Imagen("logo.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(48, 48),
                Location = new Point((panTicket.Width - 48) / 2, 14)
            };
            panTicket.Controls.Add(picLogo);

            // Título
            lblTitulo = new Label
            {
                Text = _negocio.ToUpperInvariant(),
                Font = UiUtil.Fuente(13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 50, 90),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 64),
                Size = new Size(panTicket.Width - 20, 22)
            };
            panTicket.Controls.Add(lblTitulo);

            lblSubtitulo = new Label
            {
                Text = "Sistema de Gestión para Acuarios\nAv. Principal #102 · Tel: (555) 123-4567",
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 88),
                Size = new Size(panTicket.Width - 20, 30)
            };
            panTicket.Controls.Add(lblSubtitulo);

            // Separador 1
            Label sep1 = CrearSeparador(124);
            panTicket.Controls.Add(sep1);

            // Datos de la Venta
            lblFolio = new Label
            {
                Text = "Folio: #" + _folio,
                Font = UiUtil.Fuente(8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(18, 134),
                AutoSize = true
            };
            panTicket.Controls.Add(lblFolio);

            lblFecha = new Label
            {
                Text = "Fecha: " + _fecha.ToString("dd/MM/yyyy HH:mm:ss"),
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(18, 154),
                AutoSize = true
            };
            panTicket.Controls.Add(lblFecha);

            lblCajero = new Label
            {
                Text = "Atendió: " + _usuario,
                Font = UiUtil.Fuente(8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(18, 172),
                AutoSize = true
            };
            panTicket.Controls.Add(lblCajero);

            // Separador 2
            Label sep2 = CrearSeparador(192);
            panTicket.Controls.Add(sep2);

            // Encabezado de Productos
            Label lblEncabezado = new Label
            {
                Text = "CANT   DESCRIPCIÓN                    PRECIO       TOTAL",
                Font = new Font("Consolas", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(51, 65, 85),
                Location = new Point(14, 202),
                Size = new Size(panTicket.Width - 28, 16)
            };
            panTicket.Controls.Add(lblEncabezado);

            // Panel de Líneas de Productos
            panLineas = new Panel
            {
                Location = new Point(14, 222),
                Size = new Size(panTicket.Width - 28, 175),
                AutoScroll = true
            };

            int yFila = 0;
            foreach (var item in _items)
            {
                string desc = item.Producto != null ? item.Producto.Nombre : "Producto";
                if (desc.Length > 22) desc = desc.Substring(0, 20) + "..";

                string cant = item.Cantidad.ToString().PadRight(4);
                string textoProd = string.Format("{0} {1}", cant, desc.PadRight(22));
                string textoPrecios = string.Format("${0,7:N2}  ${1,8:N2}", item.Producto != null ? item.Producto.Precio : 0m, item.Subtotal);

                Label lblFila = new Label
                {
                    Text = textoProd + textoPrecios,
                    Font = new Font("Consolas", 8f, FontStyle.Regular),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Location = new Point(0, yFila),
                    Size = new Size(panLineas.Width - 10, 18)
                };
                panLineas.Controls.Add(lblFila);
                yFila += 20;
            }
            panTicket.Controls.Add(panLineas);

            // Separador 3
            Label sep3 = CrearSeparador(404);
            panTicket.Controls.Add(sep3);

            // Totales
            int totalArticulos = _items.Sum(i => i.Cantidad);
            Label lblArticulos = new Label
            {
                Text = "Total de artículos: " + totalArticulos,
                Font = UiUtil.Fuente(8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(18, 416),
                AutoSize = true
            };
            panTicket.Controls.Add(lblArticulos);

            lblTotalTexto = new Label
            {
                Text = "TOTAL: $" + _total.ToString("N2"),
                Font = UiUtil.Fuente(12.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(3, 50, 90),
                TextAlign = ContentAlignment.MiddleRight,
                Location = new Point(panTicket.Width - 210, 412),
                Size = new Size(190, 26)
            };
            panTicket.Controls.Add(lblTotalTexto);

            // Separador 4
            Label sep4 = CrearSeparador(444);
            panTicket.Controls.Add(sep4);

            // Mensaje de pie
            lblMensajeGracias = new Label
            {
                Text = "¡Gracias por su compra en " + _negocio + "!\nConserve este ticket para cualquier cambio o garantía.\n*** Válido por 30 días ***",
                Font = UiUtil.Fuente(7.75f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 458),
                Size = new Size(panTicket.Width - 20, 45)
            };
            panTicket.Controls.Add(lblMensajeGracias);

            this.Controls.Add(panTicket);

            // Botones inferiores fuera del ticket
            btnImprimir = new Button
            {
                Text = "🖨️  Imprimir Ticket / PDF",
                BackColor = Color.FromArgb(1, 112, 137),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(9f, FontStyle.Bold),
                Size = new Size(210, 36),
                Location = new Point(24, 584),
                Cursor = Cursors.Hand
            };
            btnImprimir.FlatAppearance.BorderSize = 0;
            UiUtil.Redondear(btnImprimir, 8);
            btnImprimir.Click += BtnImprimir_Click;
            this.Controls.Add(btnImprimir);

            btnCerrar = new Button
            {
                Text = "✕  Cerrar",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(71, 85, 105),
                FlatStyle = FlatStyle.Flat,
                Font = UiUtil.Fuente(9f, FontStyle.Regular),
                Size = new Size(130, 36),
                Location = new Point(259, 584),
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            UiUtil.Redondear(btnCerrar, 8);
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);

            this.ResumeLayout(false);
        }

        private Label CrearSeparador(int y)
        {
            return new Label
            {
                Text = "--------------------------------------------------------",
                Font = new Font("Consolas", 8f, FontStyle.Regular),
                ForeColor = Color.FromArgb(203, 213, 225),
                Location = new Point(14, y),
                Size = new Size(panTicket.Width - 28, 12),
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = "Ticket_" + _folio;
                pd.PrintPage += Pd_PrintPage;

                using (PrintDialog diag = new PrintDialog())
                {
                    diag.Document = pd;
                    diag.UseEXDialog = false; // Diálogo nativo clásico limpio de Windows

                    if (diag.ShowDialog(this) == DialogResult.OK)
                    {
                        pd.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al enviar a la impresora:\n" + ex.Message, "Impresión",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int pageWidth = e.PageBounds.Width;

            // Ancho adaptativo: en hojas estándar (Carta/A4) se usa un formato más amplio y largo (520px)
            int ticketWidth = pageWidth > 600 ? 520 : Math.Min(420, pageWidth - 40);
            int left = (pageWidth - ticketWidth) / 2;
            int top = pageWidth > 600 ? 40 : 20;

            Font fEmpresa = new Font("Segoe UI", 15f, FontStyle.Bold);
            Font fSub = new Font("Segoe UI", 9f, FontStyle.Regular);
            Font fNegrita = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            Font fNormal = new Font("Segoe UI", 9f, FontStyle.Regular);
            Font fDetalle = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            Font fDetalleBold = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            Font fTotal = new Font("Segoe UI", 14f, FontStyle.Bold);

            // Altura ajustada al contenido real sin espacio de más
            int alturaEstimada = 280 + (_items.Count * 26) + 110;
            Rectangle rectTicket = new Rectangle(left, top, ticketWidth, alturaEstimada);

            // Borde y fondo blanco tipo tarjeta elegante
            // (Se dibuja primero como fondo; el borde final se redibuja al final con la altura real)
            if (pageWidth > 600)
            {
                using (GraphicsPath pathCard = UiUtil.RutaRedondeada(rectTicket, 12))
                using (Pen penBorder = new Pen(Color.FromArgb(203, 213, 225), 1.5f))
                {
                    g.FillPath(Brushes.White, pathCard);
                }
            }

            int y = top + 22;

            // 1. Logo centrado
            Image logo = UiUtil.Imagen("logo.png");
            if (logo != null)
            {
                int logoTam = 54;
                g.DrawImage(logo, left + (ticketWidth - logoTam) / 2, y, logoTam, logoTam);
                y += logoTam + 8;
            }

            // 2. Nombre del Negocio y Subtítulo
            StringFormat sfCentro = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString("AQUACONTROL", fEmpresa, new SolidBrush(Color.FromArgb(3, 50, 90)), new RectangleF(left, y, ticketWidth, 26), sfCentro);
            y += 28;

            g.DrawString("Sistema de Gestión para Acuarios\nAv. Principal #102 - Tel: (555) 123-4567\ncontacto@aquacontrol.com", fSub, new SolidBrush(Color.FromArgb(100, 116, 139)), new RectangleF(left, y, ticketWidth, 42), sfCentro);
            y += 46;

            // Separador 1
            using (Pen penSep = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                penSep.DashStyle = DashStyle.Dash;
                g.DrawLine(penSep, left + 24, y, left + ticketWidth - 24, y);
            }
            y += 14;

            // 3. Metadatos de la venta organizados en 2 columnas
            int col2X = left + (ticketWidth / 2) + 10;
            g.DrawString("Folio: #" + _folio, fNegrita, new SolidBrush(Color.FromArgb(15, 23, 42)), left + 26, y);
            g.DrawString("Cliente: Público en general", fNormal, new SolidBrush(Color.FromArgb(71, 85, 105)), col2X, y);
            y += 20;
            g.DrawString("Fecha: " + _fecha.ToString("dd/MM/yyyy HH:mm:ss"), fNormal, new SolidBrush(Color.FromArgb(71, 85, 105)), left + 26, y);
            g.DrawString("Método: Efectivo", fNormal, new SolidBrush(Color.FromArgb(71, 85, 105)), col2X, y);
            y += 20;
            g.DrawString("Atendió: " + _usuario, fNormal, new SolidBrush(Color.FromArgb(71, 85, 105)), left + 26, y);
            g.DrawString("Estado: Pagado", fNegrita, new SolidBrush(Color.FromArgb(16, 149, 106)), col2X, y);
            y += 24;

            // Separador 2
            using (Pen penSep = new Pen(Color.FromArgb(226, 232, 240), 1.25f))
            {
                penSep.DashStyle = DashStyle.Solid;
                g.DrawLine(penSep, left + 24, y, left + ticketWidth - 24, y);
            }
            y += 12;

            // 4. Encabezados de tabla alineados
            StringFormat sfDer = new StringFormat { Alignment = StringAlignment.Far };
            int wPrecio = 80;
            int wTotal = 85;
            int xPrecio = left + ticketWidth - 26 - wTotal - wPrecio;
            int xTotal = left + ticketWidth - 26 - wTotal;

            g.DrawString("CANT", fNegrita, new SolidBrush(Color.FromArgb(71, 85, 105)), left + 26, y);
            g.DrawString("DESCRIPCIÓN", fNegrita, new SolidBrush(Color.FromArgb(71, 85, 105)), left + 80, y);
            g.DrawString("PRECIO", fNegrita, new SolidBrush(Color.FromArgb(71, 85, 105)), new RectangleF(xPrecio, y, wPrecio, 20), sfDer);
            g.DrawString("TOTAL", fNegrita, new SolidBrush(Color.FromArgb(71, 85, 105)), new RectangleF(xTotal, y, wTotal, 20), sfDer);
            y += 22;

            using (Pen penSepSub = new Pen(Color.FromArgb(241, 245, 249), 1.5f))
            {
                g.DrawLine(penSepSub, left + 24, y, left + ticketWidth - 24, y);
            }
            y += 10;

            // 5. Filas de productos con mayor espacio
            foreach (var item in _items)
            {
                string desc = item.Producto != null ? item.Producto.Nombre : "Producto";
                if (desc.Length > 28) desc = desc.Substring(0, 26) + "..";

                g.DrawString(item.Cantidad.ToString() + "x", fDetalle, Brushes.Black, left + 26, y);
                g.DrawString(desc, fDetalleBold, new SolidBrush(Color.FromArgb(15, 23, 42)), left + 80, y);
                g.DrawString("$" + (item.Producto != null ? item.Producto.Precio : 0m).ToString("N2"), fDetalle, new SolidBrush(Color.FromArgb(71, 85, 105)), new RectangleF(xPrecio, y, wPrecio, 20), sfDer);
                g.DrawString("$" + item.Subtotal.ToString("N2"), fDetalleBold, Brushes.Black, new RectangleF(xTotal, y, wTotal, 20), sfDer);
                y += 24;
            }
            y += 10;

            // Separador 3
            using (Pen penSep = new Pen(Color.FromArgb(226, 232, 240), 1.25f))
            {
                penSep.DashStyle = DashStyle.Dash;
                g.DrawLine(penSep, left + 24, y, left + ticketWidth - 24, y);
            }
            y += 16;

            // 6. Resumen de Totales más amplio
            int totalArt = _items.Sum(i => i.Cantidad);
            g.DrawString("Total de artículos: " + totalArt, fNormal, new SolidBrush(Color.FromArgb(100, 116, 139)), left + 26, y + 4);
            g.DrawString("TOTAL: $" + _total.ToString("N2"), fTotal, new SolidBrush(Color.FromArgb(3, 50, 90)), new RectangleF(left + ticketWidth - 260, y, 234, 28), sfDer);
            y += 38;

            // Separador 4
            using (Pen penSep = new Pen(Color.FromArgb(226, 232, 240), 1f))
            {
                penSep.DashStyle = DashStyle.Dash;
                g.DrawLine(penSep, left + 24, y, left + ticketWidth - 24, y);
            }
            y += 18;

            // 7. Pie extendido
            g.DrawString("¡Gracias por su compra en AquaControl!\nConserve este comprobante para cualquier cambio o aclaración.\n*** Válido por 30 días a partir de la fecha de emisión ***\nwww.aquacontrol.com",
                fSub, new SolidBrush(Color.FromArgb(100, 116, 139)), new RectangleF(left, y, ticketWidth, 72), sfCentro);
            y += 72 + 16; // pie (4 líneas) + padding inferior

            // Borde final con altura real del contenido
            if (pageWidth > 600)
            {
                int alturaReal = y - top;
                Rectangle rectFinal = new Rectangle(left, top, ticketWidth, alturaReal);
                using (GraphicsPath pathCard = UiUtil.RutaRedondeada(rectFinal, 12))
                using (Pen penBorder = new Pen(Color.FromArgb(203, 213, 225), 1.5f))
                {
                    g.DrawPath(penBorder, pathCard);
                }
            }
        }
    }
}
