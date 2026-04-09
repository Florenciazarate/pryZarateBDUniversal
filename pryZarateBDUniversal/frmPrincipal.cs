using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace pryZarateBDUniversal
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cmbProvider.Items.Clear();
            cmbProvider.Items.Add("System.Data.SQLite");
            cmbProvider.Items.Add("System.Data.SqlClient");
            cmbProvider.SelectedIndex = 0;

            txtConnection.Text = System.IO.Path.Combine(Application.StartupPath, "miBase.sqlite");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "SQLite files (*.sqlite;*.db)|*.sqlite;*.db|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtConnection.Text = ofd.FileName;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var provider = cmbProvider.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(provider))
                provider = "System.Data.SQLite";

            string connString;
            if (provider == "System.Data.SQLite")
            {
                connString = $"Data Source={txtConnection.Text};Version=3;";
            }
            else
            {
                connString = txtConnection.Text; 
            }

            try
            {
                using (var db = new UniversalDatabase(provider, connString))
                {
                    var dt = db.GetDataTable("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;");
                    if (dt.Rows.Count == 0 && provider != "System.Data.SQLite")
                    {
                        dt = db.GetDataTable("SELECT TOP 100 * FROM INFORMATION_SCHEMA.TABLES");
                    }

                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgv.Rows[e.RowIndex];
            var values = new StringBuilder();
            foreach (DataGridViewCell cell in row.Cells)
            {
                values.AppendFormat("{0}: {1}\n", dgv.Columns[cell.ColumnIndex].HeaderText, cell.Value);
            }
            MessageBox.Show(values.ToString(), "Fila", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
