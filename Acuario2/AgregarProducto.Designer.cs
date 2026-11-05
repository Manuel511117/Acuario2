namespace Acuario2
{
    partial class AgregarProducto
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si se deben administrar los recursos administrados; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panEncabezado = new System.Windows.Forms.Panel();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblEspecie = new System.Windows.Forms.Label();
            this.cboEspecie = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.lblImagen = new System.Windows.Forms.Label();
            this.btnImagen = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // panEncabezado
            // 
            this.panEncabezado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panEncabezado.BackColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.panEncabezado.Controls.Add(this.lblEncabezado);
            this.panEncabezado.Controls.Add(this.btnCerrar);
            this.panEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panEncabezado.Name = "panEncabezado";
            this.panEncabezado.Size = new System.Drawing.Size(624, 72);
            this.panEncabezado.TabIndex = 0;
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.White;
            this.lblEncabezado.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEncabezado.Location = new System.Drawing.Point(0, 0);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.lblEncabezado.Size = new System.Drawing.Size(544, 72);
            this.lblEncabezado.TabIndex = 0;
            this.lblEncabezado.Text = "Agregar Producto";
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right) 
            | System.Windows.Forms.AnchorStyles.None)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(169, 46, 34);
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Location = new System.Drawing.Point(544, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 72);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Text = "\u2715";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = false;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblNombre.Location = new System.Drawing.Point(24, 94);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(272, 22);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre del producto";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombre.Location = new System.Drawing.Point(24, 118);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(272, 32);
            this.txtNombre.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = false;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblCantidad.Location = new System.Drawing.Point(328, 94);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(272, 22);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad en stock";
            this.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numCantidad
            // 
            this.numCantidad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numCantidad.Location = new System.Drawing.Point(328, 118);
            this.numCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(272, 32);
            this.numCantidad.TabIndex = 5;
            // 
            // lblEspecie
            // 
            this.lblEspecie.AutoSize = false;
            this.lblEspecie.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEspecie.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblEspecie.Location = new System.Drawing.Point(24, 162);
            this.lblEspecie.Name = "lblEspecie";
            this.lblEspecie.Size = new System.Drawing.Size(272, 22);
            this.lblEspecie.TabIndex = 6;
            this.lblEspecie.Text = "Especie";
            this.lblEspecie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboEspecie
            // 
            this.cboEspecie.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEspecie.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEspecie.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboEspecie.FormattingEnabled = true;
            this.cboEspecie.Items.AddRange(new object[] {
            "Tropical",
            "Agresivo",
            "Fr\u00EDo"});
            this.cboEspecie.Location = new System.Drawing.Point(24, 186);
            this.cboEspecie.Name = "cboEspecie";
            this.cboEspecie.Size = new System.Drawing.Size(272, 33);
            this.cboEspecie.TabIndex = 7;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = false;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblPrecio.Location = new System.Drawing.Point(328, 162);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(272, 22);
            this.lblPrecio.TabIndex = 8;
            this.lblPrecio.Text = "Precio unitario ($)";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numPrecio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrecio.Location = new System.Drawing.Point(328, 186);
            this.numPrecio.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(272, 32);
            this.numPrecio.TabIndex = 9;
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = false;
            this.lblImagen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblImagen.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblImagen.Location = new System.Drawing.Point(24, 238);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(576, 22);
            this.lblImagen.TabIndex = 10;
            this.lblImagen.Text = "Imagen del producto";
            this.lblImagen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnImagen
            // 
            this.btnImagen.BackColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.btnImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImagen.FlatAppearance.BorderSize = 0;
            this.btnImagen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(2, 39, 70);
            this.btnImagen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(5, 66, 118);
            this.btnImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnImagen.ForeColor = System.Drawing.Color.White;
            this.btnImagen.Location = new System.Drawing.Point(24, 264);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(184, 34);
            this.btnImagen.TabIndex = 11;
            this.btnImagen.Text = "Seleccionar imagen...";
            this.btnImagen.UseVisualStyleBackColor = false;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.FromArgb(238, 242, 245);
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRuta.ForeColor = System.Drawing.Color.FromArgb(95, 115, 135);
            this.txtRuta.Location = new System.Drawing.Point(220, 264);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(380, 30);
            this.txtRuta.TabIndex = 12;
            this.txtRuta.TabStop = false;
            // 
            // picImagen
            // 
            this.picImagen.BackColor = System.Drawing.Color.White;
            this.picImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImagen.Location = new System.Drawing.Point(24, 312);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(170, 130);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagen.TabIndex = 13;
            this.picImagen.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(110, 128, 145);
            this.lblInfo.Location = new System.Drawing.Point(214, 312);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(386, 130);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblError.Location = new System.Drawing.Point(24, 454);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(576, 26);
            this.lblError.TabIndex = 15;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(4, 175, 182);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(3, 143, 149);
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(6, 199, 207);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(316, 494);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(144, 42);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(216, 227, 235);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(196, 210, 221);
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(232, 240, 245);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.btnCancelar.Location = new System.Drawing.Point(472, 494);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 42);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // AgregarProducto
            // 
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(624, 556);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.picImagen);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnImagen);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.cboEspecie);
            this.Controls.Add(this.lblEspecie);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.panEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarProducto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar Producto";
            this.Load += new System.EventHandler(this.AgregarProducto_Load);
            this.panEncabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panEncabezado;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblEspecie;
        private System.Windows.Forms.ComboBox cboEspecie;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.PictureBox picImagen;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
