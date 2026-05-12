namespace pryZarateBDUniversal
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private Guna.UI2.WinForms.Guna2Panel pnlArchivo;
        private System.Windows.Forms.Label lblArchivo;
        private Guna.UI2.WinForms.Guna2TextBox txtRuta;
        private Guna.UI2.WinForms.Guna2Button btnExaminar;
        private Guna.UI2.WinForms.Guna2Button btnConectar;
        private Guna.UI2.WinForms.Guna2Panel pnlTablas;
        private System.Windows.Forms.Label lblTablas;
        private System.Windows.Forms.ListBox lstTablas;
        private Guna.UI2.WinForms.Guna2Panel pnlDatos;
        private System.Windows.Forms.Label lblDatos;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDatos;
        private Guna.UI2.WinForms.Guna2Panel pnlEstado;
        private System.Windows.Forms.Label lblEstado;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlArchivo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnConectar = new Guna.UI2.WinForms.Guna2Button();
            this.btnExaminar = new Guna.UI2.WinForms.Guna2Button();
            this.txtRuta = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.pnlTablas = new Guna.UI2.WinForms.Guna2Panel();
            this.lstTablas = new System.Windows.Forms.ListBox();
            this.lblTablas = new System.Windows.Forms.Label();
            this.pnlDatos = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDatos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblDatos = new System.Windows.Forms.Label();
            this.pnlEstado = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlArchivo.SuspendLayout();
            this.pnlTablas.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.pnlEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(26, 50);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(350, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Conectate a cualquier archivo .accdb o .mdb y explora sus tablas.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.lblTitulo.Location = new System.Drawing.Point(21, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(388, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Explorador de Bases de Access";
            // 
            // pnlArchivo
            // 
            this.pnlArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlArchivo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlArchivo.BorderRadius = 10;
            this.pnlArchivo.BorderThickness = 1;
            this.pnlArchivo.Controls.Add(this.btnConectar);
            this.pnlArchivo.Controls.Add(this.btnExaminar);
            this.pnlArchivo.Controls.Add(this.txtRuta);
            this.pnlArchivo.Controls.Add(this.lblArchivo);
            this.pnlArchivo.Location = new System.Drawing.Point(24, 105);
            this.pnlArchivo.Name = "pnlArchivo";
            this.pnlArchivo.Padding = new System.Windows.Forms.Padding(20);
            this.pnlArchivo.Size = new System.Drawing.Size(952, 100);
            this.pnlArchivo.TabIndex = 1;
            // 
            // btnConectar
            // 
            this.btnConectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConectar.BorderRadius = 6;
            this.btnConectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConectar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnConectar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.btnConectar.Location = new System.Drawing.Point(800, 40);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(130, 36);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnExaminar
            // 
            this.btnExaminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExaminar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnExaminar.BorderRadius = 6;
            this.btnExaminar.BorderThickness = 1;
            this.btnExaminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminar.FillColor = System.Drawing.Color.Transparent;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExaminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnExaminar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnExaminar.Location = new System.Drawing.Point(670, 40);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(120, 36);
            this.btnExaminar.TabIndex = 2;
            this.btnExaminar.Text = "Examinar...";
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuta.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtRuta.BorderRadius = 6;
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRuta.DefaultText = "";
            this.txtRuta.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtRuta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtRuta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtRuta.Location = new System.Drawing.Point(22, 40);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.PasswordChar = '\0';
            this.txtRuta.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.txtRuta.PlaceholderText = "C:\\ruta\\a\\tu\\base.accdb";
            this.txtRuta.SelectedText = "";
            this.txtRuta.Size = new System.Drawing.Size(640, 36);
            this.txtRuta.TabIndex = 1;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblArchivo.Location = new System.Drawing.Point(22, 18);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(87, 15);
            this.lblArchivo.TabIndex = 0;
            this.lblArchivo.Text = "Archivo Access";
            // 
            // pnlTablas
            // 
            this.pnlTablas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTablas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlTablas.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlTablas.BorderRadius = 10;
            this.pnlTablas.BorderThickness = 1;
            this.pnlTablas.Controls.Add(this.lstTablas);
            this.pnlTablas.Controls.Add(this.lblTablas);
            this.pnlTablas.Location = new System.Drawing.Point(24, 220);
            this.pnlTablas.Name = "pnlTablas";
            this.pnlTablas.Padding = new System.Windows.Forms.Padding(15);
            this.pnlTablas.Size = new System.Drawing.Size(280, 395);
            this.pnlTablas.TabIndex = 2;
            // 
            // lstTablas
            // 
            this.lstTablas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTablas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lstTablas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTablas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstTablas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.lstTablas.FormattingEnabled = true;
            this.lstTablas.ItemHeight = 17;
            this.lstTablas.Location = new System.Drawing.Point(18, 50);
            this.lstTablas.Name = "lstTablas";
            this.lstTablas.Size = new System.Drawing.Size(244, 306);
            this.lstTablas.TabIndex = 1;
            this.lstTablas.SelectedIndexChanged += new System.EventHandler(this.lstTablas_SelectedIndexChanged);
            // 
            // lblTablas
            // 
            this.lblTablas.AutoSize = true;
            this.lblTablas.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTablas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.lblTablas.Location = new System.Drawing.Point(18, 15);
            this.lblTablas.Name = "lblTablas";
            this.lblTablas.Size = new System.Drawing.Size(51, 20);
            this.lblTablas.TabIndex = 0;
            this.lblTablas.Text = "Tablas";
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlDatos.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.pnlDatos.BorderRadius = 10;
            this.pnlDatos.BorderThickness = 1;
            this.pnlDatos.Controls.Add(this.dgvDatos);
            this.pnlDatos.Controls.Add(this.lblDatos);
            this.pnlDatos.Location = new System.Drawing.Point(316, 220);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Padding = new System.Windows.Forms.Padding(15);
            this.pnlDatos.Size = new System.Drawing.Size(660, 395);
            this.pnlDatos.TabIndex = 3;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.ColumnHeadersHeight = 38;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvDatos.Location = new System.Drawing.Point(18, 50);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowTemplate.Height = 30;
            this.dgvDatos.Size = new System.Drawing.Size(624, 322);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.dgvDatos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDatos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDatos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDatos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDatos.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvDatos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvDatos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.dgvDatos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDatos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDatos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatos.ThemeStyle.HeaderStyle.Height = 38;
            this.dgvDatos.ThemeStyle.ReadOnly = true;
            this.dgvDatos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvDatos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDatos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDatos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvDatos.ThemeStyle.RowsStyle.Height = 30;
            this.dgvDatos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDatos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(211)))), ((int)(((byte)(238)))));
            this.lblDatos.Location = new System.Drawing.Point(18, 15);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(48, 20);
            this.lblDatos.TabIndex = 0;
            this.lblDatos.Text = "Datos";
            // 
            // pnlEstado
            // 
            this.pnlEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlEstado.Controls.Add(this.lblEstado);
            this.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEstado.Location = new System.Drawing.Point(0, 630);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(1000, 35);
            this.pnlEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblEstado.Location = new System.Drawing.Point(24, 9);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(74, 15);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Sin conexion";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1000, 665);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlTablas);
            this.Controls.Add(this.pnlArchivo);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Explorador de Bases de Access";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlArchivo.ResumeLayout(false);
            this.pnlArchivo.PerformLayout();
            this.pnlTablas.ResumeLayout(false);
            this.pnlTablas.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.pnlEstado.ResumeLayout(false);
            this.pnlEstado.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
