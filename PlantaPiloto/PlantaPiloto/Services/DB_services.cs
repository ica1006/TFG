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
            string sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", GlobalParameters.DBName);
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
                string mdfFile = Path.Combine(GlobalParameters.DBPath, "" + GlobalParameters.DBName + ".mdf");
                string logFile = Path.Combine(GlobalParameters.DBPath, "" + GlobalParameters.DBName + "_Log.ldf");
                SqlConnection myConn = new SqlConnection(@"Server = localhost\sqlexpress; Integrated Security = True");
                str = "CREATE DATABASE " + GlobalParameters.DBName + " ON PRIMARY " +
                    "(NAME = " + GlobalParameters.DBName + ", " +
                    "FILENAME = '" + mdfFile + "'," +
                    "SIZE = 16MB, MAXSIZE = 20MB, FILEGROWTH = 10%) " +
                    "LOG ON (NAME = " + GlobalParameters.DBName + "_Log, " +
                    "FILENAME = '" + logFile + "', " +
                    "SIZE = 4MB, " +
                    "MAXSIZE = 20MB, " +
                    "FILEGROWTH = 10%)";
                using (SqlCommand myCommand = new SqlCommand(str, myConn))
                {
                    try
                    {
                        myConn.Open();
                        //Crear directorio y asignar permisos para poder crear archivos
                        if (!Directory.Exists(GlobalParameters.DBPath))
                            Directory.CreateDirectory(GlobalParameters.DBPath);
                        if (File.Exists(mdfFile))
                            File.Delete(mdfFile);
                        if (File.Exists(logFile))
                            File.Delete(logFile);
                        DirectorySecurity ds = Directory.GetAccessControl(GlobalParameters.DBPath);
                        ds.AddAccessRule(new FileSystemAccessRule(GlobalParameters.DBCreationUser, FileSystemRights.FullControl, AccessControlType.Allow));
                        Directory.SetAccessControl(GlobalParameters.DBPath, ds);
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
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("DROP TABLE dbo." + proyect.Name, con))
                            command.ExecuteNonQuery();

                    // Create table string
                    StringBuilder sqlStr = new StringBuilder("CREATE TABLE " + proyect.Name + "([Id] [int] IDENTITY(1,1) NOT NULL, [Time] [nvarchar](20) NOT NULL");
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
        public string GetLastRowValue(Proyect proyect, List<string> vars)
        {
            StringBuilder row = new StringBuilder("");
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    StringBuilder sqlStr = new StringBuilder("SELECT TOP 1 [Time]");
                    vars.ForEach(f => sqlStr.Append(",[" + f + "]"));
                    sqlStr.Append(" FROM [" + GlobalParameters.DBName + "].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ");
                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand(sqlStr.ToString(), con))
                        {
                            SqlDataReader columnsDataReader = command.ExecuteReader();
                            while (columnsDataReader.Read())
                            {
                                for (int i = 0; i < columnsDataReader.FieldCount; i++)
                                    row.Append(String.Format("{0};", columnsDataReader[i]));
                            }
                        }
                    return row.ToString();
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                    return row.ToString();
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
        public void SaveRow(Proyect proyect, float time)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    // Cadena para insertar una nueva fila
                    StringBuilder insertCmd = new StringBuilder("INSERT INTO [dbo].[" + proyect.Name + "]([Time]");
                    foreach (Variable v in proyect.Variables)
                        insertCmd.Append(",[" + v.Name + "]");
                    insertCmd.Append(") VALUES ('" + time + "'");

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
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            {
                List<Variable> result = new List<Variable>();
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("SELECT TOP " + amount + "[" + var.Name + "] " +
                            "FROM [" + GlobalParameters.DBName + "].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ", con))
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
                                    Value = var.Type == EnumVarType.String ? varDataReader.GetString(0) : varDataReader.GetDouble(0).ToString()
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
        /// Mëtodo que devuelve una lista de tiempos almacenados en la BD.
        /// </summary>
        /// <param name="proyect"></param>
        /// <param name="var"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public List<float> GetTime(Proyect proyect, int amount)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            {
                List<float> result = new List<float>();
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("SELECT TOP " + amount + "[Time] " +
                            "FROM [" + GlobalParameters.DBName + "].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ", con))
                        {
                            SqlDataReader columnsDataReader = command.ExecuteReader();
                            while (columnsDataReader.Read())
                                result.Add(float.Parse(String.Format("{0}", columnsDataReader[0])));
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
                using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
                {
                    con.Open();

                    string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '" + GlobalParameters.DBName + "'" +
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
