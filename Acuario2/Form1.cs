using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acuario2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\V1.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.play();

            // --- EL TRUCO MÁGICO ---
            // Hacemos que el reproductor no acepte clics, PERO seguimos mandando el video al frente
            axWindowsMediaPlayer1.Enabled = false;
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            // Si el video se llegó a pausar por perder el foco, lo reanudamos
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login logn = new Login();
            logn.ShowDialog();
            this.Close();
        }
    }
}
