using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace pryZarateBDUniversal
{
    public partial class frmPrincipal : Form
    {
        private readonly BaseDatosAccess _bd = new BaseDatosAccess(); // Instancio la clase de conexión a Access.

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarEstado("Seleccioná un archivo .accdb o .mdb para empezar.", Color.FromArgb(148, 163, 184));
            // Muestro un mensaje inicial al usuario.
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog()) // Abro un diálogo de selección de archivo.
            {
                ofd.Filter = "Archivos de Access (*.accdb;*.mdb)|*.accdb;*.mdb|Todos los archivos (*.*)|*.*"; // Filtro solo Access.
                ofd.Title = "Seleccionar base de datos de Access";
                ofd.InitialDirectory = ObtenerCarpetaBaseDatos(); // Abro directo en la carpeta BaseDatos del proyecto.

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    txtRuta.Text = ofd.FileName; // Guardo la ruta seleccionada en el textbox.
                }
            }
        }

        private string ObtenerCarpetaBaseDatos() // Busca la carpeta BaseDatos del proyecto subiendo desde bin/Debug.
        {
            var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory); // Empiezo en bin/Debug.
            while (dir != null)
            {
                if (dir.GetFiles("*.csproj").Length > 0) // Si encuentro el .csproj, esta es la carpeta del proyecto.
                {
                    var carpeta = Path.Combine(dir.FullName, "BaseDatos");
                    if (Directory.Exists(carpeta)) return carpeta; // Si existe BaseDatos adentro, devuelvo esa ruta.
                    return dir.FullName; // Sino, abro en la carpeta del proyecto.
                }
                dir = dir.Parent; // Si no encontré el .csproj, subo una carpeta.
            }
            return AppDomain.CurrentDomain.BaseDirectory; // Si nunca encontré, abro en la carpeta del .exe.
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            var ruta = txtRuta.Text.Trim();

            if (string.IsNullOrEmpty(ruta)) // Si no hay ruta, error.
            {
                ActualizarEstado("Debes seleccionar un archivo primero.", Color.IndianRed);
                return;
            }

            string error;
            if (!_bd.Conectar(ruta, out error)) // Intento conectar usando BaseDatosAccess.
            {
                ActualizarEstado("Error al conectar: " + error, Color.IndianRed);
                lstTablas.Items.Clear();
                dgvDatos.DataSource = null;
                return;
            }

            // Si conectó bien, cargo la lista de tablas.
            CargarTablas();
        }

        private void CargarTablas()
        {
            try
            {
                lstTablas.Items.Clear();
                dgvDatos.DataSource = null;

                var tablas = _bd.ObtenerTablas(); // Pido al BaseDatosAccess la lista de tablas.
                foreach (DataRow row in tablas.Rows)
                {
                    lstTablas.Items.Add(row["TABLE_NAME"].ToString()); // Agrego cada nombre al ListBox.
                }

                ActualizarEstado(
                    $"Conectado a {Path.GetFileName(_bd.RutaArchivo)} — {tablas.Rows.Count} tabla(s) encontrada(s).",
                    Color.LimeGreen);
                // Muestro mensaje de éxito con el nombre del archivo y la cantidad de tablas.
            }
            catch (Exception ex)
            {
                ActualizarEstado("Error al listar tablas: " + ex.Message, Color.IndianRed);
            }
        }

        private void lstTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTablas.SelectedItem == null) return; // Si no hay nada seleccionado, salgo.

            var nombreTabla = lstTablas.SelectedItem.ToString();

            try
            {
                var datos = _bd.ObtenerDatosDeTabla(nombreTabla); // Pido todos los datos de esa tabla.
                dgvDatos.DataSource = datos; // Los muestro en la grilla.

                ActualizarEstado(
                    $"Tabla '{nombreTabla}' — {datos.Rows.Count} fila(s).",
                    Color.LimeGreen);
            }
            catch (Exception ex)
            {
                ActualizarEstado("Error al leer la tabla: " + ex.Message, Color.IndianRed);
            }
        }

        private void ActualizarEstado(string mensaje, Color color) // Cambia el texto y color de la barra de estado.
        {
            lblEstado.Text = mensaje;
            lblEstado.ForeColor = color;
        }
    }
}
