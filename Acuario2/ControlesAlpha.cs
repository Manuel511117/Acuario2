using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Acuario2
{
    public abstract class CapaAlpha : Control
    {
        private const int WS_EX_LAYERED = 0x00080000;
        private const int ULW_ALPHA = 0x00000002;
        private const byte AC_SRC_OVER = 0;
        private const byte AC_SRC_ALPHA = 1;

        [StructLayout(LayoutKind.Sequential)]
        private struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE { public int cx; public int cy; }
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT { public int x; public int y; }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst,
            ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr obj);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr obj);

        protected CapaAlpha()
        {
            SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable, true);
            TabStop = false;
        }

        /// <summary>
        /// Detecta si el control se está ejecutando en el entorno del diseñador de Visual Studio.
        /// </summary>
        public static bool EsModoDisenoStatic
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return true;
                try
                {
                    string proc = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                    if (proc.IndexOf("devenv", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        proc.IndexOf("DesignToolsServer", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        proc.IndexOf("Blend", StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }
                catch { }
                return false;
            }
        }

        protected bool EnDiseno
        {
            get
            {
                if (DesignMode) return true;
                if (EsModoDisenoStatic) return true;
                if (Site != null && Site.DesignMode) return true;
                Control padre = Parent;
                while (padre != null)
                {
                    if (padre.Site != null && padre.Site.DesignMode) return true;
                    padre = padre.Parent;
                }
                return false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!EnDiseno)
                {
                    cp.ExStyle |= WS_EX_LAYERED;
                }
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (EnDiseno)
            {
                base.OnPaintBackground(pevent);
            }
        }

        protected sealed override void OnPaint(PaintEventArgs e)
        {
            if (EnDiseno)
            {
                Dibujar(e.Graphics);
                return;
            }
            Aplicar();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!EnDiseno) Aplicar();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!EnDiseno) Aplicar();
            else Invalidate();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (!EnDiseno) Aplicar();
            else Invalidate();
        }

        private void Aplicar()
        {
            if (EnDiseno) return;
            if (Width <= 0 || Height <= 0 || !IsHandleCreated) return;

            try
            {
                using (Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                        Dibujar(g);
                    }
                    AplicarULW(bmp);
                }
            }
            catch { }
        }

        private bool AplicarULW(Bitmap bmp)
        {
            if (EnDiseno || !IsHandleCreated) return false;
            bool resultado = false;
            IntPtr hBitmap = bmp.GetHbitmap(Color.FromArgb(0, 0, 0));
            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr old = SelectObject(memDc, hBitmap);
            try
            {
                POINT src = new POINT();
                SIZE size = new SIZE { cx = Width, cy = Height };
                POINT dst = new POINT { x = Location.X, y = Location.Y };
                BLENDFUNCTION blend = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = AC_SRC_ALPHA
                };
                resultado = UpdateLayeredWindow(Handle, screenDc, ref dst, ref size, memDc, ref src, 0, ref blend, ULW_ALPHA);
            }
            catch { }
            finally
            {
                SelectObject(memDc, old);
                DeleteDC(memDc);
                ReleaseDC(IntPtr.Zero, screenDc);
                DeleteObject(hBitmap);
            }
            return resultado;
        }

        protected abstract void Dibujar(Graphics g);

        protected void Refrescar()
        {
            if (EnDiseno)
            {
                Invalidate();
                return;
            }
            Aplicar();
        }
    }

    public class VeloAlpha : CapaAlpha
    {
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private Color _color;

        public VeloAlpha() : this(Color.FromArgb(160, 3, 8, 16))
        {
        }

        public VeloAlpha(Color color)
        {
            _color = color;
        }

        [Category("Appearance")]
        public Color ColorVelo
        {
            get { return _color; }
            set { _color = value; Refrescar(); }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!EnDiseno)
                {
                    cp.ExStyle |= WS_EX_TRANSPARENT;
                }
                return cp;
            }
        }

        protected override void Dibujar(Graphics g)
        {
            using (SolidBrush b = new SolidBrush(_color))
            {
                g.FillRectangle(b, ClientRectangle);
            }
        }
    }

    public class EtiquetaAlpha : CapaAlpha
    {
        private string _texto = "";
        private Font _fuente = new Font("Segoe UI", 14f, FontStyle.Bold);
        private Color _colorTexto = Color.White;
        private ContentAlignment _alineacion = ContentAlignment.MiddleCenter;

        public EtiquetaAlpha()
        {
        }

        public string Texto
        {
            get { return _texto; }
            set { _texto = value ?? ""; Refrescar(); }
        }

        public Font Fuente
        {
            get { return _fuente; }
            set { _fuente = value; Refrescar(); }
        }

        public Color ColorTexto
        {
            get { return _colorTexto; }
            set { _colorTexto = value; Refrescar(); }
        }

        public ContentAlignment Alineacion
        {
            get { return _alineacion; }
            set { _alineacion = value; Refrescar(); }
        }

        protected override void Dibujar(Graphics g)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
            if ((_alineacion & ContentAlignment.MiddleLeft) != 0) flags |= TextFormatFlags.Left;
            else if ((_alineacion & ContentAlignment.MiddleRight) != 0) flags |= TextFormatFlags.Right;
            else flags |= TextFormatFlags.HorizontalCenter;

            if ((_alineacion & ContentAlignment.TopCenter) != 0 || (_alineacion & ContentAlignment.TopLeft) != 0 || (_alineacion & ContentAlignment.TopRight) != 0)
                flags |= TextFormatFlags.Top;
            else if ((_alineacion & ContentAlignment.BottomCenter) != 0 || (_alineacion & ContentAlignment.BottomLeft) != 0 || (_alineacion & ContentAlignment.BottomRight) != 0)
                flags |= TextFormatFlags.Bottom;
            else flags |= TextFormatFlags.VerticalCenter;

            TextRenderer.DrawText(g, _texto, _fuente, ClientRectangle, _colorTexto, flags);
        }
    }

    public class BotonAlpha : CapaAlpha
    {
        private string _texto = "";
        private Font _fuente = new Font("Segoe UI", 12f, FontStyle.Bold);
        private Color _colorTexto = Color.White;
        private Color _colorBorde = Color.FromArgb(255, 46, 196, 182);
        private Color _rellenoHover = Color.FromArgb(70, 46, 196, 182);
        private Color _bordeHover = Color.White;
        private int _radio = 14;
        private bool _hover;
        private bool _presionado;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value ?? ""; Refrescar(); }
        }

        public Font Fuente
        {
            get { return _fuente; }
            set { _fuente = value; Refrescar(); }
        }

        public Color ColorTexto
        {
            get { return _colorTexto; }
            set { _colorTexto = value; Refrescar(); }
        }

        public Color ColorBorde
        {
            get { return _colorBorde; }
            set { _colorBorde = value; Refrescar(); }
        }

        public Color RellenoHover
        {
            get { return _rellenoHover; }
            set { _rellenoHover = value; Refrescar(); }
        }

        public int Radio
        {
            get { return _radio; }
            set { _radio = value; Refrescar(); }
        }

        public BotonAlpha()
        {
            Cursor = Cursors.Hand;
            SetStyle(ControlStyles.Selectable, true);
        }

        protected GraphicsPath RutaRedondeada(Rectangle r, int radio)
        {
            int d = Math.Min(radio * 2, Math.Min(r.Width, r.Height));
            GraphicsPath path = new GraphicsPath();
            if (d <= 2)
            {
                path.AddRectangle(r);
                path.CloseFigure();
                return path;
            }
            Arc(r.X, r.Y, d, d, 180, 90, path);
            Arc(r.Right - d, r.Y, d, d, 270, 90, path);
            Arc(r.Right - d, r.Bottom - d, d, d, 0, 90, path);
            Arc(r.X, r.Bottom - d, d, d, 90, 90, path);
            path.CloseFigure();
            return path;
        }

        private static void Arc(int x, int y, int w, int h, int inicio, int barrido, GraphicsPath path)
        {
            path.AddArc(x, y, w, h, inicio, barrido);
        }

        protected override void Dibujar(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle area = new Rectangle(1, 1, Math.Max(1, Width - 3), Math.Max(1, Height - 3));

            using (GraphicsPath ruta = RutaRedondeada(area, _radio))
            {
                if (_hover)
                {
                    using (SolidBrush b = new SolidBrush(_rellenoHover))
                    {
                        g.FillPath(b, ruta);
                    }
                }
                Color borde = _hover ? _bordeHover : _colorBorde;
                using (Pen p = new Pen(borde, 2f))
                {
                    g.DrawPath(p, ruta);
                }
            }

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                                    TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;
            TextRenderer.DrawText(g, _texto, _fuente, ClientRectangle, _colorTexto, flags);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _hover = true;
            Refrescar();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _hover = false;
            _presionado = false;
            Refrescar();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _presionado = true;
                if (CanFocus && !Focused) Focus();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left && _presionado && ClientRectangle.Contains(e.Location))
            {
                OnClick(EventArgs.Empty);
            }
            _presionado = false;
        }
    }

    public class PanelRedondeado : Panel
    {
        public int Radio = 16;
        public Color ColorBorde = Color.FromArgb(255, 46, 196, 182);

        public PanelRedondeado()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
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

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            if (Width <= 2 || Height <= 2) return;

            // En modo diseño de Visual Studio no modificamos Region
            // para no interferir con los manejadores de selección y redimensionamiento.
            if (EnDiseno)
            {
                Invalidate();
                return;
            }

            try
            {
                using (GraphicsPath p = Ruta())
                {
                    Region nueva = new Region(p);
                    Region anterior = Region;
                    Region = nueva;
                    if (anterior != null) anterior.Dispose();
                }
            }
            catch { }
            Invalidate();
        }

        private GraphicsPath Ruta()
        {
            Rectangle r = new Rectangle(0, 0, Math.Max(1, Width), Math.Max(1, Height));
            int d = Math.Min(Radio * 2, Math.Min(r.Width, r.Height));
            GraphicsPath path = new GraphicsPath();
            if (d <= 2)
            {
                path.AddRectangle(r);
                path.CloseFigure();
                return path;
            }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (Width <= 0 || Height <= 0) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath p = Ruta())
            using (SolidBrush b = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(b, p);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Width <= 0 || Height <= 0) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath p = Ruta())
            using (Pen pen = new Pen(ColorBorde, 2f))
            {
                e.Graphics.DrawPath(pen, p);
            }
        }
    }
}
