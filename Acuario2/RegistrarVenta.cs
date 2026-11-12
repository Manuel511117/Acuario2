using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Formulario "Registrar Venta": elige un producto, categoría, cantidad y precio.
    /// Al guardar inserta la venta en la BD y descuenta el stock del inventario.
    /// </summary>
    public partial class RegistrarVenta : Form
    {
        /// <summary>Usuario que registra la venta.</summary>
        public string Usuario = "";

        private List<Producto> _productos = new List<Producto>();
        private bool _cargando;

        /// <summary>Elemento del combo de productos con su stock visible.</summary>
        private class ItemProducto
        {
            public Producto Producto;

            public override string ToString()
            {
                if (Producto == null) return "";
                return Producto.Nombre + "   ·   stock: " + Producto.Cantidad;
            }
        }

        public RegistrarVenta()
        {
            InitializeComponent();
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
        {
            UiUtil.Redondear(btnGuardar, 21);
            UiUtil.Redondear(btnCancelar, 21);

            cboCategoria.Items.Clear();
            cboCategoria.Items.AddRange(ConexionDB.CategoriasVenta);

            string mensaje;
            _productos = ConexionDB.ListarProductos(out mensaje);

            _cargando = true;
            cboProducto.Items.Clear();
            foreach (Producto p in _productos)
            {
                if (p.Cantidad > 0) cboProducto.Items.Add(new ItemProducto { Producto = p });
            }
            _cargando = false;

            if (cboProducto.Items.Count == 0)
            {
                lblStock.Text = "No hay productos con stock disponible.";
                btnGuardar.Enabled = false;
            }
            else
            {
                cboProducto.SelectedIndex = 0;
            }

            ActualizarTotal();
            cboProducto.Focus();
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando) return;

            ItemProducto item = cboProducto.SelectedItem as ItemProducto;
            if (item == null || item.Producto == null) return;

            Producto p = item.Producto;
            numPrecio.Value = Math.Max(numPrecio.Minimum, Math.Min(numPrecio.Maximum, p.Precio));

            numCantidad.Maximum = Math.Max(1, p.Cantidad);
            if (numCantidad.Value > p.Cantidad) numCantidad.Value = Math.Max(1, p.Cantidad);

            string sugerida = ConexionDB.CategoriaSugerida(p);
            int indice = cboCategoria.Items.IndexOf(sugerida);
            cboCategoria.SelectedIndex = indice >= 0 ? indice : 0;

            lblStock.Text = "Stock disponible: " + p.Cantidad +
                            (p.Cantidad == 1 ? " unidad" : " unidades") +
                            "  ·  Especie: " + p.Especie;
            lblStock.ForeColor = Color.FromArgb(95, 115, 135);

            ActualizarTotal();
        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void numPrecio_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = numCantidad.Value * numPrecio.Value;
            lblTotalValor.Text = "$" + total.ToString("N2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            ItemProducto item = cboProducto.SelectedItem as ItemProducto;
            if (item == null || item.Producto == null)
            {
                MostrarError("Seleccione un producto.");
                return;
            }

            Producto p = item.Producto;
            int cantidad = (int)numCantidad.Value;

            if (cantidad <= 0)
            {
                MostrarError("La cantidad debe ser mayor que cero.");
                numCantidad.Focus();
                return;
            }
            if (cantidad > p.Cantidad)
            {
                MostrarError("La cantidad supera el stock disponible (" + p.Cantidad + ").");
                numCantidad.Focus();
                return;
            }

            string categoria = cboCategoria.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(categoria))
            {
                MostrarError("Seleccione una categoría.");
                cboCategoria.Focus();
                return;
            }

            Venta v = new Venta();
            v.ProductoId = p.Id;
            v.Categoria = categoria;
            v.Cantidad = cantidad;
            v.Precio = numPrecio.Value;
            v.Usuario = Usuario;

            string mensaje;
            if (ConexionDB.RegistrarVenta(v, out mensaje))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MostrarError(string.IsNullOrEmpty(mensaje) ? "No se pudo registrar la venta." : mensaje);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
