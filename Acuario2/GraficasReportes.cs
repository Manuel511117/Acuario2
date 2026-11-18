using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Acuario2
{
    public class DatoPuntoLinea
    {
        public string Etiqueta { get; set; }
        public double Valor { get; set; }
        public DateTime Fecha { get; set; }

        public DatoPuntoLinea() { }
        public DatoPuntoLinea(string etiqueta, double valor)
        {
            Etiqueta = etiqueta;
            Valor = valor;
        }
        public DatoPuntoLinea(DateTime fecha, string etiqueta, double valor)
        {
            Fecha = fecha;
            Etiqueta = etiqueta;
            Valor = valor;
        }
    }

    /// <summary>
    /// Gráfica de línea moderna con curva suave (GDI+ antialiasing),
    /// relleno inferior degradado semitransparente, ejes horizontales y etiquetas de fecha.
    /// Idéntica al mockup de Reportes.
    /// </summary>
    public class GraficaLinea : Control
    {
        private readonly List<DatoPuntoLinea> _datos = new List<DatoPuntoLinea>();

        public Color ColorLinea = Color.FromArgb(6, 182, 212);           // Cian brillante
        public Color ColorRellenoInicio = Color.FromArgb(70, 6, 182, 212); // Degradado superior
        public Color ColorRellenoFin = Color.FromArgb(5, 6, 182, 212);    // Casi transparente abajo
        public Color ColorEje = Color.FromArgb(235, 240, 245);           // Líneas de cuadrícula
        public Color ColorTexto = Color.FromArgb(148, 163, 184);         // Gris suave para etiquetas
        public Color ColorPunto = Color.FromArgb(6, 182, 212);

        public GraficaLinea()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
            Font = UiUtil.Fuente(8.25f, FontStyle.Regular);
        }

        private bool EnDiseno
        {
            get
            {
                if (DesignMode) return true;
                if (CapaAlpha.EsModoDisenoStatic) return true;
                if (Site != null && Site.DesignMode) return true;
                return false;
            }
        }

        public void Asignar(IEnumerable<DatoPuntoLinea> datos)
        {
            _datos.Clear();
            if (datos != null) _datos.AddRange(datos);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width <= 10 || Height <= 10) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            List<DatoPuntoLinea> puntos = _datos;
            if (puntos.Count == 0)
            {
                if (EnDiseno)
                {
                    puntos = new List<DatoPuntoLinea>
                    {
                        new DatoPuntoLinea("01 Abr", 1200),
                        new DatoPuntoLinea("07 Abr", 2800),
                        new DatoPuntoLinea("14 Abr", 2300),
                        new DatoPuntoLinea("21 Abr", 4200),
                        new DatoPuntoLinea("28 Abr", 3100),
                        new DatoPuntoLinea("30 Abr", 5500)
                    };
                }
                else
                {
                    TextRenderer.DrawText(g, "Sin ventas en el período", Font, ClientRectangle,
                        Color.FromArgb(150, 165, 178),
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                    return;
                }
            }

            int padLeft = 46;
            int padRight = 18;
            int padTop = 14;
            int padBottom = 26;

            int plotWidth = Width - padLeft - padRight;
            int plotHeight = Height - padTop - padBottom;
            if (plotWidth <= 20 || plotHeight <= 20) return;

            // Determinar valor máximo de escala
            double maxVal = 100;
            foreach (var d in puntos) if (d.Valor > maxVal) maxVal = d.Valor;

            // Redondear maxVal al múltiplo de 2000 o 1000 superior
            double pasoEje = 2000;
            if (maxVal <= 500) pasoEje = 100;
            else if (maxVal <= 2000) pasoEje = 500;
            else if (maxVal <= 10000) pasoEje = 2000;
            else if (maxVal <= 20000) pasoEje = 4000;
            else pasoEje = Math.Ceiling(maxVal / 4.0 / 1000.0) * 1000.0;

            int lineas = 4;
            double escalaMax = pasoEje * lineas;
            while (escalaMax < maxVal) escalaMax += pasoEje;

            // 1. Dibujar líneas horizontales de escala y etiquetas Y
            using (Pen penEje = new Pen(ColorEje, 1f))
            using (Brush brTexto = new SolidBrush(ColorTexto))
            {
                penEje.DashStyle = DashStyle.Dash;
                penEje.DashPattern = new float[] { 3f, 3f };

                for (int i = 0; i <= lineas; i++)
                {
                    double valorNivel = (escalaMax / lineas) * i;
                    float y = padTop + plotHeight - (float)((valorNivel / escalaMax) * plotHeight);

                    g.DrawLine(penEje, padLeft, y, padLeft + plotWidth, y);

                    string etiquetaY;
                    if (valorNivel == 0) etiquetaY = "$0";
                    else if (valorNivel >= 1000) etiquetaY = "$" + (valorNivel / 1000.0).ToString("0.#") + "k";
                    else etiquetaY = "$" + valorNivel.ToString("N0");

                    Rectangle rectEtiqueta = new Rectangle(0, (int)y - 8, padLeft - 6, 16);
                    TextRenderer.DrawText(g, etiquetaY, Font, rectEtiqueta, ColorTexto,
                        TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                }
            }

            // 2. Calcular coordenadas de puntos
            PointF[] coordPuntos = new PointF[puntos.Count];
            for (int i = 0; i < puntos.Count; i++)
            {
                float x = puntos.Count == 1 ? padLeft + plotWidth / 2f
                    : padLeft + (float)i / (puntos.Count - 1) * plotWidth;
                float y = padTop + plotHeight - (float)((puntos[i].Valor / escalaMax) * plotHeight);
                y = Math.Max(padTop, Math.Min(padTop + plotHeight, y));
                coordPuntos[i] = new PointF(x, y);
            }

            // 3. Dibujar área con relleno degradado bajo la curva
            if (coordPuntos.Length >= 2)
            {
                using (GraphicsPath pathArea = new GraphicsPath())
                {
                    pathArea.AddCurve(coordPuntos, 0.35f);
                    pathArea.AddLine(coordPuntos[coordPuntos.Length - 1].X, padTop + plotHeight,
                                     coordPuntos[0].X, padTop + plotHeight);
                    pathArea.CloseFigure();

                    Rectangle rectGrad = new Rectangle(padLeft, padTop, plotWidth, plotHeight + 2);
                    using (LinearGradientBrush brGrad = new LinearGradientBrush(
                        rectGrad, ColorRellenoInicio, ColorRellenoFin, LinearGradientMode.Vertical))
                    {
                        g.FillPath(brGrad, pathArea);
                    }
                }
            }

            // 4. Dibujar la línea de la curva
            using (Pen penLinea = new Pen(ColorLinea, 2.4f))
            {
                penLinea.LineJoin = LineJoin.Round;
                penLinea.StartCap = LineCap.Round;
                penLinea.EndCap = LineCap.Round;

                if (coordPuntos.Length == 1)
                {
                    g.DrawEllipse(penLinea, coordPuntos[0].X - 4, coordPuntos[0].Y - 4, 8, 8);
                }
                else
                {
                    g.DrawCurve(penLinea, coordPuntos, 0.35f);
                }
            }

            // 5. Dibujar puntos destacados y etiquetas X
            int pasoEtiquetas = puntos.Count > 6 ? (int)Math.Ceiling(puntos.Count / 5.0) : 1;
            float ultimoXImpreso = -999f;

            using (Brush brPunto = new SolidBrush(ColorPunto))
            using (Brush brCentro = new SolidBrush(Color.White))
            using (Pen penPuntoBorde = new Pen(Color.White, 1.5f))
            {
                for (int i = 0; i < puntos.Count; i++)
                {
                    PointF pt = coordPuntos[i];
                    g.FillEllipse(brPunto, pt.X - 3.5f, pt.Y - 3.5f, 7f, 7f);
                    g.DrawEllipse(penPuntoBorde, pt.X - 3.5f, pt.Y - 3.5f, 7f, 7f);

                    // Etiqueta X: evitar colisiones entre fechas cercanas
                    bool esUltimo = (i == puntos.Count - 1);
                    bool leToca = (i % pasoEtiquetas == 0);

                    if (leToca || esUltimo)
                    {
                        if (pt.X - ultimoXImpreso >= 44f)
                        {
                            Rectangle rectX = new Rectangle((int)pt.X - 30, padTop + plotHeight + 6, 60, 16);
                            TextRenderer.DrawText(g, puntos[i].Etiqueta, Font, rectX, ColorTexto,
                                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                            ultimoXImpreso = pt.X;
                        }
                    }
                }
            }
        }
    }

    public class DatoSegmentoDona
    {
        public string Categoria { get; set; }
        public double Valor { get; set; }
        public Color ColorSegmento { get; set; }

        public DatoSegmentoDona() { }
        public DatoSegmentoDona(string categoria, double valor, Color color)
        {
            Categoria = categoria;
            Valor = valor;
            ColorSegmento = color;
        }
    }

    /// <summary>
    /// Gráfica de dona (Donut Chart) circular con suavizado antialias,
    /// colores limpios idénticos al mockup y centro recortado.
    /// </summary>
    public class GraficaDona : Control
    {
        private readonly List<DatoSegmentoDona> _segmentos = new List<DatoSegmentoDona>();

        public GraficaDona()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
            Font = UiUtil.Fuente(8.5f, FontStyle.Regular);
        }

        private bool EnDiseno
        {
            get
            {
                if (DesignMode) return true;
                if (CapaAlpha.EsModoDisenoStatic) return true;
                if (Site != null && Site.DesignMode) return true;
                return false;
            }
        }

        public void Asignar(IEnumerable<DatoSegmentoDona> segmentos)
        {
            _segmentos.Clear();
            if (segmentos != null) _segmentos.AddRange(segmentos);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width <= 10 || Height <= 10) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            List<DatoSegmentoDona> datos = _segmentos;
            if (datos.Count == 0)
            {
                if (EnDiseno)
                {
                    datos = new List<DatoSegmentoDona>
                    {
                        new DatoSegmentoDona("Peces", 16250, Color.FromArgb(4, 175, 182)),
                        new DatoSegmentoDona("Plantas", 6450, Color.FromArgb(82, 196, 104)),
                        new DatoSegmentoDona("Alimentos", 5780, Color.FromArgb(245, 176, 65)),
                        new DatoSegmentoDona("Accesorios", 4210, Color.FromArgb(142, 68, 173))
                    };
                }
                else
                {
                    TextRenderer.DrawText(g, "Sin datos", Font, ClientRectangle,
                        Color.FromArgb(150, 165, 178),
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
                    return;
                }
            }

            double total = 0;
            foreach (var s in datos) total += s.Valor;
            if (total <= 0) return;

            int diametro = Math.Min(Width, Height) - 16;
            if (diametro <= 20) return;

            int cx = Width / 2;
            int cy = Height / 2;
            Rectangle rectExterior = new Rectangle(cx - diametro / 2, cy - diametro / 2, diametro, diametro);

            int diametroInterior = (int)(diametro * 0.52f);
            Rectangle rectInterior = new Rectangle(cx - diametroInterior / 2, cy - diametroInterior / 2, diametroInterior, diametroInterior);

            float anguloActual = -90f; // Comenzar arriba

            // Dibujar cada segmento como anillo
            for (int i = 0; i < datos.Count; i++)
            {
                var seg = datos[i];
                float barrido = (float)((seg.Valor / total) * 360.0);
                if (barrido <= 0.05f) continue;

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(rectExterior, anguloActual, barrido);
                    path.AddArc(rectInterior, anguloActual + barrido, -barrido);
                    path.CloseFigure();

                    using (Brush br = new SolidBrush(seg.ColorSegmento))
                    {
                        g.FillPath(br, path);
                    }

                    // Separador sutil blanco entre segmentos
                    using (Pen penSep = new Pen(Color.White, 2f))
                    {
                        g.DrawPath(penSep, path);
                    }
                }

                anguloActual += barrido;
            }

            // Círculo interior limpio
            using (Brush brCentro = new SolidBrush(BackColor))
            {
                g.FillEllipse(brCentro, rectInterior);
            }
        }
    }
}
