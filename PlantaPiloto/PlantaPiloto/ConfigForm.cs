using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public partial class ConfigForm : Form
    {
        private MainForm _mainForm;
        private ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        private CultureInfo cul;            // declare culture info
        private string path;
        private FileStream file;
        private List<string> newVar;
        private List<List<string>> vars;

        public ConfigForm()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            path = @"../../pruebaTFG.txt";
            file = new FileStream(path, FileMode.OpenOrCreate);
            newVar = new List<string>();
            vars = new List<List<string>>();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.switch_language();
        }

        public void switch_language()
        {
            //Cambio de idioma de las cadenas
            this.Text = res_man.GetString("ConfigForm_txt", cul);
            this.lblConfigTitle.Text = res_man.GetString("lblConfigTitle_txt", cul);
            this.lblConfigProName.Text = res_man.GetString("lblConfigProName_txt", cul);
            this.lblConfigProDesc.Text = res_man.GetString("lblConfigProDesc_txt", cul);
        }

        internal void SetCulture(CultureInfo cultureInfo)
        {
            cul = cultureInfo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newVar.Clear();
            if (txtVarDesc.TextLength != 0)
            {
                newVar.Add(txtVarDesc.Text);
            }
            if (txtVarName.TextLength != 0)
            {
                newVar.Add(txtVarName.Text);
            }

            //Comprobar el número de variables mínimas (no nulas) que hacen falta
            if(newVar.Count != 0)
                vars.Add(newVar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (TextWriter tw = new StreamWriter(file))
                {
                    //Hace falta añadir validaciones
                    tw.WriteLine(DateTime.Now);
                    tw.WriteLine(this.txtProName.Text);
                    tw.WriteLine(this.txtProDesc.Text);
                    foreach(List<string> v in vars)
                    {
                        tw.WriteLine("****************************************");
                        foreach(string s in v)
                        {
                            tw.WriteLine(s);
                        }
                    }
                    tw.WriteLine("****************************************");
                    tw.WriteLine("****************************************");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
