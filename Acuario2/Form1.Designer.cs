namespace Acuario2
{
    partial class Form1
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
            this.panLateral = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panTopBar = new System.Windows.Forms.Panel();
            this.panUsuario = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panContenido = new System.Windows.Forms.Panel();
            this.panDashboard = new System.Windows.Forms.Panel();
            this.panValor = new Acuario2.PanelRedondeado();
            this.grafValor = new Acuario2.GraficaBarras();
            this.lblValorTitulo = new System.Windows.Forms.Label();
            this.panTop5 = new Acuario2.PanelRedondeado();
            this.grafTop5 = new Acuario2.GraficaBarras();
            this.lblTop5Titulo = new System.Windows.Forms.Label();
            this.panAlertas = new Acuario2.PanelRedondeado();
            this.flpAlertas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAlertasTitulo = new System.Windows.Forms.Label();
            this.panEspecie = new Acuario2.PanelRedondeado();
            this.grafEspecie = new Acuario2.GraficaBarras();
            this.lblEspecieTitulo = new System.Windows.Forms.Label();
            this.panKpi4 = new Acuario2.PanelRedondeado();
            this.picKpi4 = new System.Windows.Forms.PictureBox();
            this.lblKpi4Valor = new System.Windows.Forms.Label();
            this.lblKpi4Titulo = new System.Windows.Forms.Label();
            this.panBarra4 = new System.Windows.Forms.Panel();
            this.panKpi3 = new Acuario2.PanelRedondeado();
            this.picKpi3 = new System.Windows.Forms.PictureBox();
            this.lblKpi3Valor = new System.Windows.Forms.Label();
            this.lblKpi3Titulo = new System.Windows.Forms.Label();
            this.panBarra3 = new System.Windows.Forms.Panel();
            this.panKpi2 = new Acuario2.PanelRedondeado();
            this.picKpi2 = new System.Windows.Forms.PictureBox();
            this.lblKpi2Valor = new System.Windows.Forms.Label();
            this.lblKpi2Titulo = new System.Windows.Forms.Label();
            this.panBarra2 = new System.Windows.Forms.Panel();
            this.panKpi1 = new Acuario2.PanelRedondeado();
            this.picKpi1 = new System.Windows.Forms.PictureBox();
            this.lblKpi1Valor = new System.Windows.Forms.Label();
            this.lblKpi1Titulo = new System.Windows.Forms.Label();
            this.panBarra1 = new System.Windows.Forms.Panel();
            this.panInventario = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panFiltro = new Acuario2.PanelRedondeado();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.picFiltro = new System.Windows.Forms.PictureBox();
            this.panBuscador = new Acuario2.PanelRedondeado();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.picLupa = new System.Windows.Forms.PictureBox();
            this.panLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panTopBar.SuspendLayout();
            this.panUsuario.SuspendLayout();
            this.panContenido.SuspendLayout();
            this.panDashboard.SuspendLayout();
            this.panValor.SuspendLayout();
            this.panTop5.SuspendLayout();
            this.panAlertas.SuspendLayout();
            this.panEspecie.SuspendLayout();
            this.panKpi4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi4)).BeginInit();
            this.panKpi3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi3)).BeginInit();
            this.panKpi2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi2)).BeginInit();
            this.panKpi1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKpi1)).BeginInit();
            this.panInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panFiltro.SuspendLayout();
            this.panBuscador.SuspendLayout();
            this.SuspendLayout();
            // 
            // panLateral
            // 
            this.panLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panLateral.BackColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.panLateral.Controls.Add(this.btnSalir);
            this.panLateral.Controls.Add(this.btnConfig);
            this.panLateral.Controls.Add(this.btnReportes);
            this.panLateral.Controls.Add(this.btnInventario);
            this.panLateral.Controls.Add(this.btnInicio);
            this.panLateral.Controls.Add(this.picLogo);
            this.panLateral.Location = new System.Drawing.Point(0, 0);
            this.panLateral.Name = "panLateral";
            this.panLateral.Size = new System.Drawing.Size(260, 649);
            this.panLateral.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(2, 74, 108);
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(1, 96, 136);
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(3, 92, 131);
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(16, 579);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(228, 54);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.FromArgb(2, 74, 108);
            this.btnConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(1, 96, 136);
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(3, 92, 131);
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(16, 366);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(228, 54);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.TabStop = false;
            this.btnConfig.Text = "Configuración";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(2, 74, 108);
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(1, 96, 136);
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(3, 92, 131);
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(16, 300);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(228, 54);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.TabStop = false;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(2, 74, 108);
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(1, 96, 136);
            this.btnInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(3, 92, 131);
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(16, 234);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnInventario.Size = new System.Drawing.Size(228, 54);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.TabStop = false;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(1, 112, 137);
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(1, 96, 136);
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(2, 133, 161);
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Location = new System.Drawing.Point(16, 168);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnInicio.Size = new System.Drawing.Size(228, 54);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.TabStop = false;
            this.btnInicio.Text = "Dashboard";
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(18, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(224, 144);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // panTopBar
            // 
            this.panTopBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTopBar.BackColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.panTopBar.Controls.Add(this.panUsuario);
            this.panTopBar.Controls.Add(this.lblTitulo);
            this.panTopBar.Location = new System.Drawing.Point(260, 0);
            this.panTopBar.Name = "panTopBar";
            this.panTopBar.Size = new System.Drawing.Size(1020, 108);
            this.panTopBar.TabIndex = 1;
            // 
            // panUsuario
            // 
            this.panUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panUsuario.BackColor = System.Drawing.Color.FromArgb(54, 91, 123);
            this.panUsuario.Controls.Add(this.lblUsuario);
            this.panUsuario.Location = new System.Drawing.Point(850, 32);
            this.panUsuario.Name = "panUsuario";
            this.panUsuario.Size = new System.Drawing.Size(150, 42);
            this.panUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(0, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(150, 42);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "admin";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1020, 108);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DASHBOARD";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panContenido
            // 
            this.panContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panContenido.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.panContenido.Controls.Add(this.panDashboard);
            this.panContenido.Controls.Add(this.panInventario);
            this.panContenido.Location = new System.Drawing.Point(260, 108);
            this.panContenido.Name = "panContenido";
            this.panContenido.Size = new System.Drawing.Size(1020, 541);
            this.panContenido.TabIndex = 2;
            // 
            // panDashboard
            // 
            this.panDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDashboard.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.panDashboard.Controls.Add(this.panValor);
            this.panDashboard.Controls.Add(this.panTop5);
            this.panDashboard.Controls.Add(this.panAlertas);
            this.panDashboard.Controls.Add(this.panEspecie);
            this.panDashboard.Controls.Add(this.panKpi4);
            this.panDashboard.Controls.Add(this.panKpi3);
            this.panDashboard.Controls.Add(this.panKpi2);
            this.panDashboard.Controls.Add(this.panKpi1);
            this.panDashboard.Location = new System.Drawing.Point(0, 0);
            this.panDashboard.Name = "panDashboard";
            this.panDashboard.Size = new System.Drawing.Size(1020, 541);
            this.panDashboard.TabIndex = 0;
            // 
            // panValor
            // 
            this.panValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panValor.BackColor = System.Drawing.Color.White;
            this.panValor.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panValor.Controls.Add(this.grafValor);
            this.panValor.Controls.Add(this.lblValorTitulo);
            this.panValor.Location = new System.Drawing.Point(686, 342);
            this.panValor.Name = "panValor";
            this.panValor.Radio = 10;
            this.panValor.Size = new System.Drawing.Size(312, 177);
            this.panValor.TabIndex = 7;
            // 
            // grafValor
            // 
            this.grafValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafValor.BackColor = System.Drawing.Color.White;
            this.grafValor.ColorBarra = System.Drawing.Color.FromArgb(3, 50, 90);
            this.grafValor.ColorDestacado = System.Drawing.Color.FromArgb(4, 175, 182);
            this.grafValor.Formato = "\"$\"#,##0";
            this.grafValor.Horizontal = true;
            this.grafValor.Location = new System.Drawing.Point(14, 38);
            this.grafValor.Name = "grafValor";
            this.grafValor.Size = new System.Drawing.Size(284, 127);
            this.grafValor.TabIndex = 1;
            this.grafValor.TopeEtiquetas = 4;
            // 
            // lblValorTitulo
            // 
            this.lblValorTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblValorTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblValorTitulo.Location = new System.Drawing.Point(16, 10);
            this.lblValorTitulo.Name = "lblValorTitulo";
            this.lblValorTitulo.Size = new System.Drawing.Size(280, 24);
            this.lblValorTitulo.TabIndex = 0;
            this.lblValorTitulo.Text = "Valor por especie";
            this.lblValorTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panTop5
            // 
            this.panTop5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTop5.BackColor = System.Drawing.Color.White;
            this.panTop5.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panTop5.Controls.Add(this.grafTop5);
            this.panTop5.Controls.Add(this.lblTop5Titulo);
            this.panTop5.Location = new System.Drawing.Point(686, 150);
            this.panTop5.Name = "panTop5";
            this.panTop5.Radio = 10;
            this.panTop5.Size = new System.Drawing.Size(312, 176);
            this.panTop5.TabIndex = 6;
            // 
            // grafTop5
            // 
            this.grafTop5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafTop5.BackColor = System.Drawing.Color.White;
            this.grafTop5.ColorBarra = System.Drawing.Color.FromArgb(3, 50, 90);
            this.grafTop5.ColorDestacado = System.Drawing.Color.FromArgb(4, 175, 182);
            this.grafTop5.Formato = "\"$\"#,##0";
            this.grafTop5.Horizontal = true;
            this.grafTop5.Location = new System.Drawing.Point(14, 38);
            this.grafTop5.Name = "grafTop5";
            this.grafTop5.Size = new System.Drawing.Size(284, 126);
            this.grafTop5.TabIndex = 1;
            this.grafTop5.TopeEtiquetas = 5;
            // 
            // lblTop5Titulo
            // 
            this.lblTop5Titulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTop5Titulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblTop5Titulo.Location = new System.Drawing.Point(16, 10);
            this.lblTop5Titulo.Name = "lblTop5Titulo";
            this.lblTop5Titulo.Size = new System.Drawing.Size(280, 24);
            this.lblTop5Titulo.TabIndex = 0;
            this.lblTop5Titulo.Text = "Productos más caros";
            this.lblTop5Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panAlertas
            // 
            this.panAlertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panAlertas.BackColor = System.Drawing.Color.White;
            this.panAlertas.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panAlertas.Controls.Add(this.flpAlertas);
            this.panAlertas.Controls.Add(this.lblAlertasTitulo);
            this.panAlertas.Location = new System.Drawing.Point(354, 150);
            this.panAlertas.Name = "panAlertas";
            this.panAlertas.Radio = 10;
            this.panAlertas.Size = new System.Drawing.Size(316, 369);
            this.panAlertas.TabIndex = 5;
            // 
            // flpAlertas
            // 
            this.flpAlertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAlertas.AutoScroll = true;
            this.flpAlertas.BackColor = System.Drawing.Color.White;
            this.flpAlertas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAlertas.Location = new System.Drawing.Point(14, 44);
            this.flpAlertas.Name = "flpAlertas";
            this.flpAlertas.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.flpAlertas.Size = new System.Drawing.Size(288, 310);
            this.flpAlertas.TabIndex = 1;
            this.flpAlertas.WrapContents = false;
            // 
            // lblAlertasTitulo
            // 
            this.lblAlertasTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlertasTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblAlertasTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblAlertasTitulo.Name = "lblAlertasTitulo";
            this.lblAlertasTitulo.Size = new System.Drawing.Size(284, 26);
            this.lblAlertasTitulo.TabIndex = 0;
            this.lblAlertasTitulo.Text = "Alertas de inventario";
            this.lblAlertasTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panEspecie
            // 
            this.panEspecie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panEspecie.BackColor = System.Drawing.Color.White;
            this.panEspecie.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panEspecie.Controls.Add(this.grafEspecie);
            this.panEspecie.Controls.Add(this.lblEspecieTitulo);
            this.panEspecie.Location = new System.Drawing.Point(22, 150);
            this.panEspecie.Name = "panEspecie";
            this.panEspecie.Radio = 10;
            this.panEspecie.Size = new System.Drawing.Size(316, 369);
            this.panEspecie.TabIndex = 4;
            // 
            // grafEspecie
            // 
            this.grafEspecie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafEspecie.BackColor = System.Drawing.Color.White;
            this.grafEspecie.ColorBarra = System.Drawing.Color.FromArgb(3, 50, 90);
            this.grafEspecie.ColorDestacado = System.Drawing.Color.FromArgb(4, 175, 182);
            this.grafEspecie.Formato = "N0";
            this.grafEspecie.Horizontal = false;
            this.grafEspecie.Location = new System.Drawing.Point(14, 44);
            this.grafEspecie.Name = "grafEspecie";
            this.grafEspecie.Size = new System.Drawing.Size(288, 310);
            this.grafEspecie.TabIndex = 1;
            this.grafEspecie.TopeEtiquetas = 8;
            // 
            // lblEspecieTitulo
            // 
            this.lblEspecieTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEspecieTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblEspecieTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblEspecieTitulo.Name = "lblEspecieTitulo";
            this.lblEspecieTitulo.Size = new System.Drawing.Size(284, 26);
            this.lblEspecieTitulo.TabIndex = 0;
            this.lblEspecieTitulo.Text = "Productos por especie";
            this.lblEspecieTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panKpi4
            // 
            this.panKpi4.BackColor = System.Drawing.Color.White;
            this.panKpi4.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panKpi4.Controls.Add(this.picKpi4);
            this.panKpi4.Controls.Add(this.lblKpi4Valor);
            this.panKpi4.Controls.Add(this.lblKpi4Titulo);
            this.panKpi4.Controls.Add(this.panBarra4);
            this.panKpi4.Location = new System.Drawing.Point(766, 22);
            this.panKpi4.Name = "panKpi4";
            this.panKpi4.Radio = 10;
            this.panKpi4.Size = new System.Drawing.Size(232, 112);
            this.panKpi4.TabIndex = 3;
            // 
            // picKpi4
            // 
            this.picKpi4.BackColor = System.Drawing.Color.FromArgb(224, 244, 251);
            this.picKpi4.Location = new System.Drawing.Point(170, 24);
            this.picKpi4.Name = "picKpi4";
            this.picKpi4.Size = new System.Drawing.Size(46, 46);
            this.picKpi4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi4.TabIndex = 3;
            this.picKpi4.TabStop = false;
            // 
            // lblKpi4Valor
            // 
            this.lblKpi4Valor.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblKpi4Valor.ForeColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.lblKpi4Valor.Location = new System.Drawing.Point(14, 56);
            this.lblKpi4Valor.Name = "lblKpi4Valor";
            this.lblKpi4Valor.Size = new System.Drawing.Size(150, 46);
            this.lblKpi4Valor.TabIndex = 2;
            this.lblKpi4Valor.Text = "0";
            this.lblKpi4Valor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpi4Titulo
            // 
            this.lblKpi4Titulo.AutoEllipsis = true;
            this.lblKpi4Titulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKpi4Titulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblKpi4Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi4Titulo.Name = "lblKpi4Titulo";
            this.lblKpi4Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi4Titulo.TabIndex = 1;
            this.lblKpi4Titulo.Text = "Bajo inventario:";
            this.lblKpi4Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra4
            // 
            this.panBarra4.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.panBarra4.Location = new System.Drawing.Point(1, 1);
            this.panBarra4.Name = "panBarra4";
            this.panBarra4.Size = new System.Drawing.Size(230, 6);
            this.panBarra4.TabIndex = 0;
            // 
            // panKpi3
            // 
            this.panKpi3.BackColor = System.Drawing.Color.White;
            this.panKpi3.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panKpi3.Controls.Add(this.picKpi3);
            this.panKpi3.Controls.Add(this.lblKpi3Valor);
            this.panKpi3.Controls.Add(this.lblKpi3Titulo);
            this.panKpi3.Controls.Add(this.panBarra3);
            this.panKpi3.Location = new System.Drawing.Point(518, 22);
            this.panKpi3.Name = "panKpi3";
            this.panKpi3.Radio = 10;
            this.panKpi3.Size = new System.Drawing.Size(232, 112);
            this.panKpi3.TabIndex = 2;
            // 
            // picKpi3
            // 
            this.picKpi3.BackColor = System.Drawing.Color.FromArgb(224, 244, 251);
            this.picKpi3.Location = new System.Drawing.Point(170, 24);
            this.picKpi3.Name = "picKpi3";
            this.picKpi3.Size = new System.Drawing.Size(46, 46);
            this.picKpi3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi3.TabIndex = 3;
            this.picKpi3.TabStop = false;
            // 
            // lblKpi3Valor
            // 
            this.lblKpi3Valor.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Valor.ForeColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.lblKpi3Valor.Location = new System.Drawing.Point(14, 56);
            this.lblKpi3Valor.Name = "lblKpi3Valor";
            this.lblKpi3Valor.Size = new System.Drawing.Size(150, 46);
            this.lblKpi3Valor.TabIndex = 2;
            this.lblKpi3Valor.Text = "$0";
            this.lblKpi3Valor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpi3Titulo
            // 
            this.lblKpi3Titulo.AutoEllipsis = true;
            this.lblKpi3Titulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKpi3Titulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblKpi3Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi3Titulo.Name = "lblKpi3Titulo";
            this.lblKpi3Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi3Titulo.TabIndex = 1;
            this.lblKpi3Titulo.Text = "Valor del inventario:";
            this.lblKpi3Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra3
            // 
            this.panBarra3.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.panBarra3.Location = new System.Drawing.Point(1, 1);
            this.panBarra3.Name = "panBarra3";
            this.panBarra3.Size = new System.Drawing.Size(230, 6);
            this.panBarra3.TabIndex = 0;
            // 
            // panKpi2
            // 
            this.panKpi2.BackColor = System.Drawing.Color.White;
            this.panKpi2.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panKpi2.Controls.Add(this.picKpi2);
            this.panKpi2.Controls.Add(this.lblKpi2Valor);
            this.panKpi2.Controls.Add(this.lblKpi2Titulo);
            this.panKpi2.Controls.Add(this.panBarra2);
            this.panKpi2.Location = new System.Drawing.Point(270, 22);
            this.panKpi2.Name = "panKpi2";
            this.panKpi2.Radio = 10;
            this.panKpi2.Size = new System.Drawing.Size(232, 112);
            this.panKpi2.TabIndex = 1;
            // 
            // picKpi2
            // 
            this.picKpi2.BackColor = System.Drawing.Color.FromArgb(224, 244, 251);
            this.picKpi2.Location = new System.Drawing.Point(170, 24);
            this.picKpi2.Name = "picKpi2";
            this.picKpi2.Size = new System.Drawing.Size(46, 46);
            this.picKpi2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi2.TabIndex = 3;
            this.picKpi2.TabStop = false;
            // 
            // lblKpi2Valor
            // 
            this.lblKpi2Valor.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Valor.ForeColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.lblKpi2Valor.Location = new System.Drawing.Point(14, 56);
            this.lblKpi2Valor.Name = "lblKpi2Valor";
            this.lblKpi2Valor.Size = new System.Drawing.Size(150, 46);
            this.lblKpi2Valor.TabIndex = 2;
            this.lblKpi2Valor.Text = "0";
            this.lblKpi2Valor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpi2Titulo
            // 
            this.lblKpi2Titulo.AutoEllipsis = true;
            this.lblKpi2Titulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKpi2Titulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblKpi2Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi2Titulo.Name = "lblKpi2Titulo";
            this.lblKpi2Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi2Titulo.TabIndex = 1;
            this.lblKpi2Titulo.Text = "Unidades disponibles:";
            this.lblKpi2Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra2
            // 
            this.panBarra2.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.panBarra2.Location = new System.Drawing.Point(1, 1);
            this.panBarra2.Name = "panBarra2";
            this.panBarra2.Size = new System.Drawing.Size(230, 6);
            this.panBarra2.TabIndex = 0;
            // 
            // panKpi1
            // 
            this.panKpi1.BackColor = System.Drawing.Color.White;
            this.panKpi1.ColorBorde = System.Drawing.Color.FromArgb(220, 230, 236);
            this.panKpi1.Controls.Add(this.picKpi1);
            this.panKpi1.Controls.Add(this.lblKpi1Valor);
            this.panKpi1.Controls.Add(this.lblKpi1Titulo);
            this.panKpi1.Controls.Add(this.panBarra1);
            this.panKpi1.Location = new System.Drawing.Point(22, 22);
            this.panKpi1.Name = "panKpi1";
            this.panKpi1.Radio = 10;
            this.panKpi1.Size = new System.Drawing.Size(232, 112);
            this.panKpi1.TabIndex = 0;
            // 
            // picKpi1
            // 
            this.picKpi1.BackColor = System.Drawing.Color.FromArgb(224, 244, 251);
            this.picKpi1.Location = new System.Drawing.Point(170, 24);
            this.picKpi1.Name = "picKpi1";
            this.picKpi1.Size = new System.Drawing.Size(46, 46);
            this.picKpi1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picKpi1.TabIndex = 3;
            this.picKpi1.TabStop = false;
            // 
            // lblKpi1Valor
            // 
            this.lblKpi1Valor.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Valor.ForeColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.lblKpi1Valor.Location = new System.Drawing.Point(14, 56);
            this.lblKpi1Valor.Name = "lblKpi1Valor";
            this.lblKpi1Valor.Size = new System.Drawing.Size(150, 46);
            this.lblKpi1Valor.TabIndex = 2;
            this.lblKpi1Valor.Text = "0";
            this.lblKpi1Valor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpi1Titulo
            // 
            this.lblKpi1Titulo.AutoEllipsis = true;
            this.lblKpi1Titulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblKpi1Titulo.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.lblKpi1Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi1Titulo.Name = "lblKpi1Titulo";
            this.lblKpi1Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi1Titulo.TabIndex = 1;
            this.lblKpi1Titulo.Text = "Productos registrados:";
            this.lblKpi1Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra1
            // 
            this.panBarra1.BackColor = System.Drawing.Color.FromArgb(8, 145, 178);
            this.panBarra1.Location = new System.Drawing.Point(1, 1);
            this.panBarra1.Name = "panBarra1";
            this.panBarra1.Size = new System.Drawing.Size(230, 6);
            this.panBarra1.TabIndex = 0;
            // 
            // panInventario
            // 
            this.panInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panInventario.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.panInventario.Controls.Add(this.dgvProductos);
            this.panInventario.Controls.Add(this.lblAviso);
            this.panInventario.Controls.Add(this.btnActualizar);
            this.panInventario.Controls.Add(this.btnAgregar);
            this.panInventario.Controls.Add(this.panFiltro);
            this.panInventario.Controls.Add(this.panBuscador);
            this.panInventario.Location = new System.Drawing.Point(0, 0);
            this.panInventario.Name = "panInventario";
            this.panInventario.Size = new System.Drawing.Size(1020, 541);
            this.panInventario.TabIndex = 1;
            this.panInventario.Visible = false;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToOrderColumns = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 244, 247);
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 46, 81);
            this.dgvProductos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProductos.ColumnHeadersHeight = 48;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colEspecie,
            this.colCantidad,
            this.colPrecio,
            this.colVer,
            this.colEstado,
            this.colEditar,
            this.colEliminar});
            this.dgvProductos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvProductos.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvProductos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.dgvProductos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(217, 238, 243);
            this.dgvProductos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(3, 50, 90);
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(233, 239, 244);
            this.dgvProductos.Location = new System.Drawing.Point(22, 142);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 44;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProductos.Size = new System.Drawing.Size(976, 377);
            this.dgvProductos.TabIndex = 5;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductos.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductos_CellMouseMove);
            this.dgvProductos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProductos_CellPainting);
            this.dgvProductos.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellLeave);
            this.dgvProductos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductos_CellFormatting);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 200;
            // 
            // colEspecie
            // 
            this.colEspecie.HeaderText = "Especie";
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.ReadOnly = true;
            this.colEspecie.Width = 120;
            // 
            // colCantidad
            // 
            this.colCantidad.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 85;
            // 
            // colPrecio
            // 
            this.colPrecio.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 100;
            // 
            // colVer
            // 
            this.colVer.HeaderText = "Ver";
            this.colVer.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Width = 72;
            // 
            // colEstado
            // 
            this.colEstado.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 120;
            // 
            // colEditar
            // 
            this.colEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Width = 92;
            // 
            // colEliminar
            // 
            this.colEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.ReadOnly = true;
            this.colEliminar.Width = 98;
            // 
            // lblAviso
            // 
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(95, 115, 135);
            this.lblAviso.Location = new System.Drawing.Point(250, 78);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(520, 48);
            this.lblAviso.TabIndex = 4;
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(2, 43, 79);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(1, 32, 59);
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(4, 62, 111);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(788, 78);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnActualizar.Size = new System.Drawing.Size(210, 48);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.TabStop = false;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(4, 175, 182);
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(3, 143, 149);
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(6, 199, 207);
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(22, 78);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnAgregar.Size = new System.Drawing.Size(210, 48);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panFiltro
            // 
            this.panFiltro.BackColor = System.Drawing.Color.White;
            this.panFiltro.ColorBorde = System.Drawing.Color.White;
            this.panFiltro.Controls.Add(this.cboFiltro);
            this.panFiltro.Controls.Add(this.picFiltro);
            this.panFiltro.Location = new System.Drawing.Point(468, 20);
            this.panFiltro.Name = "panFiltro";
            this.panFiltro.Radio = 14;
            this.panFiltro.Size = new System.Drawing.Size(300, 44);
            this.panFiltro.TabIndex = 1;
            // 
            // cboFiltro
            // 
            this.cboFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFiltro.BackColor = System.Drawing.Color.White;
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFiltro.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboFiltro.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Todas las especies",
            "Tropical",
            "Agresivo",
            "Fr\u00EDo"});
            this.cboFiltro.Location = new System.Drawing.Point(44, 7);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(246, 28);
            this.cboFiltro.TabIndex = 1;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // picFiltro
            // 
            this.picFiltro.BackColor = System.Drawing.Color.Transparent;
            this.picFiltro.Location = new System.Drawing.Point(16, 12);
            this.picFiltro.Name = "picFiltro";
            this.picFiltro.Size = new System.Drawing.Size(20, 20);
            this.picFiltro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFiltro.TabIndex = 0;
            this.picFiltro.TabStop = false;
            // 
            // panBuscador
            // 
            this.panBuscador.BackColor = System.Drawing.Color.White;
            this.panBuscador.ColorBorde = System.Drawing.Color.White;
            this.panBuscador.Controls.Add(this.txtBuscar);
            this.panBuscador.Controls.Add(this.picLupa);
            this.panBuscador.Location = new System.Drawing.Point(22, 20);
            this.panBuscador.Name = "panBuscador";
            this.panBuscador.Radio = 14;
            this.panBuscador.Size = new System.Drawing.Size(430, 44);
            this.panBuscador.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(20, 64, 95);
            this.txtBuscar.Location = new System.Drawing.Point(44, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(374, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // picLupa
            // 
            this.picLupa.BackColor = System.Drawing.Color.Transparent;
            this.picLupa.Location = new System.Drawing.Point(16, 12);
            this.picLupa.Name = "picLupa";
            this.picLupa.Size = new System.Drawing.Size(20, 20);
            this.picLupa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLupa.TabIndex = 0;
            this.picLupa.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.ClientSize = new System.Drawing.Size(1280, 649);
            this.Controls.Add(this.panContenido);
            this.Controls.Add(this.panTopBar);
            this.Controls.Add(this.panLateral);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AquaControl - Sistema de gestión para acuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panTopBar.ResumeLayout(false);
            this.panUsuario.ResumeLayout(false);
            this.panContenido.ResumeLayout(false);
            this.panDashboard.ResumeLayout(false);
            this.panValor.ResumeLayout(false);
            this.panTop5.ResumeLayout(false);
            this.panAlertas.ResumeLayout(false);
            this.panEspecie.ResumeLayout(false);
            this.panKpi4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picKpi4)).EndInit();
            this.panKpi3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picKpi3)).EndInit();
            this.panKpi2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picKpi2)).EndInit();
            this.panKpi1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picKpi1)).EndInit();
            this.panInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panFiltro.ResumeLayout(false);
            this.panFiltro.PerformLayout();
            this.panBuscador.ResumeLayout(false);
            this.panBuscador.PerformLayout();
            this.panUsuario.PerformLayout();
            this.panTopBar.PerformLayout();
            this.panLateral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panLateral;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panTopBar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panContenido;
        private System.Windows.Forms.Panel panDashboard;
        private System.Windows.Forms.Panel panInventario;
        private Acuario2.PanelRedondeado panKpi1;
        private System.Windows.Forms.Panel panBarra1;
        private System.Windows.Forms.Label lblKpi1Titulo;
        private System.Windows.Forms.Label lblKpi1Valor;
        private System.Windows.Forms.PictureBox picKpi1;
        private Acuario2.PanelRedondeado panKpi2;
        private System.Windows.Forms.Panel panBarra2;
        private System.Windows.Forms.Label lblKpi2Titulo;
        private System.Windows.Forms.Label lblKpi2Valor;
        private System.Windows.Forms.PictureBox picKpi2;
        private Acuario2.PanelRedondeado panKpi3;
        private System.Windows.Forms.Panel panBarra3;
        private System.Windows.Forms.Label lblKpi3Titulo;
        private System.Windows.Forms.Label lblKpi3Valor;
        private System.Windows.Forms.PictureBox picKpi3;
        private Acuario2.PanelRedondeado panKpi4;
        private System.Windows.Forms.Panel panBarra4;
        private System.Windows.Forms.Label lblKpi4Titulo;
        private System.Windows.Forms.Label lblKpi4Valor;
        private System.Windows.Forms.PictureBox picKpi4;
        private Acuario2.PanelRedondeado panEspecie;
        private System.Windows.Forms.Label lblEspecieTitulo;
        private Acuario2.GraficaBarras grafEspecie;
        private Acuario2.PanelRedondeado panAlertas;
        private System.Windows.Forms.Label lblAlertasTitulo;
        private System.Windows.Forms.FlowLayoutPanel flpAlertas;
        private Acuario2.PanelRedondeado panTop5;
        private System.Windows.Forms.Label lblTop5Titulo;
        private Acuario2.GraficaBarras grafTop5;
        private Acuario2.PanelRedondeado panValor;
        private System.Windows.Forms.Label lblValorTitulo;
        private Acuario2.GraficaBarras grafValor;
        private Acuario2.PanelRedondeado panBuscador;
        private System.Windows.Forms.PictureBox picLupa;
        private System.Windows.Forms.TextBox txtBuscar;
        private Acuario2.PanelRedondeado panFiltro;
        private System.Windows.Forms.PictureBox picFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewImageColumn colVer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colEliminar;
    }
}
