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
            #region Actualización de cadenas

            this.Text = res_man.GetString("ConfigForm_txt", cul);
            this.lblConfigProName.Text = res_man.GetString("lblConfigProName_txt", cul);
            this.lblConfigProDesc.Text = res_man.GetString("lblConfigProDesc_txt", cul);
            this.lblVarAccess.Text = res_man.GetString("lblVarAccess_txt", cul);
            this.lblVarBoardUnits.Text = res_man.GetString("lblVarBoardUnits_txt", cul);
            this.lblVarCommunicationType.Text = res_man.GetString("lblVarCommunicationType_txt", cul);
            this.lblVarDesc.Text = res_man.GetString("lblVarDesc_txt", cul);
            this.lblVarInterfaceUnits.Text = res_man.GetString("lblVarInterfaceUnits_txt", cul);
            this.lblVarLinearAdjust.Text = res_man.GetString("lblVarLinearAdjust_txt", cul);
            this.lblVarName.Text = res_man.GetString("lblVarName_txt", cul);
            this.lblVarRange.Text = res_man.GetString("lblVarRange_txt", cul);
            this.lblVarType.Text = res_man.GetString("lblVarType_txt", cul);
            this.lblVectFile.Text = res_man.GetString("lblVectFile_txt", cul);
            this.gbNewVar.Text = res_man.GetString("gbNewVar_txt", cul);
            this.gbProyectDetails.Text = res_man.GetString("gbProyectDetails_txt", cul);
            this.btnAddVar.Text = res_man.GetString("btnAddVar_txt", cul);
            this.btnSaveConfig.Text = res_man.GetString("btnSaveConfig_txt", cul);

            #endregion
        }

        internal void SetCulture(CultureInfo cultureInfo)
        {
            cul = cultureInfo;
        }

        private void addNewVar_Click(object sender, EventArgs e)
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

        private void saveConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                file = new FileStream(path, FileMode.OpenOrCreate);

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

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Método que se ejecuta al cerrar el formulario, antes de que este se cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            file.Dispose();
        }

        /// <summary>
        /// Método que cambia la disponibilidad de los textbox de ajuste lineal y rango cuando la 
        /// el tipo de variable es una cadena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbVarType_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbVarType.SelectedItem.ToString() == "string")
            {
                txtVarLinearAdjB.Enabled = false;
                txtVarLinearAdjA.Enabled = false;
                txtVarRangeHigh.Enabled = false;
                txtVarRangeLow.Enabled = false;
            }
            else
            {
                txtVarLinearAdjB.Enabled = true;
                txtVarLinearAdjA.Enabled = true;
                txtVarRangeHigh.Enabled = true;
                txtVarRangeLow.Enabled = true;
            }
        }
    }
}
