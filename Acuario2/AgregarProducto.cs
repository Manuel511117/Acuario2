using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Formulario "Agregar Producto" (también usado para editar).
    /// Encabezado navy #03325A, imagen copiada a la carpeta "imagenes" junto al exe.
    /// </summary>
    public partial class AgregarProducto : Form
    {
        /// <summary>Producto a editar; null = modo agregar.</summary>
        public Producto Editando = null;

        private string _imagenRelativa = "";

        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void AgregarProducto_Load(object sender, EventArgs e)
        {
            RedondearBotones();

            if (Editando != null)
            {
                lblEncabezado.Text = "Editar Producto";
                this.Text = "Editar Producto";
                btnGuardar.Text = "Guardar cambios";
                txtNombre.Text = Editando.Nombre;
                if (!string.IsNullOrEmpty(Editando.Especie)) cboEspecie.Text = Editando.Especie;
                numCantidad.Value = Math.Max(numCantidad.Minimum, Math.Min(numCantidad.Maximum, Editando.Cantidad));
                numPrecio.Value = Math.Max(numPrecio.Minimum, Math.Min(numPrecio.Maximum, Editando.Precio));
                _imagenRelativa = Editando.Imagen ?? "";
            }

            MostrarImagen();
            txtNombre.Focus();
            txtNombre.SelectAll();
        }

        private void RedondearBotones()
        {
            UiUtil.Redondear(btnGuardar, 21);
            UiUtil.Redondear(btnCancelar, 21);
            UiUtil.Redondear(btnImagen, 17);
            UiUtil.Redondear(picImagen, 10);
        }

        /// <summary>Muestra la imagen seleccionada y su información.</summary>
        private void MostrarImagen()
        {
            Image img = UiUtil.ImagenProducto(_imagenRelativa);
            picImagen.Image = img;
            txtRuta.Text = _imagenRelativa;

            if (img == null)
            {
                lblInfo.Text = "Sin imagen seleccionada." + Environment.NewLine +
                               "La imagen se guardara en la carpeta \"imagenes\"" +
                               Environment.NewLine + "junto al programa y se mostrara en la columna Ver.";
            }
            else
            {
                lblInfo.Text = "Archivo: " + Path.GetFileName(_imagenRelativa) + Environment.NewLine +
                               "Tamano: " + img.Width + " x " + img.Height + " px" + Environment.NewLine +
                               "Se guardara en la carpeta imagenes.";
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Seleccionar imagen del producto";
                dlg.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif|Todos los archivos|*.*";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    _imagenRelativa = UiUtil.ImportarImagen(dlg.FileName);
                    MostrarImagen();
                    lblError.Visible = false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("btnImagen_Click: " + ex);
                    MostrarError("No se pudo cargar la imagen elegida.");
                }
            }
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string nombre = (txtNombre.Text ?? "").Trim();
            string especie = (cboEspecie.Text ?? "").Trim();

            if (nombre.Length == 0)
            {
                MostrarError("Ingrese el nombre del producto.");
                txtNombre.Focus();
                return;
            }
            if (especie.Length == 0)
            {
                MostrarError("Ingrese la especie del producto.");
                cboEspecie.Focus();
                return;
            }

            Producto p = new Producto();
            p.Nombre = nombre;
            p.Especie = especie;
            p.Cantidad = (int)numCantidad.Value;
            p.Precio = numPrecio.Value;
            p.Imagen = _imagenRelativa;

            string mensaje;
            bool ok;
            if (Editando != null)
            {
                p.Id = Editando.Id;
                ok = ConexionDB.ActualizarProducto(p, out mensaje);
            }
            else
            {
                ok = ConexionDB.InsertarProducto(p, out mensaje);
            }

            if (ok)
            {
                // si se reemplazo la imagen, borra el archivo anterior (evita huérfanos)
                if (Editando != null && !string.IsNullOrWhiteSpace(Editando.Imagen) &&
                    !string.Equals(Editando.Imagen, _imagenRelativa, StringComparison.OrdinalIgnoreCase))
                {
                    UiUtil.EliminarImagen(Editando.Imagen);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MostrarError(string.IsNullOrEmpty(mensaje) ? "No se pudo guardar el producto." : mensaje);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
