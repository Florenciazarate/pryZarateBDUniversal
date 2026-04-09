namespace pryZarateBDUniversal
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cmbProvider;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Label lblConnection;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            // Provider label
            this.lblProvider = new System.Windows.Forms.Label();
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(12, 12);
            this.lblProvider.Text = "Proveedor:";
            this.Controls.Add(this.lblProvider);

            // Provider combo
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.cmbProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvider.Location = new System.Drawing.Point(80, 8);
            this.cmbProvider.Size = new System.Drawing.Size(260, 21);
            this.Controls.Add(this.cmbProvider);

            // Connection label
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(350, 12);
            this.lblConnection.Text = "Cadena/Archivo:";
            this.Controls.Add(this.lblConnection);

            // Connection textbox
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.txtConnection.Location = new System.Drawing.Point(440, 8);
            this.txtConnection.Size = new System.Drawing.Size(240, 20);
            this.txtConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Controls.Add(this.txtConnection);

            // Browse button (para SQLite)
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnBrowse.Location = new System.Drawing.Point(690, 6);
            this.btnBrowse.Size = new System.Drawing.Size(30, 24);
            this.btnBrowse.Text = "...";
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.Controls.Add(this.btnBrowse);

            // Connect button
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnConnect.Location = new System.Drawing.Point(730, 6);
            this.btnConnect.Size = new System.Drawing.Size(60, 24);
            this.btnConnect.Text = "Conectar";
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            this.Controls.Add(this.btnConnect);

            // DataGridView
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(12, 40);
            this.dgv.Size = new System.Drawing.Size(780, 398);
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.Controls.Add(this.dgv);

            this.Load += new System.EventHandler(this.frmPrincipal_Load);
        }

        #endregion
    }
}

