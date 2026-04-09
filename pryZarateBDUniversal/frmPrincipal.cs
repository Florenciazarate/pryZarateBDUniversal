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
            // Ejemplo: crear y usar una base de datos SQLite en archivo local.
            var dbPath = System.IO.Path.Combine(Application.StartupPath, "miBase.sqlite");
            var connString = $"Data Source={dbPath};Version=3;";

            using (var db = new UniversalDatabase("System.Data.SQLite", connString))
            {
                // Crear tabla si no existe
                db.ExecuteScript(@"CREATE TABLE IF NOT EXISTS Personas (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Nombre TEXT NOT NULL,
                                        Edad INTEGER
                                    );");

                // Insertar algunos datos
                db.ExecuteNonQuery("INSERT INTO Personas (Nombre, Edad) VALUES (@nombre, @edad);",
                    new[] { db.CreateParameter("@nombre", "Juan"), db.CreateParameter("@edad", 30) });

                // Leer datos
                var dt = db.GetDataTable("SELECT Id, Nombre, Edad FROM Personas;");
                dgv.DataSource = dt; // Asume que hay un DataGridView llamado dgv en el formulario
            }
        }
    }
}
