using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    public partial class IniciarSesion : Form
    {
        private double _ratioVideo = 16.0 / 9.0;
        private bool _ratioLeido;

        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void IniciarSesion_Load(object sender, EventArgs e)
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

            tarjeta.BringToFront();
            txtUsuario.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tarjeta.BringToFront();
            txtUsuario.Focus();
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

        private void IniciarSesion_Resize(object sender, EventArgs e)
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

            tarjeta.Location = new Point((ClientSize.Width - tarjeta.Width) / 2,
                                         (ClientSize.Height - tarjeta.Height) / 2);
            tarjeta.BringToFront();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
            {
                lblError.Text = "Ingrese usuario y contraseña.";
                lblError.Visible = true;
                return;
            }

            string mensaje;
            if (ConexionDB.ValidarUsuario(usuario, clave, out mensaje))
            {
                lblError.Visible = false;
                Form1 principal = new Form1();
                principal.Usuario = usuario;
                principal.Show();
                this.Close();
            }
            else
            {
                lblError.Text = mensaje;
                lblError.Visible = true;
            }
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            Bienvenida bienvenida = new Bienvenida();
            bienvenida.Show();
            this.Close();
        }

        private void IniciarSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lblVolver_Click(sender, e);
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
