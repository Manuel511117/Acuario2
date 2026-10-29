namespace Acuario2
{
    partial class IniciarSesion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarSesion));
            this.axPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.velo = new Acuario2.VeloAlpha(System.Drawing.Color.FromArgb(160, 3, 8, 16));
            this.tarjeta = new Acuario2.PanelRedondeado();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblVolver = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).BeginInit();
            this.tarjeta.SuspendLayout();
            this.SuspendLayout();
            //
            // axPlayer
            //
            this.axPlayer.Enabled = true;
            this.axPlayer.Location = new System.Drawing.Point(0, 0);
            this.axPlayer.Name = "axPlayer";
            this.axPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer.OcxState")));
            this.axPlayer.Size = new System.Drawing.Size(1280, 720);
            this.axPlayer.TabIndex = 0;
            //
            // velo
            //
            this.velo.Location = new System.Drawing.Point(0, 0);
            this.velo.Name = "velo";
            this.velo.Size = new System.Drawing.Size(1280, 720);
            this.velo.TabIndex = 1;
            //
            // tarjeta
            //
            this.tarjeta.BackColor = System.Drawing.Color.FromArgb(14, 34, 51);
            this.tarjeta.ColorBorde = System.Drawing.Color.FromArgb(255, 46, 196, 182);
            this.tarjeta.Controls.Add(this.lblTitulo);
            this.tarjeta.Controls.Add(this.lblUsuario);
            this.tarjeta.Controls.Add(this.txtUsuario);
            this.tarjeta.Controls.Add(this.lblClave);
            this.tarjeta.Controls.Add(this.txtClave);
            this.tarjeta.Controls.Add(this.btnEntrar);
            this.tarjeta.Controls.Add(this.lblVolver);
            this.tarjeta.Controls.Add(this.lblError);
            this.tarjeta.Location = new System.Drawing.Point(430, 160);
            this.tarjeta.Name = "tarjeta";
            this.tarjeta.Radio = 16;
            this.tarjeta.Size = new System.Drawing.Size(420, 400);
            this.tarjeta.TabIndex = 2;
            //
            // lblTitulo
            //
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(40, 28);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(340, 44);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Iniciar sesión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUsuario
            //
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(159, 216, 212);
            this.lblUsuario.Location = new System.Drawing.Point(40, 92);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(340, 22);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(10, 22, 34);
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.ForeColor = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(40, 116);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(340, 32);
            this.txtUsuario.TabIndex = 2;
            //
            // lblClave
            //
            this.lblClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(159, 216, 212);
            this.lblClave.Location = new System.Drawing.Point(40, 164);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(340, 22);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Contraseña";
            //
            // txtClave
            //
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(10, 22, 34);
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtClave.ForeColor = System.Drawing.Color.White;
            this.txtClave.Location = new System.Drawing.Point(40, 188);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '•';
            this.txtClave.Size = new System.Drawing.Size(340, 32);
            this.txtClave.TabIndex = 4;
            //
            // btnEntrar
            //
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(46, 196, 182);
            this.btnEntrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(36, 160, 148);
            this.btnEntrar.FlatAppearance.BorderSize = 0;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEntrar.ForeColor = System.Drawing.Color.FromArgb(5, 20, 28);
            this.btnEntrar.Location = new System.Drawing.Point(40, 248);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(340, 46);
            this.btnEntrar.TabIndex = 5;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            //
            // lblVolver
            //
            this.lblVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVolver.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblVolver.ForeColor = System.Drawing.Color.FromArgb(127, 213, 207);
            this.lblVolver.Location = new System.Drawing.Point(40, 312);
            this.lblVolver.Name = "lblVolver";
            this.lblVolver.Size = new System.Drawing.Size(340, 28);
            this.lblVolver.TabIndex = 6;
            this.lblVolver.Text = "←  Volver a bienvenida";
            this.lblVolver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVolver.Click += new System.EventHandler(this.lblVolver_Click);
            //
            // lblError
            //
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(255, 107, 107);
            this.lblError.Location = new System.Drawing.Point(40, 352);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(340, 28);
            this.lblError.TabIndex = 7;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            //
            // IniciarSesion
            //
            this.AcceptButton = this.btnEntrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(11, 30, 45);
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tarjeta);
            this.Controls.Add(this.velo);
            this.Controls.Add(this.axPlayer);
            this.ForeColor = System.Drawing.Color.White;
            this.KeyPreview = true;
            this.Name = "IniciarSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IniciarSesion_Load);
            this.Resize += new System.EventHandler(this.IniciarSesion_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IniciarSesion_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).EndInit();
            this.tarjeta.ResumeLayout(false);
            this.tarjeta.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axPlayer;
        private Acuario2.VeloAlpha velo;
        private Acuario2.PanelRedondeado tarjeta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblVolver;
        private System.Windows.Forms.Label lblError;
    }
}
