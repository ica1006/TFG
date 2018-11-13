using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public partial class ConfigForm : Form
    {
        MainForm _mainForm;
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info

        public ConfigForm()
        {
            InitializeComponent();
            _mainForm = new MainForm();
            res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
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
    }
}
