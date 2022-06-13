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

        private String _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Services\TFG-PlantaPiloto.mdf;Integrated Security=True";

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

        public DB_services(CultureInfo cul, String connectionString)
        {
            _cul = cul;
            _exMg = new ExceptionManagement(_cul);
            _connectionString = connectionString;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Método que crea la tabla donde se van a guardar los datos a partir de las variables del proyecto
        /// </summary>
        /// <param name="pr">Proyecto del que toma los datos</param>
        public void CreateTableDB(Proyect proyect)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    // Open the SqlConnection.
                    //con.Close();
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("DROP TABLE " + proyect.Name, con))
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
                    this.CreateWebTableDB(proyect);
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                    MessageBox.Show("Excepcion en el método CreateTableDB()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception crating the project table in the data base.\n" + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    CloseConnection(con);
                }
            }

        }

        public void CreateWebTableDB(Proyect proyect)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();

                    if (CheckWebDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("DROP TABLE Web" + proyect.Name, con))
                            command.ExecuteNonQuery();

                    // Create table string
                    StringBuilder sqlStr = new StringBuilder("CREATE TABLE Web" + proyect.Name + "([Id] [int] IDENTITY(1,1) NOT NULL, [Time] [nvarchar](20) NOT NULL, [Variable] [nvarchar](20), [NuevoValor] [nvarchar](20) NOT NULL)");

                    // The following code uses an SqlCommand based on the SqlConnection.
                    using (SqlCommand command = new SqlCommand(sqlStr.ToString(), con))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                    MessageBox.Show("Excepcion en el método CreateWebTableDB()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception creating the project web table in the data base.\n" + ex.Message + "\n" + ex.StackTrace);
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
            //using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    StringBuilder sqlStr = new StringBuilder("SELECT TOP 1 [Time]");
                    vars.ForEach(f => sqlStr.Append(",[" + f + "]"));
                    //sqlStr.Append(" FROM [" + GlobalParameters.DBName + "].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ");
                    sqlStr.Append(" FROM " + proyect.Name + " ORDER BY [Id] DESC ");
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
                    MessageBox.Show("Excepcion en el método GetLastRowValue()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception getting the last row of the project table.\n" + ex.Message + "\n" + ex.StackTrace);
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
            //using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    // Cadena para insertar una nueva fila
                    StringBuilder insertCmd = new StringBuilder("INSERT INTO " + proyect.Name + "([Time]");
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
                    MessageBox.Show("Excepcion en el método SaveRow()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception saving a row in the project table.\n" + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    CloseConnection(con);
                }
            }
        }

        public void InsertModifyValue(Proyect proyect, string variable, string value, string time)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckWebDBExists(proyect))
                    {
                        // Cadena para insertar una nueva fila
                        StringBuilder insertCmd = new StringBuilder("INSERT INTO Web" + proyect.Name + "([Time],[Variable],[NuevoValor]) VALUES ('" + time + "', '" + variable + "', '" + value + "')");

                        using (SqlCommand command = new SqlCommand(insertCmd.ToString(), con))
                            command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    //_exMg.HandleException(ex);
                    MessageBox.Show("Excepcion en el método InsertModifyValue()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception inserting new row in the project web table.\n" + ex.Message + "\n" + ex.StackTrace);
                }
                finally
                {
                    CloseConnection(con);
                }
            }
        }

        public string GetLastRowValueWeb(Proyect proyect)
        {
            StringBuilder row = new StringBuilder("");
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();

                    if (CheckWebDBExists(proyect))
                    {
                        StringBuilder sqlStr = new StringBuilder("SELECT TOP 1 [Variable],[NuevoValor] FROM Web" + proyect.Name + " ORDER BY [Id] DESC");
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
                    return null;
                }
                catch (Exception ex)
                {
                    _exMg.HandleException(ex);
                    MessageBox.Show("Excepcion en el método GetLastRowValueWeb()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception getting las row in the project web table.\n" + ex.Message + "\n" + ex.StackTrace);
                    return row.ToString();
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
            //using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                List<Variable> result = new List<Variable>();
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("SELECT TOP " + amount + "[" + var.Name + "] " +
                            "FROM " + proyect.Name + " ORDER BY ID DESC ", con))
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
                    MessageBox.Show("Excepcion en el método GetVarValue()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception getting variable list from project table.\n" + ex.Message + "\n" + ex.StackTrace);
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
            //using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                List<float> result = new List<float>();
                try
                {
                    // Open the SqlConnection.
                    con.Open();

                    if (CheckDBExists(proyect))
                        using (SqlCommand command = new SqlCommand("SELECT TOP " + amount + "[Time] " +
                            "FROM " + proyect.Name + " ORDER BY [Id] DESC ", con))
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
                    MessageBox.Show("Excepcion en el método GetTime()" + ex.Message + ex.StackTrace);
                    GlobalParameters.errorLog.NewEntry("Exception getting the time from the project table.\n" + ex.Message + "\n" + ex.StackTrace);
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
                //using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=" + GlobalParameters.DBName + ";Integrated Security = True;"))
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    /* string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '" + GlobalParameters.DBName + "'" +
                            " AND TABLE_NAME = '" + proyect.Name + "'";*/

                    string sCmd = "SELECT [Id] FROM " + proyect.Name;

                    SqlCommand cmd = new SqlCommand(sCmd, con);
                    cmd.ExecuteScalar();
                    return true;
                    //return ((int)cmd.ExecuteScalar() == 1);
                }
            }
            catch (SqlException)
            {
                // No existe la base de datos
                return false;
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
                MessageBox.Show("Excepcion en el método CheckDBExists()" + ex.Message + ex.StackTrace + ex.GetType().FullName);
                GlobalParameters.errorLog.NewEntry("Exception checking if the project data base table exist.\n" + ex.Message + "\n" + ex.StackTrace);
                return false;
            }
        }

        public bool CheckWebDBExists(Proyect proyect)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();

                    string sCmd = "SELECT [Id] FROM Web" + proyect.Name;

                    SqlCommand cmd = new SqlCommand(sCmd, con);
                    cmd.ExecuteScalar();
                    return true;
                    //return ((int)cmd.ExecuteScalar() == 1);
                }
            }
            catch (SqlException)
            {
                // No existe la base de datos
                return false;
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
                MessageBox.Show("Excepcion en el método CheckDBExists()" + ex.Message + ex.StackTrace + ex.GetType().FullName);
                GlobalParameters.errorLog.NewEntry("Exception checking if the project web data base table exist.\n" + ex.Message + "\n" + ex.StackTrace);
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

        public String getConnectionString()
        {
            return _connectionString;
        }
        #endregion
    }
}
