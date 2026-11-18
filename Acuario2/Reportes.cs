using System;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
            this.Text = "AquaControl - Reportes";
            this.Size = new Size(1180, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 248, 250);
            SetupUI();
        }

        private void SetupUI()
        {
            this.Controls.Clear();
            ControlReportes ctrl = new ControlReportes
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(ctrl);
            ctrl.Recargar();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
