using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlantaPiloto;

namespace WebPlantaPiloto
{
    public partial class FullDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.updateTable(sender, e);
        }

        protected void updateTable(object sender, EventArgs e)
        {
            string connectionString = (string)Session["connectionString"];
            Proyect project = (Proyect)Session["proyect"];

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from " + project.Name, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Server.Transfer("Main.aspx");
        }
    }
}