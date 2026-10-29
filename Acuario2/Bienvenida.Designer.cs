namespace Acuario2
{
    partial class Bienvenida
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bienvenida));
            this.axPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.velo = new Acuario2.VeloAlpha(System.Drawing.Color.FromArgb(55, 3, 8, 16));
            this.etqTitulo = new Acuario2.EtiquetaAlpha();
            this.etqSubtitulo = new Acuario2.EtiquetaAlpha();
            this.btnIniciar = new Acuario2.BotonAlpha();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // axPlayer
            // 
            this.axPlayer.Enabled = true;
            this.axPlayer.Location = new System.Drawing.Point(0, 0);
            this.axPlayer.Name = "axPlayer";
            this.axPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer.OcxState")));
            this.axPlayer.Size = new System.Drawing.Size(1380, 720);
            this.axPlayer.TabIndex = 0;
            // 
            // velo
            // 
            this.velo.Location = new System.Drawing.Point(0, 0);
            this.velo.Name = "velo";
            this.velo.Size = new System.Drawing.Size(1280, 720);
            this.velo.TabIndex = 1;
            this.velo.TabStop = false;
            // 
            // etqTitulo
            // 
            this.etqTitulo.Alineacion = System.Drawing.ContentAlignment.MiddleCenter;
            this.etqTitulo.ColorTexto = System.Drawing.Color.White;
            this.etqTitulo.Fuente = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Bold);
            this.etqTitulo.Location = new System.Drawing.Point(0, 170);
            this.etqTitulo.Name = "etqTitulo";
            this.etqTitulo.Size = new System.Drawing.Size(1280, 70);
            this.etqTitulo.TabIndex = 2;
            this.etqTitulo.TabStop = false;
            this.etqTitulo.Texto = "Bienvenido a Acuario";
            // 
            // etqSubtitulo
            // 
            this.etqSubtitulo.Alineacion = System.Drawing.ContentAlignment.MiddleCenter;
            this.etqSubtitulo.ColorTexto = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(216)))), ((int)(((byte)(212)))));
            this.etqSubtitulo.Fuente = new System.Drawing.Font("Segoe UI", 14F);
            this.etqSubtitulo.Location = new System.Drawing.Point(0, 242);
            this.etqSubtitulo.Name = "etqSubtitulo";
            this.etqSubtitulo.Size = new System.Drawing.Size(1280, 36);
            this.etqSubtitulo.TabIndex = 3;
            this.etqSubtitulo.TabStop = false;
            this.etqSubtitulo.Texto = "Sistema de gestión del acuario";
            // 
            // btnIniciar
            // 
            this.btnIniciar.ColorBorde = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(196)))), ((int)(((byte)(182)))));
            this.btnIniciar.ColorTexto = System.Drawing.Color.White;
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.Fuente = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.Location = new System.Drawing.Point(490, 380);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Radio = 14;
            this.btnIniciar.RellenoHover = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(46)))), ((int)(((byte)(196)))), ((int)(((byte)(182)))));
            this.btnIniciar.Size = new System.Drawing.Size(300, 56);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.TabStop = false;
            this.btnIniciar.Texto = "Iniciar sesión";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // Bienvenida
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1280, 701);
            this.Controls.Add(this.etqTitulo);
            this.Controls.Add(this.etqSubtitulo);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.velo);
            this.Controls.Add(this.axPlayer);
            this.ForeColor = System.Drawing.Color.White;
            this.KeyPreview = true;
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Bienvenida_Load);
            this.Resize += new System.EventHandler(this.Bienvenida_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axPlayer;
        private Acuario2.VeloAlpha velo;
        private Acuario2.EtiquetaAlpha etqTitulo;
        private Acuario2.EtiquetaAlpha etqSubtitulo;
        private Acuario2.BotonAlpha btnIniciar;
    }
}
