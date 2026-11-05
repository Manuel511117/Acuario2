using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Gráfica de barras dibujada a mano (vertical u horizontal) con la paleta del
    /// mockup. No usa DataVisualization: control total del aspecto y cero referencias.
    /// </summary>
    public class GraficaBarras : Control
    {
        private readonly List<DatoGrafica> _datos = new List<DatoGrafica>();

        public Color ColorBarra = Color.FromArgb(3, 50, 90);        // navy principal
        public Color ColorDestacado = Color.FromArgb(4, 175, 182);  // cian acento
        public Color ColorTextoValor = Color.FromArgb(3, 50, 90);
        public Color ColorTextoEtiqueta = Color.FromArgb(95, 115, 135);
        public Color ColorLineaBase = Color.FromArgb(226, 233, 239);
        public bool Horizontal = false;
        public string Formato = "N0";
        public int TopeEtiquetas = 8;

        public GraficaBarras()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
            Font = UiUtil.Fuente(8.5f, FontStyle.Regular);
        }

        /// <summary>Asigna los datos a representar (etiqueta + valor).</summary>
        public void Asignar(IEnumerable<DatoGrafica> datos)
        {
            _datos.Clear();
            if (datos != null) _datos.AddRange(datos);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (_datos.Count == 0)
            {
                TextRenderer.DrawText(g, "Sin datos disponibles", Font, ClientRectangle,
                    Color.FromArgb(150, 165, 178),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                return;
            }

            if (Horizontal) PintarHorizontal(g);
            else PintarVertical(g);
        }

        private int IndiceMejor(List<DatoGrafica> datos)
        {
            int mejor = 0;
            for (int i = 1; i < datos.Count; i++)
                if (datos[i].Valor > datos[mejor].Valor) mejor = i;
            return mejor;
        }

        private void PintarVertical(Graphics g)
        {
            List<DatoGrafica> datos = _datos.Count > TopeEtiquetas ? _datos.GetRange(0, TopeEtiquetas) : _datos;
            double max = 1;
            foreach (DatoGrafica d in datos) max = Math.Max(max, d.Valor);

            Rectangle area = new Rectangle(8, 26, Math.Max(20, Width - 16), Math.Max(30, Height - 50));
            int n = datos.Count;
            int hueco = 14;
            int ancho = (area.Width - hueco * (n + 1)) / n;
            if (ancho < 8)
            {
                ancho = 8;
                hueco = Math.Max(2, (area.Width - ancho * n) / (n + 1));
            }

            Font fValor = UiUtil.Fuente(8.5f, FontStyle.Bold);
            Font fEtiqueta = UiUtil.Fuente(8f, FontStyle.Regular);
            int mejor = IndiceMejor(datos);

            for (int i = 0; i < n; i++)
            {
                DatoGrafica d = datos[i];
                int alto = (int)Math.Round(area.Height * (d.Valor / max));
                if (alto < 4) alto = 4;
                int x = area.X + hueco + i * (ancho + hueco);
                int y = area.Bottom - alto;
                Rectangle r = new Rectangle(x, y, ancho, alto);

                Color c = (i == mejor) ? ColorDestacado : ColorBarra;
                using (GraphicsPath ruta = UiUtil.RutaRedondeada(r, Math.Min(5, ancho / 2)))
                using (SolidBrush b = new SolidBrush(c)) g.FillPath(b, ruta);

                string valor = d.Valor.ToString(Formato);
                TextRenderer.DrawText(g, valor, fValor,
                    new Rectangle(x - 10, y - 21, ancho + 20, 19), ColorTextoValor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);

                TextRenderer.DrawText(g, d.Etiqueta, fEtiqueta,
                    new Rectangle(x - 10, area.Bottom + 5, ancho + 20, 19), ColorTextoEtiqueta,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
            }

            using (Pen pluma = new Pen(ColorLineaBase, 1f))
                g.DrawLine(pluma, area.X, area.Bottom + 1, area.Right, area.Bottom + 1);
        }

        private void PintarHorizontal(Graphics g)
        {
            List<DatoGrafica> datos = _datos.Count > TopeEtiquetas ? _datos.GetRange(0, TopeEtiquetas) : _datos;
            double max = 1;
            foreach (DatoGrafica d in datos) max = Math.Max(max, d.Valor);

            int n = datos.Count;
            int altoFila = Math.Max(16, (Height - 2) / n);
            int anchoEtiqueta = Math.Max(56, (int)(Width * 0.33));
            int xBarra = anchoEtiqueta + 8;
            int anchoMax = Width - xBarra - 48;
            if (anchoMax < 24) anchoMax = 24;

            Font fValor = UiUtil.Fuente(8.5f, FontStyle.Bold);
            Font fEtiqueta = UiUtil.Fuente(8.5f, FontStyle.Regular);
            int mejor = IndiceMejor(datos);

            for (int i = 0; i < n; i++)
            {
                DatoGrafica d = datos[i];
                int y = i * altoFila;

                TextRenderer.DrawText(g, d.Etiqueta, fEtiqueta,
                    new Rectangle(0, y, anchoEtiqueta, altoFila), ColorTextoEtiqueta,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);

                int altoBarra = Math.Min(16, Math.Max(8, altoFila - 8));
                int by = y + (altoFila - altoBarra) / 2;
                int bw = (int)Math.Round(anchoMax * (d.Valor / max));
                if (bw < 4) bw = 4;
                Rectangle r = new Rectangle(xBarra, by, bw, altoBarra);

                Color c = (i == mejor) ? ColorDestacado : ColorBarra;
                using (GraphicsPath ruta = UiUtil.RutaRedondeada(r, Math.Min(5, altoBarra / 2)))
                using (SolidBrush b = new SolidBrush(c)) g.FillPath(b, ruta);

                TextRenderer.DrawText(g, d.Valor.ToString(Formato), fValor,
                    new Rectangle(Width - 46, y, 46, altoFila), ColorTextoValor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
            }
        }
    }
}
