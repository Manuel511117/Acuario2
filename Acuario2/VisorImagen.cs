using System;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    /// <summary>
    /// Visor de la imagen de un producto (se abre desde la columna "Ver" de la grilla).
    /// Formulario construido en código (sin archivo de diseñador).
    /// </summary>
    public class VisorImagen : Form
    {
        private readonly PictureBox _pic;
        private readonly Label _lblInfo;

        public VisorImagen() : this("Vista previa", "")
        {
        }

        public VisorImagen(string titulo, string rutaRelativa)
        {
            string nombre = string.IsNullOrWhiteSpace(titulo) ? "producto" : titulo;

            Text = "Imagen de " + nombre;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            KeyPreview = true;
            BackColor = Color.FromArgb(245, 248, 250);
            ClientSize = new Size(560, 570);

            // encabezado navy
            Panel pan = new Panel();
            pan.Location = new Point(0, 0);
            pan.Size = new Size(560, 66);
            pan.BackColor = Color.FromArgb(3, 50, 90);

            Label lbl = new Label();
            lbl.Text = nombre;
            lbl.ForeColor = Color.White;
            lbl.Font = UiUtil.Fuente(15f, FontStyle.Bold);
            lbl.Location = new Point(0, 0);
            lbl.Size = new Size(490, 66);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Padding = new Padding(20, 0, 0, 0);
            lbl.AutoEllipsis = true;

            Button btn = new Button();
            btn.Text = "\u2715";
            btn.Font = UiUtil.Fuente(14f, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(3, 50, 90);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(169, 46, 34);
            btn.Cursor = Cursors.Hand;
            btn.Location = new Point(490, 0);
            btn.Size = new Size(70, 66);
            btn.TabStop = false;
            btn.Click += delegate { Close(); };

            pan.Controls.Add(lbl);
            pan.Controls.Add(btn);

            _pic = new PictureBox();
            _pic.Location = new Point(14, 80);
            _pic.Size = new Size(532, 440);
            _pic.SizeMode = PictureBoxSizeMode.Zoom;
            _pic.BackColor = Color.White;
            _pic.BorderStyle = BorderStyle.FixedSingle;

            Image img = UiUtil.ImagenProducto(rutaRelativa);
            if (img != null) _pic.Image = img;
            else _pic.Image = UiUtil.SinImagen(64);

            _lblInfo = new Label();
            _lblInfo.Location = new Point(14, 528);
            _lblInfo.Size = new Size(532, 30);
            _lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            _lblInfo.Font = UiUtil.Fuente(9f, FontStyle.Regular);
            _lblInfo.ForeColor = Color.FromArgb(110, 128, 145);
            _lblInfo.Text = img != null
                ? rutaRelativa
                : "Este producto todavia no tiene imagen asignada.";

            Controls.Add(pan);
            Controls.Add(_pic);
            Controls.Add(_lblInfo);

            btn.DialogResult = DialogResult.Cancel;
            CancelButton = btn;

            KeyDown += delegate(object s, KeyEventArgs ev)
            {
                if (ev.KeyCode == Keys.Escape) Close();
            };
        }
    }
}
