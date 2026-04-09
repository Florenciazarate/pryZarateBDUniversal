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
using System.IO;

namespace pryZarateBDUniversal
{
    public partial class frmPrincipal : Form
    {
        private string _lastProvider;
        private string _lastConnectionString;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cmbProvider.Items.Clear();
            cmbProvider.Items.Add("System.Data.SQLite");
            cmbProvider.Items.Add("System.Data.OleDb");
            cmbProvider.Items.Add("System.Data.SqlClient");
            cmbProvider.SelectedIndex = 0;

            txtConnection.Text = Path.Combine(Application.StartupPath, "miBase.sqlite");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var provider = cmbProvider.SelectedItem as string;
            using (var ofd = new OpenFileDialog())
            {
                if (provider == "System.Data.OleDb")
                {
                    ofd.Filter = "Access files (*.accdb;*.mdb)|*.accdb;*.mdb|All files (*.*)|*.*";
                }
                else
                {
                    ofd.Filter = "SQLite files (*.sqlite;*.db)|*.sqlite;*.db|All files (*.*)|*.*";
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtConnection.Text = ofd.FileName;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var source = txtConnection.Text;
            if (string.IsNullOrWhiteSpace(source) || !File.Exists(source))
            {
                MessageBox.Show(this, "Seleccione un archivo válido para importar.", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dest = Path.Combine(Application.StartupPath, Path.GetFileName(source));
                File.Copy(source, dest, true);
                txtConnection.Text = dest;
                MessageBox.Show(this, "Archivo importado al directorio de la aplicación.", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConnection_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtConnection_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (data != null && data.Length > 0)
            {
                txtConnection.Text = data[0];
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var provider = cmbProvider.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(provider))
                provider = "System.Data.SQLite";

            string connString = null;

            if (provider == "System.Data.SQLite")
            {
                connString = $"Data Source={txtConnection.Text};Version=3;";
                // simple path, will be tested below
            }
            else if (provider == "System.Data.OleDb")
            {
                // Para Access intentamos varios providers (ACE 16, ACE 12, Jet) para evitar errores por versión/plataforma
                var ext = Path.GetExtension(txtConnection.Text)?.ToLowerInvariant();
                var attempts = new List<string>();
                if (ext == ".mdb")
                {
                    attempts.Add("Microsoft.Jet.OLEDB.4.0");
                    attempts.Add("Microsoft.ACE.OLEDB.12.0");
                    attempts.Add("Microsoft.ACE.OLEDB.16.0");
                }
                else
                {
                    // .accdb usually needs ACE
                    attempts.Add("Microsoft.ACE.OLEDB.16.0");
                    attempts.Add("Microsoft.ACE.OLEDB.12.0");
                    attempts.Add("Microsoft.Jet.OLEDB.4.0");
                }

                Exception lastEx = null;
                foreach (var prov in attempts)
                {
                    var testConn = $"Provider={prov};Data Source={txtConnection.Text};Persist Security Info=False;";
                    try
                    {
                        using (var db = new UniversalDatabase("System.Data.OleDb", testConn))
                        using (var conn = db.CreateConnection())
                        {
                            conn.Open();
                            // Si abre, elegir este
                            connString = testConn;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        lastEx = ex;
                        // continuar al siguiente provider
                    }
                }

                if (connString == null)
                {
                    var msg = "No se pudo abrir el archivo Access con los providers probados.";
                    if (lastEx != null)
                    {
                        msg += "\n\nÚltimo error: " + lastEx.Message;
                        if (lastEx.Message.IndexOf("file is not a database", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lastEx.Message.IndexOf("not a valid database", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            msg += "\n\nEl archivo puede estar corrupto o no ser un archivo de Access válido. Intenta abrirlo con Microsoft Access y revisarlo.";
                        }
                    }
                    msg += "\n\nAsegúrate de tener instalado Microsoft Access Database Engine (ACE) para archivos .accdb y que la plataforma (x86/x64) coincida.";
                    MessageBox.Show(this, msg, "Error conexión Access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                connString = txtConnection.Text; // Para SQL Server y otros, usuario proporciona la cadena
            }

            // Guardar para uso posterior (doble-click)
            _lastProvider = provider;
            _lastConnectionString = connString;

            try
            {
                using (var db = new UniversalDatabase(provider, connString))
                using (var conn = db.CreateConnection())
                {
                    conn.Open();
                    DataTable schema = null;
                    try
                    {
                        schema = conn.GetSchema("Tables");
                    }
                    catch
                    {
                        schema = null;
                    }

                    DataTable dt = new DataTable();

                    if (schema != null && schema.Rows.Count > 0)
                    {
                        // Buscar columna que contenga el nombre de la tabla
                        string nameCol = null;
                        foreach (DataColumn c in schema.Columns)
                        {
                            var n = c.ColumnName.ToLowerInvariant();
                            if (n.Contains("table") && n.Contains("name")) { nameCol = c.ColumnName; break; }
                        }
                        if (nameCol == null)
                        {
                            // fallback: buscar columna que termine o contenga "name"
                            foreach (DataColumn c in schema.Columns)
                            {
                                if (c.ColumnName.ToLowerInvariant().Contains("name")) { nameCol = c.ColumnName; break; }
                            }
                        }

                        dt.Columns.Add("TABLE_NAME");
                        foreach (DataRow r in schema.Rows)
                        {
                            try
                            {
                                var val = nameCol != null ? r[nameCol]?.ToString() : r[0]?.ToString();
                                var typeCol = schema.Columns.Contains("TABLE_TYPE") ? r["TABLE_TYPE"]?.ToString() : null;
                                // Filtrar filas comunes: TABLE, BASE TABLE
                                if (typeCol != null)
                                {
                                    var t = typeCol.ToUpperInvariant();
                                    if (!(t.Contains("TABLE") || t.Contains("VIEW")))
                                        continue;
                                }
                                if (!string.IsNullOrWhiteSpace(val))
                                    dt.Rows.Add(val);
                            }
                            catch { }
                        }
                    }

                    // Si no obtuvimos nada, intentar consultas por proveedor
                    if (dt.Rows.Count == 0)
                    {
                        if (provider == "System.Data.SQLite")
                        {
                            dt = db.GetDataTable("SELECT name as TABLE_NAME FROM sqlite_master WHERE type='table' ORDER BY name;");
                        }
                        else if (provider == "System.Data.OleDb")
                        {
                            // Intentar usar el esquema alternativo para OleDb
                            try
                            {
                                var schema2 = conn.GetSchema("Tables");
                                dt = new DataTable();
                                dt.Columns.Add("TABLE_NAME");
                                foreach (DataRow r in schema2.Rows)
                                {
                                    var tname = r["TABLE_NAME"]?.ToString();
                                    var ttype = r.Table.Columns.Contains("TABLE_TYPE") ? r["TABLE_TYPE"]?.ToString() : null;
                                    if (!string.IsNullOrWhiteSpace(tname) && (ttype == null || ttype.ToUpperInvariant().Contains("TABLE")))
                                        dt.Rows.Add(tname);
                                }
                            }
                            catch
                            {
                                // última alternativa: intentar consultar MSysObjects (puede fallar por permisos)
                                try
                                {
                                    dt = db.GetDataTable("SELECT Name as TABLE_NAME FROM MSysObjects WHERE (Type=1 OR Type=4) AND Name NOT LIKE 'MSys%';");
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            try
                            {
                                dt = db.GetDataTable("SELECT TOP 100 TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
                            }
                            catch
                            {
                                try
                                {
                                    dt = db.GetDataTable("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");
                                }
                                catch
                                {
                                    dt = new DataTable();
                                }
                            }
                        }
                    }

                    // Normalizar la tabla resultante para que siempre sea una lista simple de nombres (columna TABLE_NAME)
                    dt = NormalizeToTableList(dt);

                    dgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                // Añadir sugerencias comunes para Access
                if (provider == "System.Data.OleDb")
                {
                    msg += "\n\nNota: para Access necesitas tener instalado Microsoft Access Database Engine (ACE) si usas .accdb.\n" +
                           "Si usas .mdb, puede requerir plataforma x86 y el provider Jet. Comprueba la plataforma de compilación.";
                }
                MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable NormalizeToTableList(DataTable src)
        {
            var result = new DataTable();
            result.Columns.Add("TABLE_NAME");
            if (src == null) return result;

            // Buscar columna que claramente sea el nombre de tabla
            string nameCol = null;
            foreach (DataColumn c in src.Columns)
            {
                var n = c.ColumnName.ToLowerInvariant();
                if (n == "table_name" || n == "name" || n.Contains("table") && n.Contains("name"))
                {
                    nameCol = c.ColumnName; break;
                }
            }
            if (nameCol == null)
            {
                // fallback: cualquier columna cuyo nombre contenga "name"
                foreach (DataColumn c in src.Columns)
                {
                    if (c.ColumnName.ToLowerInvariant().Contains("name")) { nameCol = c.ColumnName; break; }
                }
            }

            if (nameCol != null)
            {
                foreach (DataRow r in src.Rows)
                {
                    try
                    {
                        var val = r[nameCol]?.ToString();
                        if (!string.IsNullOrWhiteSpace(val)) result.Rows.Add(val);
                    }
                    catch { }
                }
                return result;
            }

            // Si no encontramos una columna "name", tomar la primera columna
            if (src.Columns.Count > 0)
            {
                foreach (DataRow r in src.Rows)
                {
                    try
                    {
                        var val = r[0]?.ToString();
                        if (!string.IsNullOrWhiteSpace(val)) result.Rows.Add(val);
                    }
                    catch { }
                }
            }

            return result;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Si la vista actual es la lista de tablas (columna TABLE_NAME), abrir la tabla completa
            var currentDt = dgv.DataSource as DataTable;
            if (currentDt != null && currentDt.Columns.Contains("TABLE_NAME") && currentDt.Columns.Count == 1)
            {
                var tableName = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString();
                if (string.IsNullOrWhiteSpace(tableName)) return;

                // Proteger corchetes en el nombre
                tableName = tableName.Replace("]", "]]" );

                try
                {
                    using (var db = new UniversalDatabase(_lastProvider ?? "System.Data.SQLite", _lastConnectionString ?? $"Data Source={Path.Combine(Application.StartupPath, "miBase.sqlite")};Version=3;"))
                    {
                        string sql = BuildSelectAllSql(_lastProvider, tableName);
                        var full = db.GetDataTable(sql);
                        dgv.DataSource = full;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error al abrir tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            // Si no es la lista de tablas, mostrar valores de la fila como antes
            var row = dgv.Rows[e.RowIndex];
            var values = new StringBuilder();
            foreach (DataGridViewCell cell in row.Cells)
            {
                values.AppendFormat("{0}: {1}\n", dgv.Columns[cell.ColumnIndex].HeaderText, cell.Value);
            }
            MessageBox.Show(values.ToString(), "Fila", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string BuildSelectAllSql(string provider, string tableName)
        {
            if (string.IsNullOrWhiteSpace(provider)) provider = "System.Data.SQLite";
            // Escapar según provider
            switch (provider)
            {
                case "System.Data.SqlClient":
                    return $"SELECT * FROM [{tableName}]";
                case "System.Data.OleDb":
                    return $"SELECT * FROM [{tableName}]"; // Access acepta corchetes
                case "System.Data.SQLite":
                default:
                    // Para sqlite usar comillas dobles si el nombre contiene spaces, pero [] suelen funcionar también
                    return $"SELECT * FROM \"{tableName}\"";
            }
        }
    }
}
