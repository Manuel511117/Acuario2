using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Tarjeta del catálogo del punto de venta: imagen, nombre, categoría,
    /// precio, stock y botón para agregar el producto al carrito.
    /// </summary>
    public class TarjetaProducto : UserControl
    {
        private static readonly Color Navy = Color.FromArgb(3, 50, 90);
        private static readonly Color Teal = Color.FromArgb(14, 124, 134);
        private static readonly Color Borde = Color.FromArgb(225, 232, 237);
        private static readonly Color TextoSuave = Color.FromArgb(110, 130, 145);

        /// <summary>Se dispara al pulsar "Agregar".</summary>
        public event Action<Producto> Agregar;

        private readonly Producto _producto;
        private readonly Button _btnAgregar;
        private readonly Label _lblStock;

        public Producto Producto
        {
            get { return _producto; }
        }

        public TarjetaProducto(Producto producto)
        {
            _producto = producto ?? new Producto();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Size = new Size(178, 252);
            Margin = new Padding(7);
            Cursor = Cursors.Default;

            PictureBox foto = new PictureBox();
            foto.Location = new Point(12, 12);
            foto.Size = new Size(154, 100);
            foto.SizeMode = PictureBoxSizeMode.Zoom;
            foto.BackColor = Color.FromArgb(226, 236, 242);
            foto.Image = UiUtil.ImagenTarjeta(_producto.Imagen, foto.Width, foto.Height);
            foto.TabStop = false;
            Controls.Add(foto);

            Label lblNombre = new Label();
            lblNombre.Location = new Point(12, 118);
            lblNombre.Size = new Size(154, 38);
            lblNombre.Text = _producto.Nombre ?? "";
            lblNombre.Font = UiUtil.Fuente(10f, FontStyle.Bold);
            lblNombre.ForeColor = Navy;
            lblNombre.AutoEllipsis = true;
            Controls.Add(lblNombre);

            Label lblCategoria = new Label();
            lblCategoria.Location = new Point(12, 156);
            lblCategoria.Size = new Size(154, 18);
            lblCategoria.Text = _producto.Categoria ?? "";
            lblCategoria.Font = UiUtil.Fuente(8.5f, FontStyle.Regular);
            lblCategoria.ForeColor = Teal;
            lblCategoria.AutoEllipsis = true;
            Controls.Add(lblCategoria);

            Label lblPrecio = new Label();
            lblPrecio.Location = new Point(12, 178);
            lblPrecio.Size = new Size(92, 26);
            lblPrecio.Text = "C$ " + _producto.Precio.ToString("0.00");
            lblPrecio.Font = UiUtil.Fuente(11.5f, FontStyle.Bold);
            lblPrecio.ForeColor = Navy;
            lblPrecio.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(lblPrecio);

            _lblStock = new Label();
            _lblStock.Location = new Point(100, 180);
            _lblStock.Size = new Size(66, 22);
            _lblStock.Font = UiUtil.Fuente(8.5f, FontStyle.Regular);
            _lblStock.ForeColor = TextoSuave;
            _lblStock.TextAlign = ContentAlignment.MiddleRight;
            Controls.Add(_lblStock);

            _btnAgregar = new Button();
            _btnAgregar.Location = new Point(12, 208);
            _btnAgregar.Size = new Size(154, 32);
            _btnAgregar.FlatStyle = FlatStyle.Flat;
            _btnAgregar.FlatAppearance.BorderSize = 0;
            _btnAgregar.BackColor = Navy;
            _btnAgregar.ForeColor = Color.White;
            _btnAgregar.Font = UiUtil.Fuente(9.5f, FontStyle.Bold);
            _btnAgregar.Cursor = Cursors.Hand;
            _btnAgregar.UseVisualStyleBackColor = false;
            _btnAgregar.Text = "Agregar";
            _btnAgregar.Click += delegate { if (Agregar != null && _producto.Id > 0) Agregar(_producto); };
            _btnAgregar.MouseEnter += delegate { if (_btnAgregar.Enabled) _btnAgregar.BackColor = Teal; };
            _btnAgregar.MouseLeave += delegate { if (_btnAgregar.Enabled) _btnAgregar.BackColor = Navy; };
            Controls.Add(_btnAgregar);

            ActualizarStock(_producto.Cantidad);
        }

        /// <summary>Actualiza el texto de stock y habilita/deshabilita el botón.</summary>
        public void ActualizarStock(int stock)
        {
            _producto.Cantidad = stock;
            _lblStock.Text = "Stock: " + stock;
            _lblStock.ForeColor = stock <= 0 ? Color.FromArgb(192, 57, 43) : TextoSuave;

            if (stock <= 0)
            {
                _btnAgregar.Enabled = false;
                _btnAgregar.Text = "Agotado";
                _btnAgregar.BackColor = Color.FromArgb(210, 218, 224);
                _btnAgregar.ForeColor = Color.FromArgb(120, 132, 142);
            }
            else
            {
                _btnAgregar.Enabled = true;
                _btnAgregar.Text = "Agregar";
                _btnAgregar.BackColor = Navy;
                _btnAgregar.ForeColor = Color.White;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiUtil.Redondear(this, 14);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath p = UiUtil.RutaRedondeada(r, 14))
            using (Pen pen = new Pen(Borde, 1f))
            {
                e.Graphics.DrawPath(pen, p);
            }
        }
    }

    /// <summary>
    /// Tarjeta del carrito: nombre, precio unitario, subtotal y controles
    /// para subir/bajar la cantidad o quitar el producto.
    /// </summary>
    public class TarjetaCarrito : UserControl
    {
        private static readonly Color Navy = Color.FromArgb(3, 50, 90);
        private static readonly Color Teal = Color.FromArgb(14, 124, 134);
        private static readonly Color Borde = Color.FromArgb(225, 232, 237);
        private static readonly Color TextoSuave = Color.FromArgb(110, 130, 145);
        private static readonly Color Rojo = Color.FromArgb(192, 57, 43);

        /// <summary>Se dispara al cambiar la cantidad (+1 / -1).</summary>
        public event Action<TarjetaCarrito, int> CambiarCantidad;

        /// <summary>Se dispara al pulsar "Quitar".</summary>
        public event Action<TarjetaCarrito> Quitar;

        public ItemCarrito Item { get; private set; }

        private readonly Label _lblNombre;
        private readonly Label _lblUnitario;
        private readonly Label _lblCantidad;
        private readonly Label _lblSubtotal;
        private readonly Button _btnMenos;
        private readonly Button _btnMas;

        public TarjetaCarrito(ItemCarrito item)
        {
            Item = item;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Size = new Size(284, 92);
            Margin = new Padding(4, 4, 4, 6);

            _lblNombre = new Label();
            _lblNombre.Location = new Point(12, 9);
            _lblNombre.Size = new Size(190, 22);
            _lblNombre.Font = UiUtil.Fuente(10f, FontStyle.Bold);
            _lblNombre.ForeColor = Navy;
            _lblNombre.AutoEllipsis = true;
            Controls.Add(_lblNombre);

            Button btnQuitar = new Button();
            btnQuitar.Location = new Point(218, 6);
            btnQuitar.Size = new Size(54, 26);
            btnQuitar.FlatStyle = FlatStyle.Flat;
            btnQuitar.FlatAppearance.BorderSize = 0;
            btnQuitar.BackColor = Color.White;
            btnQuitar.ForeColor = Rojo;
            btnQuitar.Font = UiUtil.Fuente(8.5f, FontStyle.Bold);
            btnQuitar.Cursor = Cursors.Hand;
            btnQuitar.Text = "Quitar";
            btnQuitar.Click += delegate { if (Quitar != null) Quitar(this); };
            btnQuitar.MouseEnter += delegate { btnQuitar.BackColor = Color.FromArgb(253, 237, 235); };
            btnQuitar.MouseLeave += delegate { btnQuitar.BackColor = Color.White; };
            Controls.Add(btnQuitar);

            _lblUnitario = new Label();
            _lblUnitario.Location = new Point(12, 32);
            _lblUnitario.Size = new Size(180, 18);
            _lblUnitario.Font = UiUtil.Fuente(8.5f, FontStyle.Regular);
            _lblUnitario.ForeColor = TextoSuave;
            Controls.Add(_lblUnitario);

            _btnMenos = CrearBotonCantidad("-", new Point(12, 56));
            _btnMenos.Click += delegate { if (CambiarCantidad != null) CambiarCantidad(this, -1); };
            Controls.Add(_btnMenos);

            _lblCantidad = new Label();
            _lblCantidad.Location = new Point(40, 56);
            _lblCantidad.Size = new Size(38, 26);
            _lblCantidad.Font = UiUtil.Fuente(10f, FontStyle.Bold);
            _lblCantidad.ForeColor = Navy;
            _lblCantidad.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(_lblCantidad);

            _btnMas = CrearBotonCantidad("+", new Point(80, 56));
            _btnMas.Click += delegate { if (CambiarCantidad != null) CambiarCantidad(this, 1); };
            Controls.Add(_btnMas);

            _lblSubtotal = new Label();
            _lblSubtotal.Location = new Point(126, 56);
            _lblSubtotal.Size = new Size(146, 26);
            _lblSubtotal.Font = UiUtil.Fuente(10.5f, FontStyle.Bold);
            _lblSubtotal.ForeColor = Navy;
            _lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
            Controls.Add(_lblSubtotal);

            Refrescar();
        }

        private static Button CrearBotonCantidad(string texto, Point ubicacion)
        {
            Button b = new Button();
            b.Location = ubicacion;
            b.Size = new Size(26, 26);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = Color.FromArgb(206, 218, 226);
            b.BackColor = Color.FromArgb(245, 248, 250);
            b.ForeColor = Navy;
            b.Font = UiUtil.Fuente(11f, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.Text = texto;
            b.MouseEnter += delegate { b.BackColor = Color.FromArgb(229, 238, 243); };
            b.MouseLeave += delegate { b.BackColor = Color.FromArgb(245, 248, 250); };
            return b;
        }

        /// <summary>Refresca los textos con la cantidad y el subtotal actuales.</summary>
        public void Refrescar()
        {
            if (Item == null || Item.Producto == null) return;

            _lblNombre.Text = Item.Producto.Nombre;
            _lblUnitario.Text = "C$ " + Item.Producto.Precio.ToString("0.00") + " c/u  ·  " + Item.Producto.Categoria;
            _lblCantidad.Text = Item.Cantidad.ToString();
            _lblSubtotal.Text = "C$ " + Item.Subtotal.ToString("0.00");

            _btnMenos.Enabled = Item.Cantidad > 1;
            _btnMas.Enabled = Item.Cantidad < Item.Producto.Cantidad;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UiUtil.Redondear(this, 12);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath p = UiUtil.RutaRedondeada(r, 12))
            using (Pen pen = new Pen(Borde, 1f))
            {
                e.Graphics.DrawPath(pen, p);
            }
        }
    }
}
