using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    public partial class Bienvenida : Form
    {
        private double _ratioVideo = 16.0 / 9.0;
        private bool _ratioLeido;

        public Bienvenida()
        {
            InitializeComponent();
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            axPlayer.uiMode = "none";
            axPlayer.settings.autoStart = true;
            axPlayer.settings.setMode("loop", true);
            axPlayer.stretchToFit = true;
            axPlayer.enableContextMenu = false;
            axPlayer.OpenStateChange += axPlayer_OpenStateChange;
            axPlayer.URL = VideoHelper.RutaVideo();
            Reorganizar();
        }

        private void axPlayer_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (_ratioLeido) return;
            try
            {
                WMPLib.IWMPMedia media = axPlayer.currentMedia;
                if (media == null) return;
                string res = media.getItemInfo("Resolution");
                if (string.IsNullOrEmpty(res)) return;
                string[] partes = res.Split('x');
                int w = int.Parse(partes[0]);
                int h = int.Parse(partes[1]);
                if (w > 0 && h > 0)
                {
                    _ratioVideo = (double)w / h;
                    _ratioLeido = true;
                    Reorganizar();
                }
            }
            catch { }
        }

        private void Bienvenida_Resize(object sender, EventArgs e)
        {
            Reorganizar();
        }

        private void Reorganizar()
        {
            if (ClientSize.Width > 0 && ClientSize.Height > 0)
            {
                double ratioCliente = (double)ClientSize.Width / ClientSize.Height;
                int w, h;
                if (ratioCliente > _ratioVideo)
                {
                    w = ClientSize.Width;
                    h = (int)Math.Round(w / _ratioVideo);
                }
                else
                {
                    h = ClientSize.Height;
                    w = (int)Math.Round(h * _ratioVideo);
                }
                axPlayer.Bounds = new Rectangle((ClientSize.Width - w) / 2, (ClientSize.Height - h) / 2, w, h);
            }
            velo.Bounds = ClientRectangle;

            int ancho = ClientSize.Width;
            int alto = ClientSize.Height;

            etqTitulo.Bounds = new Rectangle(0, (int)(alto * 0.24), ancho, 70);
            etqSubtitulo.Bounds = new Rectangle(0, (int)(alto * 0.24) + 72, ancho, 36);
            btnIniciar.Size = new Size(300, 56);
            btnIniciar.Location = new Point((ancho - btnIniciar.Width) / 2, (int)(alto * 0.52));
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarSesion login = new IniciarSesion();
            login.Show();
            this.Hide();
        }
    }
}
