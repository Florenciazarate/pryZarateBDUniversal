using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace pryZarateBDUniversal
{
    // Clase genérica para acceso a bases de datos mediante DbProviderFactory.
    // Permite usar distintos proveedores (SQL Server, SQLite, MySQL, etc.) pasando
    // el nombre del proveedor y la cadena de conexión.
    public class UniversalDatabase : IDisposable
    {
        private readonly DbProviderFactory _factory;
        private readonly string _connectionString;

        public UniversalDatabase(string providerInvariantName, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(providerInvariantName))
            {
                providerInvariantName = "System.Data.SqlClient";
            }

            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            try
            {
                _factory = DbProviderFactories.GetFactory(providerInvariantName);
            }
            catch (Exception ex)
            {
                // Intento de recuperación específico para System.Data.SQLite cuando no está registrado en config.
                if (string.Equals(providerInvariantName, "System.Data.SQLite", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        // Intentar cargar la fábrica vía reflexión (requiere que la DLL de SQLite esté referenciada/copied to output).
                        var asm = Assembly.Load("System.Data.SQLite");
                        var type = asm.GetType("System.Data.SQLite.SQLiteFactory");
                        var field = type?.GetField("Instance", BindingFlags.Public | BindingFlags.Static);
                        var instance = field?.GetValue(null) as DbProviderFactory;
                        if (instance != null)
                        {
                            _factory = instance;
                            return;
                        }
                    }
                    catch
                    {
                        // Ignorar y lanzar un error más claro abajo.
                    }

                    throw new ConfigurationErrorsException(
                        "No se puede obtener el proveedor 'System.Data.SQLite'.\n" +
                        "Pasos para resolver:\n" +
                        "1) Instala el paquete NuGet 'System.Data.SQLite' o 'System.Data.SQLite.Core' en el proyecto.\n" +
                        "   En Visual Studio: Tools > NuGet Package Manager > Package Manager Console:\n" +
                        "   Install-Package System.Data.SQLite.Core\n" +
                        "2) Asegúrate de que la DLL 'System.Data.SQLite.dll' esté copiada al directorio de salida.\n" +
                        "3) (Opcional) Registra el proveedor en App.config en la sección <system.data><DbProviderFactories> con el invariant 'System.Data.SQLite'.\n" +
                        "Si ya instalaste el paquete, revisa la plataforma (x86/x64) y las dependencias nativas.", ex);
                }

                // Para otros proveedores, volver a lanzar una excepción más informativa.
                throw new ConfigurationErrorsException($"No se encuentra o no se puede cargar el proveedor de datos .NET Framework registrado: '{providerInvariantName}'", ex);
            }
        }

        public DbConnection CreateConnection()
        {
            var conn = _factory.CreateConnection();
            conn.ConnectionString = _connectionString;
            return conn;
        }

        public int ExecuteNonQuery(string sql, IEnumerable<DbParameter> parameters = null)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string sql, IEnumerable<DbParameter> parameters = null)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);
                }

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public DataTable GetDataTable(string sql, IEnumerable<DbParameter> parameters = null)
        {
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                if (parameters != null)
                {
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);
                }

                using (var da = _factory.CreateDataAdapter())
                {
                    da.SelectCommand = cmd;
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Ejecuta un script que puede contener varias sentencias separadas por la palabra GO en una línea.
        public void ExecuteScript(string script)
        {
            if (string.IsNullOrWhiteSpace(script))
                return;

            var batches = SplitScriptIntoBatches(script);
            using (var conn = CreateConnection())
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                foreach (var batch in batches)
                {
                    if (string.IsNullOrWhiteSpace(batch))
                        continue;

                    cmd.CommandText = batch;
                    cmd.Parameters.Clear();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static IEnumerable<string> SplitScriptIntoBatches(string script)
        {
            var lines = script.Replace("\r\n", "\n").Split(new[] { '\n' }, StringSplitOptions.None);
            var current = new System.Text.StringBuilder();

            foreach (var raw in lines)
            {
                var line = raw.Trim();
                if (string.Equals(line, "GO", StringComparison.OrdinalIgnoreCase))
                {
                    yield return current.ToString();
                    current.Clear();
                }
                else
                {
                    current.AppendLine(raw);
                }
            }

            if (current.Length > 0)
                yield return current.ToString();
        }

        public DbParameter CreateParameter(string name, object value)
        {
            var p = _factory.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            return p;
        }

        public void Dispose()
        {
            // No hay recursos a liberar en esta implementación, pero se deja para la interfaz.
        }
    }
}
