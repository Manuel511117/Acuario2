using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Utilidades visuales compartidas: formas redondeadas, carga de imágenes
    /// (carpeta "imagenes" junto al exe), fuentes reutilizadas y miniaturas.
    /// </summary>
    public static class UiUtil
    {
        private static readonly Dictionary<string, Image> _imagenes = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, Font> _fuentes = new Dictionary<string, Font>();
        private static Image _sinImagen;

        // ------------------------------------------------------------ formas

        /// <summary>Ruta de un rectángulo con las esquinas redondeadas.</summary>
        public static GraphicsPath RutaRedondeada(Rectangle r, int radio)
        {
            int d = Math.Min(radio * 2, Math.Min(r.Width, r.Height));
            GraphicsPath p = new GraphicsPath();
            if (d <= 2)
            {
                p.AddRectangle(r);
                p.CloseFigure();
                return p;
            }
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        /// <summary>Redondea los bordes de un control (recorta su región).</summary>
        public static void Redondear(Control c, int radio)
        {
            if (c == null || c.Width <= 2 || c.Height <= 2) return;
            GraphicsPath p = RutaRedondeada(c.ClientRectangle, radio);
            Region anterior = c.Region;
            c.Region = new Region(p);
            p.Dispose();
            if (anterior != null) anterior.Dispose();
        }

        // ------------------------------------------------------------ fuentes

        /// <summary>Fuente Segoe UI reutilizable (evita crear fuentes en cada pintada).</summary>
        public static Font Fuente(float tam, FontStyle estilo)
        {
            string clave = tam.ToString("0.0##") + "|" + (int)estilo;
            Font f;
            if (_fuentes.TryGetValue(clave, out f) && f != null) return f;
            f = new Font("Segoe UI", tam, estilo);
            _fuentes[clave] = f;
            return f;
        }

        // ------------------------------------------------------------ imágenes

        /// <summary>Carpeta "imagenes" junto al exe (se crea si no existe).</summary>
        public static string CarpetaImagenes()
        {
            string carpeta = Path.Combine(Application.StartupPath, "imagenes");
            try
            {
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);
            }
            catch { }
            return carpeta;
        }

        /// <summary>
        /// Carga una imagen de la carpeta imágenes. Acepta "logo.png" (va a imagenes\)
        /// o "imagenes\prod_1.png" (ruta relativa guardada en la BD). Usa caché.
        /// </summary>
        public static Image Imagen(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return null;

            string clave = nombre.ToLowerInvariant();
            Image guardada;
            if (_imagenes.TryGetValue(clave, out guardada)) return guardada;

            string ruta;
            if (Path.IsPathRooted(nombre)) ruta = nombre;
            else if (nombre.IndexOf(Path.DirectorySeparatorChar) >= 0 || nombre.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
                ruta = Path.Combine(Application.StartupPath, nombre);
            else ruta = Path.Combine(CarpetaImagenes(), nombre);

            Image img = null;
            try { if (File.Exists(ruta)) img = Image.FromFile(ruta); }
            catch { img = null; }

            _imagenes[clave] = img;
            return img;
        }

        /// <summary>Carga la imagen de un producto (ruta relativa de la BD, puede venir vacía).</summary>
        public static Image ImagenProducto(string rutaRelativa)
        {
            if (string.IsNullOrWhiteSpace(rutaRelativa)) return null;
            return Imagen(rutaRelativa);
        }

        /// <summary>Olvida la imagen en caché (para cuando el archivo cambia).</summary>
        public static void InvalidarImagen(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return;
            string clave = nombre.ToLowerInvariant();
            Image img;
            if (_imagenes.TryGetValue(clave, out img))
            {
                _imagenes.Remove(clave);
                if (img != null && !object.ReferenceEquals(img, _sinImagen)) { try { img.Dispose(); } catch { } }
            }
        }

        /// <summary>Copia la imagen elegida a la carpeta imágenes y devuelve la ruta relativa para la BD.</summary>
        public static string ImportarImagen(string origen)
        {
            string ext = Path.GetExtension(origen).ToLowerInvariant();
            if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".bmp" && ext != ".gif" && ext != ".wmf") ext = ".png";
            string nombre = "prod_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ext;
            string destino = Path.Combine(CarpetaImagenes(), nombre);
            File.Copy(origen, destino, true);
            return Path.Combine("imagenes", nombre);
        }

        /// <summary>
        /// Elimina el archivo de imagen de un producto. Solo borra archivos que estén
        /// dentro de la carpeta "imagenes" (nunca rutas ajenas). Si falla, no hace nada.
        /// </summary>
        public static void EliminarImagen(string rutaRelativa)
        {
            if (string.IsNullOrWhiteSpace(rutaRelativa)) return;
            try
            {
                string carpeta = Path.GetFullPath(CarpetaImagenes());
                string ruta = Path.IsPathRooted(rutaRelativa)
                    ? rutaRelativa
                    : Path.Combine(Application.StartupPath, rutaRelativa);
                string completa = Path.GetFullPath(ruta);
                if (!completa.StartsWith(carpeta, StringComparison.OrdinalIgnoreCase)) return;

                InvalidarImagen(rutaRelativa);
                if (File.Exists(completa)) File.Delete(completa);
            }
            catch { }
        }

        /// <summary>Copia de la imagen escalada manteniendo la proporción (o null).</summary>
        public static Image Escalar(Image img, int maxW, int maxH)
        {
            if (img == null || maxW <= 0 || maxH <= 0) return null;
            double escala = Math.Min((double)maxW / img.Width, (double)maxH / img.Height);
            if (escala <= 0) return null;
            int w = Math.Max(1, (int)Math.Round(img.Width * escala));
            int h = Math.Max(1, (int)Math.Round(img.Height * escala));
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(img, new Rectangle(0, 0, w, h));
            }
            return bmp;
        }

        /// <summary>Imágen de reemplazo para productos sin foto.</summary>
        public static Image SinImagen(int lado)
        {
            if (_sinImagen != null) return _sinImagen;
            Bitmap b = new Bitmap(lado, lado);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Color c = Color.FromArgb(186, 203, 215);
                using (Pen p = new Pen(c, 2f)) g.DrawRectangle(p, 5, 5, lado - 11, lado - 11);
                using (Pen p = new Pen(c, 2f))
                {
                    g.DrawLine(p, lado / 2f - 6, lado / 2f, lado / 2f + 6, lado / 2f);
                    g.DrawLine(p, lado / 2f, lado / 2f - 6, lado / 2f, lado / 2f + 6);
                }
            }
            _sinImagen = b;
            return b;
        }

        /// <summary>Miniatura (cacheada) para la columna Ver de la grilla.</summary>
        public static Image Minatura(string rutaRelativa, int lado)
        {
            string clave = "thumb|" + (rutaRelativa ?? "").ToLowerInvariant() + "|" + lado;
            Image cache;
            if (_imagenes.TryGetValue(clave, out cache) && cache != null) return cache;

            Image img = ImagenProducto(rutaRelativa);
            Image mini = img == null ? SinImagen(lado) : Escalar(img, lado, lado);
            if (mini == null) mini = SinImagen(lado);
            _imagenes[clave] = mini;
            return mini;
        }
    }
}
