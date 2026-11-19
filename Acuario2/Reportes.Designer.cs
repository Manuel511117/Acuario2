using System;
using System.Drawing;
using System.Windows.Forms;

namespace Acuario2
{
    partial class Reportes
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

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panVentas = new System.Windows.Forms.Panel();
            this.lblAviso = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.colEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVer = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoriaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panReportes = new System.Windows.Forms.Panel();
            this.panConfig = new System.Windows.Forms.Panel();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panDashboard = new System.Windows.Forms.Panel();
            this.panContenido = new System.Windows.Forms.Panel();
            this.panInventario = new System.Windows.Forms.Panel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panUsuario = new System.Windows.Forms.Panel();
            this.panTopBar = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panLateral = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panFiltro = new Acuario2.PanelRedondeado();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.picFiltro = new System.Windows.Forms.PictureBox();
            this.panBuscador = new Acuario2.PanelRedondeado();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.picLupa = new System.Windows.Forms.PictureBox();
            this.panFiltroVentas = new Acuario2.PanelRedondeado();
            this.lblCategoriaVenta = new System.Windows.Forms.Label();
            this.cboCategoriaVenta = new System.Windows.Forms.ComboBox();
            this.lblAvisoVentas = new System.Windows.Forms.Label();
            this.btnActualizarVentas = new System.Windows.Forms.Button();
            this.panCatalogo = new Acuario2.PanelRedondeado();
            this.flpCatalogo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCatalogoVacio = new System.Windows.Forms.Label();
            this.lblCatalogoTitulo = new System.Windows.Forms.Label();
            this.panCarrito = new Acuario2.PanelRedondeado();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.btnVaciarCarrito = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.lblCarritoVacio = new System.Windows.Forms.Label();
            this.flpCarrito = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCarritoTitulo = new System.Windows.Forms.Label();
            this.panVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panReportes.SuspendLayout();
            this.panDashboard.SuspendLayout();
            this.panContenido.SuspendLayout();
            this.panInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.panUsuario.SuspendLayout();
            this.panTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panLateral.SuspendLayout();
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
            this.panFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFiltro)).BeginInit();
            this.panBuscador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLupa)).BeginInit();
            this.panFiltroVentas.SuspendLayout();
            this.panCatalogo.SuspendLayout();
            this.panCarrito.SuspendLayout();
            this.SuspendLayout();
            // 
            // panVentas
            // 
            this.panVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panVentas.Controls.Add(this.panFiltroVentas);
            this.panVentas.Controls.Add(this.panCatalogo);
            this.panVentas.Controls.Add(this.panCarrito);
            this.panVentas.Location = new System.Drawing.Point(0, 0);
            this.panVentas.Name = "panVentas";
            this.panVentas.Size = new System.Drawing.Size(1020, 541);
            this.panVentas.TabIndex = 2;
            this.panVentas.Visible = false;
            // 
            // lblAviso
            // 
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(115)))), ((int)(((byte)(135)))));
            this.lblAviso.Location = new System.Drawing.Point(250, 78);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(520, 48);
            this.lblAviso.TabIndex = 4;
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(79)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(59)))));
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(62)))), ((int)(((byte)(111)))));
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
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(175)))), ((int)(((byte)(182)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(143)))), ((int)(((byte)(149)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
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
            // 
            // colEliminar
            // 
            this.colEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEliminar.HeaderText = "Eliminar";
            this.colEliminar.MinimumWidth = 6;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.ReadOnly = true;
            this.colEliminar.Width = 88;
            // 
            // colEditar
            // 
            this.colEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEditar.HeaderText = "Editar";
            this.colEditar.MinimumWidth = 6;
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Width = 84;
            // 
            // colEstado
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colEstado.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 125;
            // 
            // colVer
            // 
            this.colVer.HeaderText = "Ver";
            this.colVer.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colVer.MinimumWidth = 6;
            this.colVer.Name = "colVer";
            this.colVer.ReadOnly = true;
            this.colVer.Width = 60;
            // 
            // colPrecio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 125;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 78;
            // 
            // colCategoriaProducto
            // 
            this.colCategoriaProducto.HeaderText = "Categoría";
            this.colCategoriaProducto.MinimumWidth = 6;
            this.colCategoriaProducto.Name = "colCategoriaProducto";
            this.colCategoriaProducto.ReadOnly = true;
            this.colCategoriaProducto.Width = 115;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 170;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn2.HeaderText = "Eliminar";
            this.dataGridViewButtonColumn2.MinimumWidth = 6;
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Width = 88;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn7.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Ver";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn5.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 78;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Categoría";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 115;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Especie";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeight = 48;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.dataGridView1.Location = new System.Drawing.Point(22, 82);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 44;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(976, 377);
            this.dataGridView1.TabIndex = 6;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.HeaderText = "Editar";
            this.dataGridViewButtonColumn1.MinimumWidth = 6;
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Width = 84;
            // 
            // colEspecie
            // 
            this.colEspecie.HeaderText = "Especie";
            this.colEspecie.MinimumWidth = 6;
            this.colEspecie.Name = "colEspecie";
            this.colEspecie.ReadOnly = true;
            this.colEspecie.Width = 105;
            // 
            // panReportes
            // 
            this.panReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panReportes.Controls.Add(this.dataGridView1);
            this.panReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panReportes.Location = new System.Drawing.Point(0, 0);
            this.panReportes.Name = "panReportes";
            this.panReportes.Size = new System.Drawing.Size(1020, 541);
            this.panReportes.TabIndex = 3;
            // 
            // panConfig
            // 
            this.panConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panConfig.Location = new System.Drawing.Point(0, 0);
            this.panConfig.Name = "panConfig";
            this.panConfig.Size = new System.Drawing.Size(1020, 541);
            this.panConfig.TabIndex = 4;
            this.panConfig.Visible = false;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // panDashboard
            // 
            this.panDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
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
            // panContenido
            // 
            this.panContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.panContenido.Controls.Add(this.panDashboard);
            this.panContenido.Controls.Add(this.panInventario);
            this.panContenido.Controls.Add(this.panVentas);
            this.panContenido.Controls.Add(this.panReportes);
            this.panContenido.Controls.Add(this.panConfig);
            this.panContenido.Location = new System.Drawing.Point(260, 108);
            this.panContenido.Name = "panContenido";
            this.panContenido.Size = new System.Drawing.Size(1020, 541);
            this.panContenido.TabIndex = 5;
            // 
            // panInventario
            // 
            this.panInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
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
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(46)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvProductos.ColumnHeadersHeight = 48;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colEspecie,
            this.colCategoriaProducto,
            this.colCantidad,
            this.colPrecio,
            this.colVer,
            this.colEstado,
            this.colEditar,
            this.colEliminar});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(238)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(244)))));
            this.dgvProductos.Location = new System.Drawing.Point(22, 142);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 44;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvProductos.Size = new System.Drawing.Size(976, 377);
            this.dgvProductos.TabIndex = 5;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(0, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(150, 42);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "admin";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panUsuario
            // 
            this.panUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(91)))), ((int)(((byte)(123)))));
            this.panUsuario.Controls.Add(this.lblUsuario);
            this.panUsuario.Location = new System.Drawing.Point(850, 32);
            this.panUsuario.Name = "panUsuario";
            this.panUsuario.Size = new System.Drawing.Size(150, 42);
            this.panUsuario.TabIndex = 1;
            // 
            // panTopBar
            // 
            this.panTopBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.panTopBar.Controls.Add(this.button1);
            this.panTopBar.Controls.Add(this.panUsuario);
            this.panTopBar.Controls.Add(this.lblTitulo);
            this.panTopBar.Location = new System.Drawing.Point(260, 0);
            this.panTopBar.Name = "panTopBar";
            this.panTopBar.Size = new System.Drawing.Size(1020, 108);
            this.panTopBar.TabIndex = 4;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1020, 108);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DASHBOARD";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(108)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(131)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(16, 579);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(228, 54);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(108)))));
            this.btnConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(131)))));
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Location = new System.Drawing.Point(16, 432);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnConfig.Size = new System.Drawing.Size(228, 54);
            this.btnConfig.TabIndex = 5;
            this.btnConfig.TabStop = false;
            this.btnConfig.Text = "Configuración";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfig.UseVisualStyleBackColor = false;
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(108)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(131)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Location = new System.Drawing.Point(16, 366);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(228, 54);
            this.btnReportes.TabIndex = 4;
            this.btnReportes.TabStop = false;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(108)))));
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.btnVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(131)))));
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnVentas.ForeColor = System.Drawing.Color.White;
            this.btnVentas.Location = new System.Drawing.Point(16, 300);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(228, 54);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.TabStop = false;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(108)))));
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.btnInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(131)))));
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
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInventario.UseVisualStyleBackColor = false;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(112)))), ((int)(((byte)(137)))));
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(133)))), ((int)(((byte)(161)))));
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
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicio.UseVisualStyleBackColor = false;
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
            // panLateral
            // 
            this.panLateral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.panLateral.Controls.Add(this.btnSalir);
            this.panLateral.Controls.Add(this.btnConfig);
            this.panLateral.Controls.Add(this.btnReportes);
            this.panLateral.Controls.Add(this.btnVentas);
            this.panLateral.Controls.Add(this.btnInventario);
            this.panLateral.Controls.Add(this.btnInicio);
            this.panLateral.Controls.Add(this.picLogo);
            this.panLateral.Location = new System.Drawing.Point(0, 0);
            this.panLateral.Name = "panLateral";
            this.panLateral.Size = new System.Drawing.Size(260, 649);
            this.panLateral.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(108)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(96)))), ((int)(((byte)(136)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(131)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(943, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(77, 36);
            this.button1.TabIndex = 7;
            this.button1.TabStop = false;
            this.button1.Text = "X";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panValor
            // 
            this.panValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panValor.BackColor = System.Drawing.Color.White;
            this.panValor.Controls.Add(this.grafValor);
            this.panValor.Controls.Add(this.lblValorTitulo);
            this.panValor.Location = new System.Drawing.Point(686, 342);
            this.panValor.Name = "panValor";
            this.panValor.Size = new System.Drawing.Size(312, 177);
            this.panValor.TabIndex = 7;
            // 
            // grafValor
            // 
            this.grafValor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafValor.BackColor = System.Drawing.Color.White;
            this.grafValor.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.grafValor.Location = new System.Drawing.Point(14, 38);
            this.grafValor.Name = "grafValor";
            this.grafValor.Size = new System.Drawing.Size(284, 127);
            this.grafValor.TabIndex = 1;
            // 
            // lblValorTitulo
            // 
            this.lblValorTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblValorTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
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
            this.panTop5.Controls.Add(this.grafTop5);
            this.panTop5.Controls.Add(this.lblTop5Titulo);
            this.panTop5.Location = new System.Drawing.Point(686, 150);
            this.panTop5.Name = "panTop5";
            this.panTop5.Size = new System.Drawing.Size(312, 176);
            this.panTop5.TabIndex = 6;
            // 
            // grafTop5
            // 
            this.grafTop5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafTop5.BackColor = System.Drawing.Color.White;
            this.grafTop5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.grafTop5.Location = new System.Drawing.Point(14, 38);
            this.grafTop5.Name = "grafTop5";
            this.grafTop5.Size = new System.Drawing.Size(284, 126);
            this.grafTop5.TabIndex = 1;
            // 
            // lblTop5Titulo
            // 
            this.lblTop5Titulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTop5Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
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
            this.panAlertas.Controls.Add(this.flpAlertas);
            this.panAlertas.Controls.Add(this.lblAlertasTitulo);
            this.panAlertas.Location = new System.Drawing.Point(354, 150);
            this.panAlertas.Name = "panAlertas";
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
            this.flpAlertas.Location = new System.Drawing.Point(12, 44);
            this.flpAlertas.Name = "flpAlertas";
            this.flpAlertas.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.flpAlertas.Size = new System.Drawing.Size(288, 310);
            this.flpAlertas.TabIndex = 1;
            this.flpAlertas.WrapContents = false;
            // 
            // lblAlertasTitulo
            // 
            this.lblAlertasTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlertasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
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
            this.panEspecie.Controls.Add(this.grafEspecie);
            this.panEspecie.Controls.Add(this.lblEspecieTitulo);
            this.panEspecie.Location = new System.Drawing.Point(22, 150);
            this.panEspecie.Name = "panEspecie";
            this.panEspecie.Size = new System.Drawing.Size(316, 369);
            this.panEspecie.TabIndex = 4;
            // 
            // grafEspecie
            // 
            this.grafEspecie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafEspecie.BackColor = System.Drawing.Color.White;
            this.grafEspecie.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.grafEspecie.Location = new System.Drawing.Point(14, 44);
            this.grafEspecie.Name = "grafEspecie";
            this.grafEspecie.Size = new System.Drawing.Size(288, 310);
            this.grafEspecie.TabIndex = 1;
            // 
            // lblEspecieTitulo
            // 
            this.lblEspecieTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblEspecieTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
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
            this.panKpi4.Controls.Add(this.picKpi4);
            this.panKpi4.Controls.Add(this.lblKpi4Valor);
            this.panKpi4.Controls.Add(this.lblKpi4Titulo);
            this.panKpi4.Controls.Add(this.panBarra4);
            this.panKpi4.Location = new System.Drawing.Point(766, 22);
            this.panKpi4.Name = "panKpi4";
            this.panKpi4.Size = new System.Drawing.Size(232, 112);
            this.panKpi4.TabIndex = 3;
            // 
            // picKpi4
            // 
            this.picKpi4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.picKpi4.Location = new System.Drawing.Point(170, 24);
            this.picKpi4.Name = "picKpi4";
            this.picKpi4.Size = new System.Drawing.Size(46, 46);
            this.picKpi4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picKpi4.TabIndex = 3;
            this.picKpi4.TabStop = false;
            // 
            // lblKpi4Valor
            // 
            this.lblKpi4Valor.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblKpi4Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
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
            this.lblKpi4Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblKpi4Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi4Titulo.Name = "lblKpi4Titulo";
            this.lblKpi4Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi4Titulo.TabIndex = 1;
            this.lblKpi4Titulo.Text = "Bajo inventario:";
            this.lblKpi4Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra4
            // 
            this.panBarra4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.panBarra4.Location = new System.Drawing.Point(1, 1);
            this.panBarra4.Name = "panBarra4";
            this.panBarra4.Size = new System.Drawing.Size(230, 6);
            this.panBarra4.TabIndex = 0;
            // 
            // panKpi3
            // 
            this.panKpi3.BackColor = System.Drawing.Color.White;
            this.panKpi3.Controls.Add(this.picKpi3);
            this.panKpi3.Controls.Add(this.lblKpi3Valor);
            this.panKpi3.Controls.Add(this.lblKpi3Titulo);
            this.panKpi3.Controls.Add(this.panBarra3);
            this.panKpi3.Location = new System.Drawing.Point(518, 22);
            this.panKpi3.Name = "panKpi3";
            this.panKpi3.Size = new System.Drawing.Size(232, 112);
            this.panKpi3.TabIndex = 2;
            // 
            // picKpi3
            // 
            this.picKpi3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
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
            this.lblKpi3Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
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
            this.lblKpi3Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblKpi3Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi3Titulo.Name = "lblKpi3Titulo";
            this.lblKpi3Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi3Titulo.TabIndex = 1;
            this.lblKpi3Titulo.Text = "Valor del inventario:";
            this.lblKpi3Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra3
            // 
            this.panBarra3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.panBarra3.Location = new System.Drawing.Point(1, 1);
            this.panBarra3.Name = "panBarra3";
            this.panBarra3.Size = new System.Drawing.Size(230, 6);
            this.panBarra3.TabIndex = 0;
            // 
            // panKpi2
            // 
            this.panKpi2.BackColor = System.Drawing.Color.White;
            this.panKpi2.Controls.Add(this.picKpi2);
            this.panKpi2.Controls.Add(this.lblKpi2Valor);
            this.panKpi2.Controls.Add(this.lblKpi2Titulo);
            this.panKpi2.Controls.Add(this.panBarra2);
            this.panKpi2.Location = new System.Drawing.Point(270, 22);
            this.panKpi2.Name = "panKpi2";
            this.panKpi2.Size = new System.Drawing.Size(232, 112);
            this.panKpi2.TabIndex = 1;
            // 
            // picKpi2
            // 
            this.picKpi2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
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
            this.lblKpi2Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
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
            this.lblKpi2Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblKpi2Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi2Titulo.Name = "lblKpi2Titulo";
            this.lblKpi2Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi2Titulo.TabIndex = 1;
            this.lblKpi2Titulo.Text = "Unidades disponibles:";
            this.lblKpi2Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra2
            // 
            this.panBarra2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.panBarra2.Location = new System.Drawing.Point(1, 1);
            this.panBarra2.Name = "panBarra2";
            this.panBarra2.Size = new System.Drawing.Size(230, 6);
            this.panBarra2.TabIndex = 0;
            // 
            // panKpi1
            // 
            this.panKpi1.BackColor = System.Drawing.Color.White;
            this.panKpi1.Controls.Add(this.picKpi1);
            this.panKpi1.Controls.Add(this.lblKpi1Valor);
            this.panKpi1.Controls.Add(this.lblKpi1Titulo);
            this.panKpi1.Controls.Add(this.panBarra1);
            this.panKpi1.Location = new System.Drawing.Point(22, 22);
            this.panKpi1.Name = "panKpi1";
            this.panKpi1.Size = new System.Drawing.Size(232, 112);
            this.panKpi1.TabIndex = 0;
            // 
            // picKpi1
            // 
            this.picKpi1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
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
            this.lblKpi1Valor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
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
            this.lblKpi1Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblKpi1Titulo.Location = new System.Drawing.Point(14, 16);
            this.lblKpi1Titulo.Name = "lblKpi1Titulo";
            this.lblKpi1Titulo.Size = new System.Drawing.Size(154, 36);
            this.lblKpi1Titulo.TabIndex = 1;
            this.lblKpi1Titulo.Text = "Productos registrados:";
            this.lblKpi1Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panBarra1
            // 
            this.panBarra1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(145)))), ((int)(((byte)(178)))));
            this.panBarra1.Location = new System.Drawing.Point(1, 1);
            this.panBarra1.Name = "panBarra1";
            this.panBarra1.Size = new System.Drawing.Size(230, 6);
            this.panBarra1.TabIndex = 0;
            // 
            // panFiltro
            // 
            this.panFiltro.BackColor = System.Drawing.Color.White;
            this.panFiltro.Controls.Add(this.cboFiltro);
            this.panFiltro.Controls.Add(this.picFiltro);
            this.panFiltro.Location = new System.Drawing.Point(468, 20);
            this.panFiltro.Name = "panFiltro";
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
            this.cboFiltro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Todas las especies",
            "Tropical",
            "Agresivo",
            "Frío"});
            this.cboFiltro.Location = new System.Drawing.Point(44, 7);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(246, 31);
            this.cboFiltro.TabIndex = 1;
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
            this.panBuscador.Controls.Add(this.txtBuscar);
            this.panBuscador.Controls.Add(this.picLupa);
            this.panBuscador.Location = new System.Drawing.Point(22, 20);
            this.panBuscador.Name = "panBuscador";
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
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.txtBuscar.Location = new System.Drawing.Point(44, 10);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(374, 25);
            this.txtBuscar.TabIndex = 1;
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
            // panFiltroVentas
            // 
            this.panFiltroVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panFiltroVentas.BackColor = System.Drawing.Color.White;
            this.panFiltroVentas.Controls.Add(this.lblCategoriaVenta);
            this.panFiltroVentas.Controls.Add(this.cboCategoriaVenta);
            this.panFiltroVentas.Controls.Add(this.lblAvisoVentas);
            this.panFiltroVentas.Controls.Add(this.btnActualizarVentas);
            this.panFiltroVentas.Location = new System.Drawing.Point(22, 18);
            this.panFiltroVentas.Name = "panFiltroVentas";
            this.panFiltroVentas.Size = new System.Drawing.Size(976, 56);
            this.panFiltroVentas.TabIndex = 0;
            // 
            // lblCategoriaVenta
            // 
            this.lblCategoriaVenta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoriaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblCategoriaVenta.Location = new System.Drawing.Point(18, 16);
            this.lblCategoriaVenta.Name = "lblCategoriaVenta";
            this.lblCategoriaVenta.Size = new System.Drawing.Size(86, 24);
            this.lblCategoriaVenta.TabIndex = 0;
            this.lblCategoriaVenta.Text = "Categoría:";
            this.lblCategoriaVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCategoriaVenta
            // 
            this.cboCategoriaVenta.BackColor = System.Drawing.Color.White;
            this.cboCategoriaVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoriaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategoriaVenta.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboCategoriaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.cboCategoriaVenta.FormattingEnabled = true;
            this.cboCategoriaVenta.Location = new System.Drawing.Point(110, 13);
            this.cboCategoriaVenta.Name = "cboCategoriaVenta";
            this.cboCategoriaVenta.Size = new System.Drawing.Size(240, 31);
            this.cboCategoriaVenta.TabIndex = 1;
            // 
            // lblAvisoVentas
            // 
            this.lblAvisoVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvisoVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAvisoVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(115)))), ((int)(((byte)(135)))));
            this.lblAvisoVentas.Location = new System.Drawing.Point(366, 8);
            this.lblAvisoVentas.Name = "lblAvisoVentas";
            this.lblAvisoVentas.Size = new System.Drawing.Size(420, 40);
            this.lblAvisoVentas.TabIndex = 2;
            this.lblAvisoVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnActualizarVentas
            // 
            this.btnActualizarVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(43)))), ((int)(((byte)(79)))));
            this.btnActualizarVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarVentas.FlatAppearance.BorderSize = 0;
            this.btnActualizarVentas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(32)))), ((int)(((byte)(59)))));
            this.btnActualizarVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(62)))), ((int)(((byte)(111)))));
            this.btnActualizarVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarVentas.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnActualizarVentas.ForeColor = System.Drawing.Color.White;
            this.btnActualizarVentas.Location = new System.Drawing.Point(800, 10);
            this.btnActualizarVentas.Name = "btnActualizarVentas";
            this.btnActualizarVentas.Size = new System.Drawing.Size(158, 36);
            this.btnActualizarVentas.TabIndex = 3;
            this.btnActualizarVentas.TabStop = false;
            this.btnActualizarVentas.Text = "Actualizar";
            this.btnActualizarVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizarVentas.UseVisualStyleBackColor = false;
            // 
            // panCatalogo
            // 
            this.panCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panCatalogo.BackColor = System.Drawing.Color.White;
            this.panCatalogo.Controls.Add(this.flpCatalogo);
            this.panCatalogo.Controls.Add(this.lblCatalogoVacio);
            this.panCatalogo.Controls.Add(this.lblCatalogoTitulo);
            this.panCatalogo.Location = new System.Drawing.Point(22, 88);
            this.panCatalogo.Name = "panCatalogo";
            this.panCatalogo.Size = new System.Drawing.Size(636, 433);
            this.panCatalogo.TabIndex = 1;
            // 
            // flpCatalogo
            // 
            this.flpCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCatalogo.AutoScroll = true;
            this.flpCatalogo.BackColor = System.Drawing.Color.White;
            this.flpCatalogo.Location = new System.Drawing.Point(12, 44);
            this.flpCatalogo.Name = "flpCatalogo";
            this.flpCatalogo.Size = new System.Drawing.Size(612, 377);
            this.flpCatalogo.TabIndex = 1;
            // 
            // lblCatalogoVacio
            // 
            this.lblCatalogoVacio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCatalogoVacio.BackColor = System.Drawing.Color.White;
            this.lblCatalogoVacio.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblCatalogoVacio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblCatalogoVacio.Location = new System.Drawing.Point(16, 44);
            this.lblCatalogoVacio.Name = "lblCatalogoVacio";
            this.lblCatalogoVacio.Size = new System.Drawing.Size(604, 90);
            this.lblCatalogoVacio.TabIndex = 2;
            this.lblCatalogoVacio.Text = "No hay productos en esta categoría.";
            this.lblCatalogoVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCatalogoVacio.Visible = false;
            // 
            // lblCatalogoTitulo
            // 
            this.lblCatalogoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCatalogoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblCatalogoTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblCatalogoTitulo.Name = "lblCatalogoTitulo";
            this.lblCatalogoTitulo.Size = new System.Drawing.Size(300, 24);
            this.lblCatalogoTitulo.TabIndex = 0;
            this.lblCatalogoTitulo.Text = "Productos";
            // 
            // panCarrito
            // 
            this.panCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panCarrito.BackColor = System.Drawing.Color.White;
            this.panCarrito.Controls.Add(this.lblTotalVenta);
            this.panCarrito.Controls.Add(this.lblTotalVentas);
            this.panCarrito.Controls.Add(this.btnVaciarCarrito);
            this.panCarrito.Controls.Add(this.btnRegistrarVenta);
            this.panCarrito.Controls.Add(this.lblCarritoVacio);
            this.panCarrito.Controls.Add(this.flpCarrito);
            this.panCarrito.Controls.Add(this.lblCarritoTitulo);
            this.panCarrito.Location = new System.Drawing.Point(668, 88);
            this.panCarrito.Name = "panCarrito";
            this.panCarrito.Size = new System.Drawing.Size(330, 433);
            this.panCarrito.TabIndex = 2;
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalVenta.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTotalVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(124)))), ((int)(((byte)(134)))));
            this.lblTotalVenta.Location = new System.Drawing.Point(130, 331);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(184, 30);
            this.lblTotalVenta.TabIndex = 4;
            this.lblTotalVenta.Text = "$ 0.00";
            this.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalVentas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblTotalVentas.Location = new System.Drawing.Point(16, 334);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(110, 28);
            this.lblTotalVentas.TabIndex = 3;
            this.lblTotalVentas.Text = "Total:";
            this.lblTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVaciarCarrito
            // 
            this.btnVaciarCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVaciarCarrito.BackColor = System.Drawing.Color.White;
            this.btnVaciarCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVaciarCarrito.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnVaciarCarrito.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.btnVaciarCarrito.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnVaciarCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaciarCarrito.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVaciarCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(50)))), ((int)(((byte)(90)))));
            this.btnVaciarCarrito.Location = new System.Drawing.Point(16, 372);
            this.btnVaciarCarrito.Name = "btnVaciarCarrito";
            this.btnVaciarCarrito.Size = new System.Drawing.Size(140, 40);
            this.btnVaciarCarrito.TabIndex = 5;
            this.btnVaciarCarrito.Text = "Vaciar carrito";
            this.btnVaciarCarrito.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(175)))), ((int)(((byte)(182)))));
            this.btnRegistrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarVenta.FlatAppearance.BorderSize = 0;
            this.btnRegistrarVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(143)))), ((int)(((byte)(149)))));
            this.btnRegistrarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(199)))), ((int)(((byte)(207)))));
            this.btnRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(166, 372);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(148, 40);
            this.btnRegistrarVenta.TabIndex = 6;
            this.btnRegistrarVenta.Text = "Registrar venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            // 
            // lblCarritoVacio
            // 
            this.lblCarritoVacio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarritoVacio.BackColor = System.Drawing.Color.White;
            this.lblCarritoVacio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCarritoVacio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblCarritoVacio.Location = new System.Drawing.Point(16, 52);
            this.lblCarritoVacio.Name = "lblCarritoVacio";
            this.lblCarritoVacio.Size = new System.Drawing.Size(298, 60);
            this.lblCarritoVacio.TabIndex = 2;
            this.lblCarritoVacio.Text = "Agrega productos del catálogo para iniciar la venta.";
            this.lblCarritoVacio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpCarrito
            // 
            this.flpCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCarrito.AutoScroll = true;
            this.flpCarrito.BackColor = System.Drawing.Color.White;
            this.flpCarrito.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCarrito.Location = new System.Drawing.Point(8, 44);
            this.flpCarrito.Name = "flpCarrito";
            this.flpCarrito.Size = new System.Drawing.Size(314, 282);
            this.flpCarrito.TabIndex = 1;
            this.flpCarrito.WrapContents = false;
            // 
            // lblCarritoTitulo
            // 
            this.lblCarritoTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCarritoTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(64)))), ((int)(((byte)(95)))));
            this.lblCarritoTitulo.Location = new System.Drawing.Point(16, 12);
            this.lblCarritoTitulo.Name = "lblCarritoTitulo";
            this.lblCarritoTitulo.Size = new System.Drawing.Size(200, 24);
            this.lblCarritoTitulo.TabIndex = 0;
            this.lblCarritoTitulo.Text = "Carrito";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 649);
            this.Controls.Add(this.panContenido);
            this.Controls.Add(this.panTopBar);
            this.Controls.Add(this.panLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panReportes.ResumeLayout(false);
            this.panDashboard.ResumeLayout(false);
            this.panContenido.ResumeLayout(false);
            this.panInventario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.panUsuario.ResumeLayout(false);
            this.panTopBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panLateral.ResumeLayout(false);
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
            this.panFiltro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFiltro)).EndInit();
            this.panBuscador.ResumeLayout(false);
            this.panBuscador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLupa)).EndInit();
            this.panFiltroVentas.ResumeLayout(false);
            this.panCatalogo.ResumeLayout(false);
            this.panCarrito.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Label lblCategoriaVenta;
        private ComboBox cboCategoriaVenta;
        private Button btnActualizarVentas;
        private PanelRedondeado panFiltroVentas;
        private Label lblAvisoVentas;
        private Panel panVentas;
        private PanelRedondeado panCatalogo;
        private FlowLayoutPanel flpCatalogo;
        private Label lblCatalogoVacio;
        private Label lblCatalogoTitulo;
        private PanelRedondeado panCarrito;
        private Label lblTotalVenta;
        private Label lblTotalVentas;
        private Button btnVaciarCarrito;
        private Button btnRegistrarVenta;
        private Label lblCarritoVacio;
        private FlowLayoutPanel flpCarrito;
        private Label lblCarritoTitulo;
        private TextBox txtBuscar;
        private PictureBox picLupa;
        private PictureBox picFiltro;
        private Label lblAviso;
        private Button btnActualizar;
        private Button btnAgregar;
        private ComboBox cboFiltro;
        private PanelRedondeado panFiltro;
        private DataGridViewButtonColumn colEliminar;
        private PanelRedondeado panBuscador;
        private DataGridViewButtonColumn colEditar;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewImageColumn colVer;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colCategoriaProducto;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridView dataGridView1;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewTextBoxColumn colEspecie;
        private Panel panReportes;
        private Panel panConfig;
        private DataGridViewTextBoxColumn colId;
        private FlowLayoutPanel flpAlertas;
        private PanelRedondeado panAlertas;
        private Label lblAlertasTitulo;
        private GraficaBarras grafTop5;
        private Label lblTop5Titulo;
        private PanelRedondeado panTop5;
        private GraficaBarras grafValor;
        private Label lblValorTitulo;
        private PanelRedondeado panValor;
        private Panel panDashboard;
        private PanelRedondeado panEspecie;
        private GraficaBarras grafEspecie;
        private Label lblEspecieTitulo;
        private PanelRedondeado panKpi4;
        private PictureBox picKpi4;
        private Label lblKpi4Valor;
        private Label lblKpi4Titulo;
        private Panel panBarra4;
        private PanelRedondeado panKpi3;
        private PictureBox picKpi3;
        private Label lblKpi3Valor;
        private Label lblKpi3Titulo;
        private Panel panBarra3;
        private PanelRedondeado panKpi2;
        private PictureBox picKpi2;
        private Label lblKpi2Valor;
        private Label lblKpi2Titulo;
        private Panel panBarra2;
        private PanelRedondeado panKpi1;
        private PictureBox picKpi1;
        private Label lblKpi1Valor;
        private Label lblKpi1Titulo;
        private Panel panBarra1;
        private Panel panContenido;
        private Panel panInventario;
        private DataGridView dgvProductos;
        private Label lblUsuario;
        private Panel panUsuario;
        private Panel panTopBar;
        private Label lblTitulo;
        private Button btnSalir;
        private Button btnConfig;
        private Button btnReportes;
        private Button btnVentas;
        private Button btnInventario;
        private Button btnInicio;
        private PictureBox picLogo;
        private Panel panLateral;
        private Button button1;
    }
}
