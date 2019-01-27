using PlantaPiloto.Classes;
using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public class DB_services
    {
        #region Properties
        readonly GlobalParameters _globalParameters;

        readonly ExceptionManagement _exMg;

        private CultureInfo _cul;

        public CultureInfo Cul
        {
            get { return _cul; }
            set
            {
                _cul = value;
            }
        }

        #endregion

        #region Constructor
        public DB_services(CultureInfo cul)
        {
            _cul = cul;
            _exMg = new ExceptionManagement(_cul);
            _globalParameters = new GlobalParameters();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Método que crea una Base de Datos en SQL Server
        /// </summary>
        public void CreateDB()
        {
            //Comprobar si la DB existe
            bool dbExists = false;
            SqlConnection tmpConn = new SqlConnection("Server=localhost\\sqlexpress;Integrated security=SSPI;database=master");
            string sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", _globalParameters.DBName);
            using (tmpConn)
            {
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                {
                    tmpConn.Open();
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                        int.TryParse(resultObj.ToString(), out databaseID);                    
                    tmpConn.Close();
                    dbExists = (databaseID > 0);
                }
            }
            //Si la DB no existe se crea
            if (!dbExists)
            {
                String str;
                SqlConnection myConn = new SqlConnection("Server=localhost\\sqlexpress;Integrated security=SSPI;database=master");
                str = "CREATE DATABASE " + _globalParameters.DBName + " ON PRIMARY " +
                    "(NAME = " + _globalParameters.DBName + ", " +
                    "FILENAME = '" + Path.Combine(_globalParameters.DBPath, "" + _globalParameters.DBName + ".mdf") + "'," +
                    "SIZE = 16MB, MAXSIZE = 20MB, FILEGROWTH = 10%) " +
                    "LOG ON (NAME = " + _globalParameters.DBName + "_Log, " +
                    "FILENAME = '" + Path.Combine(_globalParameters.DBPath, "" + _globalParameters.DBName + "_Log.ldf") + "', " +
                    "SIZE = 4MB, " +
                    "MAXSIZE = 20MB, " +
                    "FILEGROWTH = 10%)";
                using (SqlCommand myCommand = new SqlCommand(str, myConn))
                {
                    try
                    {
                        myConn.Open();
                        //Crear directorio y asignar permisos para poder crear archivos
                        if (!Directory.Exists(_globalParameters.DBPath))
                            Directory.CreateDirectory(_globalParameters.DBPath);
                        DirectorySecurity ds = Directory.GetAccessControl(_globalParameters.DBPath);
                        ds.AddAccessRule(new FileSystemAccessRule("Todos", FileSystemRights.FullControl, AccessControlType.Allow));
                        Directory.SetAccessControl(_globalParameters.DBPath, ds);
                        //Ejecutar sentencia SQL
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        _exMg.HandleException(ex);
                    }
                    finally
                    {
                        if (myConn.State == ConnectionState.Open)
                        {
                            myConn.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Método que crea la tabla donde se van a guardar los datos a partir de las variables del proyecto
        /// </summary>
        /// <param name="pr">Proyecto del que toma los datos</param>
        public void CreateTableDB(Proyect proyect)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + _globalParameters.DBName + ";Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("DROP TABLE dbo." + proyect.Name, con))
                            command.ExecuteNonQuery();

                    // Create table string
                    StringBuilder sqlStr = new StringBuilder("CREATE TABLE " + proyect.Name + "([Id] [int] IDENTITY(1,1) NOT NULL, [Time] [int] NOT NULL");
                    foreach (Variable v in proyect.Variables)
                    {
                        sqlStr.Append(", [" + v.Name + "] ");
                        if (v.Type == EnumVarType.String)
                            sqlStr.Append("[nvarchar](20) NULL");
                        else
                            sqlStr.Append("[float] NULL");
                    }
                    sqlStr.Append(")");

                    // The following code uses an SqlCommand based on the SqlConnection.
                    using (SqlCommand command = new SqlCommand(sqlStr.ToString(), con))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                }
                finally
                {
                    CloseConnection(con);
                }
            }

        }

        /// <summary>
        /// Método que obtiene el nombre de las columnas del proyecto que se pasa por parámetro
        /// </summary>
        /// <param name="proyect">Proyecto del que se quieren conocer los nombres de las columnas</param>
        public string[] GetLastRowValue(Proyect proyect)
        {
            string[] row = null;
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + _globalParameters.DBName + ";Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM [" + _globalParameters.DBName + "].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ", con))
                        {
                            SqlDataReader columnsDataReader = command.ExecuteReader();
                            while (columnsDataReader.Read())
                            {
                                row = new string[columnsDataReader.FieldCount];
                                for (int i = 0; i < columnsDataReader.FieldCount; i++)
                                    row[i] = String.Format("{0}", columnsDataReader[i]);
                            }
                        }
                    return row;
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                    return row;
                }
                finally
                {
                    CloseConnection(con);
                }
            }
        }

        /// <summary>
        /// Método que añade una nueva fila a la BD
        /// </summary>
        /// <param name="proyect">Proyecto del que obtiene los datos para crear la consulta</param>
        public void SaveRow(Proyect proyect)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + _globalParameters.DBName + ";Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    // Cadena para insertar una nueva fila
                    StringBuilder insertCmd = new StringBuilder("INSERT INTO [dbo].[" + proyect.Name + "]([Time]");
                    foreach (Variable v in proyect.Variables)
                        insertCmd.Append(",[" + v.Name + "]");
                    insertCmd.Append(") VALUES (" + proyect.Variables[0].Time);

                    foreach (Variable v in proyect.Variables)
                        insertCmd.Append(v.Type == EnumVarType.String ? ",'" + v.Value.ToString() + "'" : "," + v.Value);
                    insertCmd.Append(")");

                    // Comprobamos si está
                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand(insertCmd.ToString(), con))
                            command.ExecuteNonQuery();
                    else
                        CreateTableDB(proyect);
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                }
                finally
                {
                    CloseConnection(con);
                }
            }
        }

        /// <summary>
        /// Mëtodo que devuelve una lista de variables con los valores almacenados en la BD.
        /// </summary>
        /// <param name="proyect"></param>
        /// <param name="var"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public List<Variable> GetVarValue(Proyect proyect, Variable var, int amount)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + _globalParameters.DBName + ";Integrated Security = True;"))
            {
                List<Variable> result = new List<Variable>();
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("SELECT TOP " + amount + " [Time], [" + var.Name + "] " +
                            "FROM [" + _globalParameters.DBName + "].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ", con))
                        {
                            SqlDataReader varDataReader = command.ExecuteReader();
                            while (varDataReader.Read())
                            {
                                Variable v = new Variable
                                {
                                    Name = var.Name,
                                    Type = var.Type,
                                    Access = var.Access,
                                    CommunicationType = var.CommunicationType,
                                    Time = varDataReader.GetInt32(0),
                                    Value = var.Type == EnumVarType.String ? varDataReader.GetString(1) : varDataReader.GetDouble(1).ToString()
                                };
                                result.Add(v);
                            }
                        }
                    return result;
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                    return result;
                }
                finally
                {
                    CloseConnection(con);
                }
            }
        }

        /// <summary>
        /// Método que evalúa si la BD existe
        /// </summary>
        /// <param name="proyect">Proyecto que se utiliza para saber el nombre de la BD</param>
        /// <returns></returns>
        public bool CheckDBExists(Proyect proyect)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + _globalParameters.DBName + ";Integrated Security = True;"))
                {
                    con.Open();

                    string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '" + _globalParameters.DBName + "'" +
                           " AND TABLE_NAME = '" + proyect.Name + "'";

                    SqlCommand cmd = new SqlCommand(sCmd, con);

                    return ((int)cmd.ExecuteScalar() == 1);
                }
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
                return false;
            }
        }

        /// <summary>
        /// Método que cierra la conexión con la BD
        /// </summary>
        /// <param name="con"></param>
        public void CloseConnection(SqlConnection con)
        {
            con.Close();
            con.Dispose();
        }
        #endregion
    }
}
