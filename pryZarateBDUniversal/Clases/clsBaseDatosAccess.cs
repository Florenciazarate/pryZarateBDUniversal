using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace pryZarateBDUniversal
{
    // Conecta a cualquier base de datos de Microsoft Access (.accdb o .mdb).
    public class BaseDatosAccess
    {
        private string _connectionString; // La cadena de conexión que se arma al abrir un archivo.
        private string _rutaArchivo;       // Ruta del archivo de Access actualmente conectado.

        public string RutaArchivo => _rutaArchivo; // Devuelve la ruta del archivo conectado.
        public bool EstaConectado => !string.IsNullOrEmpty(_connectionString); // True si hay una conexión configurada.

        // Intenta conectar a un archivo de Access. Prueba ACE 16, ACE 12 y Jet 4.0 hasta que uno funcione.
        public bool Conectar(string rutaArchivo, out string errorMessage)
        {
            errorMessage = null;

            if (!File.Exists(rutaArchivo)) // Si el archivo no existe, error.
            {
                errorMessage = "El archivo no existe.";
                return false;
            }

            var extension = Path.GetExtension(rutaArchivo).ToLowerInvariant();
            var providers = new List<string>();

            if (extension == ".mdb") // Para .mdb (Access antiguo) priorizo Jet.
            {
                providers.Add("Microsoft.Jet.OLEDB.4.0");
                providers.Add("Microsoft.ACE.OLEDB.12.0");
                providers.Add("Microsoft.ACE.OLEDB.16.0");
            }
            else // Para .accdb (Access moderno) priorizo ACE.
            {
                providers.Add("Microsoft.ACE.OLEDB.16.0");
                providers.Add("Microsoft.ACE.OLEDB.12.0");
                providers.Add("Microsoft.Jet.OLEDB.4.0");
            }

            Exception ultimoError = null;
            foreach (var provider in providers) // Pruebo provider por provider.
            {
                var cs = $"Provider={provider};Data Source={rutaArchivo};Persist Security Info=False;";
                try
                {
                    using (var conn = new OleDbConnection(cs))
                    {
                        conn.Open(); // Si esto no falla, el provider funciona.
                    }
                    _connectionString = cs;
                    _rutaArchivo = rutaArchivo;
                    return true;
                }
                catch (Exception ex)
                {
                    ultimoError = ex; // Guardo el error por si todos fallan.
                }
            }

            errorMessage = "No se pudo conectar al archivo. " +
                           "Verifica tener instalado Microsoft Access Database Engine (ACE) " +
                           "y que la plataforma de compilación coincida (x86/x64).";
            if (ultimoError != null)
                errorMessage += "\n\nÚltimo error: " + ultimoError.Message;

            return false;
        }

        // Devuelve los nombres de todas las tablas de usuario en la base (sin las del sistema MSys*).
        public DataTable ObtenerTablas()
        {
            var tablas = new DataTable();
            tablas.Columns.Add("TABLE_NAME");

            using (var conn = new OleDbConnection(_connectionString))
            {
                conn.Open();
                var schema = conn.GetSchema("Tables"); // Pido a la conexión el esquema de tablas.

                foreach (DataRow row in schema.Rows)
                {
                    var nombre = row["TABLE_NAME"]?.ToString();
                    var tipo = row["TABLE_TYPE"]?.ToString();

                    if (string.IsNullOrWhiteSpace(nombre)) continue;
                    if (nombre.StartsWith("MSys", StringComparison.OrdinalIgnoreCase)) continue; // Las MSys son del sistema, las salto.
                    if (tipo != null && tipo.ToUpperInvariant() != "TABLE") continue; // Solo tablas (no vistas ni internas).

                    tablas.Rows.Add(nombre);
                }
            }

            return tablas;
        }

        // Devuelve todos los datos de una tabla.
        public DataTable ObtenerDatosDeTabla(string nombreTabla)
        {
            var datos = new DataTable();
            using (var conn = new OleDbConnection(_connectionString))
            using (var da = new OleDbDataAdapter($"SELECT * FROM [{nombreTabla}]", conn)) // Uso corchetes por si el nombre tiene espacios.
            {
                da.Fill(datos);
            }
            return datos;
        }
    }
}
