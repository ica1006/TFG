using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public class DB_services
    {
        /// <summary>
        /// Método que crea la tabla donde se van a guardar los datos a partir de las variables del proyecto
        /// </summary>
        /// <param name="pr">Proyecto del que toma los datos</param>
        public void CreateTableDB(Proyect proyect)
        {
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=TFG_DB;Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    // Delete table if exists
                    string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'TFG_DB'" +
                        " AND TABLE_NAME = '" + proyect.Name + "'";
                    SqlCommand cmd = new SqlCommand(sCmd, con);
                    // Comprobamos si está
                    // Devuelve 1 si ya existe o 0 si no existe
                    if ((int)cmd.ExecuteScalar() == 1)
                        using (SqlCommand command = new SqlCommand("DROP TABLE dbo." + proyect.Name, con))
                            command.ExecuteNonQuery();

                    // Create table string
                    string sqlStr = "CREATE TABLE " + proyect.Name + "([Id] [int] IDENTITY(1,1) NOT NULL, [Time] [int] NOT NULL";
                    foreach (Variable v in proyect.Variables)
                    {
                        sqlStr += ", [" + v.Name + "] ";
                        if (v.Type == EnumVarType.String)
                            sqlStr += "[nvarchar](20) NULL";
                        else
                            sqlStr += "[float] NULL";
                    }
                    sqlStr += ")";

                    // The following code uses an SqlCommand based on the SqlConnection.
                    using (SqlCommand command = new SqlCommand(sqlStr, con))
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

        }

        /// <summary>
        /// Método que obtiene el nombre de las columnas del proyecto que se pasa por parámetro
        /// </summary>
        /// <param name="proyect">Proyecto del que se quieren conocer los nombres de las columnas</param>
        public static string[] GetLastRowValue(Proyect proyect)
        {
            string[] row = null;
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=TFG_DB;Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    // Delete table if exists
                    string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'TFG_DB'" +
                        " AND TABLE_NAME = '" + proyect.Name + "'";
                    SqlCommand cmd = new SqlCommand(sCmd, con);
                    // Comprobamos si está
                    // Devuelve 1 si ya existe o 0 si no existe
                    if ((int)cmd.ExecuteScalar() == 1)
                        using (SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM [TFG_DB].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ", con))
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
                    MessageBox.Show(ex.Message);
                    return row;
                }
                finally
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Método que añade una nueva fila a la BD
        /// </summary>
        /// <param name="proyect">Proyecto del que obtiene los datos para crear la consulta</param>
        public void SaveRow(Proyect proyect)
        {
            List<string> columns = new List<string>();
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=TFG_DB;Integrated Security = True;"))
            {
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    // Cadena para comprobar si la tabla existe
                    string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'TFG_DB'" +
                        " AND TABLE_NAME = '" + proyect.Name + "'";
                    SqlCommand cmd = new SqlCommand(sCmd, con);
                    // Cadena para insertar una nueva fila
                    string insertCmd = "INSERT INTO [dbo].[" + proyect.Name + "]([Time]";
                    foreach (Variable v in proyect.Variables)
                        insertCmd += ",[" + v.Name + "]";
                    insertCmd += ") VALUES (" + proyect.Variables[0].Time;
                    foreach (Variable v in proyect.Variables)
                        insertCmd += v.Type == EnumVarType.String ? ",'" + v.Value.ToString() + "'" : "," + v.Value;
                    insertCmd += ")";
                    // Comprobamos si está
                    // Devuelve 1 si ya existe o 0 si no existe
                    if ((int)cmd.ExecuteScalar() == 1)
                        using (SqlCommand command = new SqlCommand(insertCmd, con))
                            command.ExecuteNonQuery();
                    else
                        CreateTableDB(proyect);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    try
                    {
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception)
                    {
                    }
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
            using (SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress; Database=TFG_DB;Integrated Security = True;"))
            {
                List<Variable> result = new List<Variable>();
                try
                {
                    // Open the SqlConnection.
                    con.Open();
                    // Delete table if exists
                    string sCmd = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'TFG_DB'" +
                        " AND TABLE_NAME = '" + proyect.Name + "'";
                    SqlCommand cmd = new SqlCommand(sCmd, con);
                    // Comprobamos si está
                    // Devuelve 1 si ya existe o 0 si no existe
                    if ((int)cmd.ExecuteScalar() == 1)
                        using (SqlCommand command = new SqlCommand("SELECT TOP " + amount + " [Time], [" + var.Name + "] " +
                            "FROM [TFG_DB].[dbo].[" + proyect.Name + "] ORDER BY ID DESC ", con))
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
                                    // EVALUAR TIPO DE VARIABLE Y ASIGNAR GETDOUBLE, GETINT DEPENDIENDO
                                    Value = varDataReader.GetDouble(1).ToString()
                                    //Value = varDataReader[1].ToString()
                                };
                                result.Add(v);
                            }
                        }
                    return result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return result;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
