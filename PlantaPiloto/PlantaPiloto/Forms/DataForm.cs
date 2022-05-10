using PlantaPiloto.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantaPiloto.Forms
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void datosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.datos' Puede moverla o quitarla según sea necesario.
            this.datosTableAdapter.Fill(this.dataSet1.datos);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            datos d = new datos();
            d.Id = 16;
            d.Nombre = "Pedro Sanchez";
            d.Numero = 78;
            d.Time = "now";
            DBplantaClassDataContext contex = new DBplantaClassDataContext();
            contex.datos.InsertOnSubmit(d);
            try
            {
                contex.SubmitChanges();
                MessageBox.Show("ok");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.datosTableAdapter.Fill(this.dataSet1.datos);
        }
    }
}
