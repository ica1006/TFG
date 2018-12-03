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
                    string sqlStr = "CREATE TABLE " + proyect.Name + "([Id] [int] IDENTITY(1,1) NOT NULL";
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
        public void GetColumnNames(Proyect proyect)
        {
            List<string> columns = new List<string>();
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
                        using (SqlCommand command = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                            "WHERE TABLE_CATALOG = 'TFG_DB' AND TABLE_NAME = '" + proyect.Name + "'", con))
                        {
                            SqlDataReader columnsDataReader = command.ExecuteReader();
                            while (columnsDataReader.Read())
                            {
                                columns.Add(String.Format("{0}", columnsDataReader[0]));
                            }
                        }
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
                    string insertCmd = "INSERT INTO [dbo].[" + proyect.Name + "](";
                    foreach (Variable v in proyect.Variables)
                        insertCmd += "[" + v.Name + "],";
                    insertCmd = insertCmd.Substring(0, insertCmd.Length - 1);
                    insertCmd += ") VALUES (";
                    foreach (Variable v in proyect.Variables)
                        insertCmd += v.Type == EnumVarType.String ? "'"+v.Value.ToString() + "',": v.Value + ",";
                    insertCmd = insertCmd.Substring(0, insertCmd.Length - 1);
                    insertCmd += ")";
                    // Comprobamos si está
                    // Devuelve 1 si ya existe o 0 si no existe
                    if ((int)cmd.ExecuteScalar() == 1)
                        using (SqlCommand command = new SqlCommand(insertCmd, con))
                            command.ExecuteNonQuery();
                    else
                        this.CreateTableDB(proyect);
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
    }
}
