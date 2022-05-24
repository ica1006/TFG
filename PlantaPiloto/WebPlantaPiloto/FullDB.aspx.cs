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
            if (!IsPostBack)
            {
                this.updateTable(sender, e);
                if (Session["language"] != null)
                    this.setLanguage();
                if (Session["theme"] != null)
                    this.setTheme();
            }
        }

        protected void updateTable(object sender, EventArgs e)
        {
            string connectionString = (string)Session["connectionString"];
            Proyect project = (Proyect)Session["proyect"];

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from " + project.Name, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            SqlCommand cmd2 = new SqlCommand("select * from Web" + project.Name, con);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2);
            GridView2.DataSource = ds2;
            GridView2.DataBind();
            con.Close();
        }

        private void setLanguage()
        {
            string language = (string)Session["language"];
            if (language.Equals("English"))
            {
                lbl_changesDB.Text = EnglishText.lbl_changesDB;
                lbl_valuesDB.Text = EnglishText.lbl_valuesDB;
                btn_back.Text = EnglishText.btn_back;
                btn_StartStop.Text = EnglishText.btn_StartStop;
            }
            else if (language.Equals("Spanish"))
            {
                lbl_changesDB.Text = SpanishText.lbl_changesDB;
                lbl_valuesDB.Text = SpanishText.lbl_valuesDB;
                btn_back.Text = SpanishText.btn_back;
                btn_StartStop.Text = SpanishText.btn_StartStop;
            }
        }

        private void setTheme()
        {
            string theme = (string)Session["theme"];
            bodyTag.Attributes.Clear();

            if (theme.Equals("Light"))
                bodyTag.Attributes.Add("bgcolor", "white");
            else if (theme.Equals("Dark"))
                bodyTag.Attributes.Add("bgcolor", "#2C2C2C");
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            //Server.Transfer("Main.aspx");
            Response.Redirect("Main.aspx");
        }

        protected void btn_StartStop_Click(object sender, EventArgs e)
        {
            if (btn_StartStop.Text.Equals(EnglishText.btn_StartStop))
            {
                btn_StartStop.Text = EnglishText.btn_StartStop2;
                Timer1.Enabled = false;
            }
            else if (btn_StartStop.Text.Equals(SpanishText.btn_StartStop))
            {
                btn_StartStop.Text = SpanishText.btn_StartStop2;
                Timer1.Enabled = false;
            }else if (btn_StartStop.Text.Equals(EnglishText.btn_StartStop2))
            {
                btn_StartStop.Text = EnglishText.btn_StartStop;
                Timer1.Enabled = true;
            }
            else if (btn_StartStop.Text.Equals(SpanishText.btn_StartStop2))
            {
                btn_StartStop.Text = SpanishText.btn_StartStop;
                Timer1.Enabled = true;
            }
        }
    }
}