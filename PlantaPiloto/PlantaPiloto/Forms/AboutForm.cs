using System.Resources;
using PlantaPiloto.Classes;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PlantaPiloto
{
    public partial class AboutForm : Form
    {
        #region Properties

        readonly ResourceManager _res_man;
        private CultureInfo _cul;
        readonly HelpProvider _helpProvider;
        readonly ExceptionManagement _exMg;
        readonly string _filesPath;

        public CultureInfo Cul
        {
            get { return _cul; }
            set { _cul = value; OnPropertyChanged("Cul"); }
        }

        #endregion

        #region Constructor

        public AboutForm(CultureInfo cul)
        {
            InitializeComponent();
            _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);
            _cul = cul;
            _helpProvider = new HelpProvider();
            _filesPath = new GlobalParameters().FilesPath;
            _helpProvider.HelpNamespace = Path.Combine(_filesPath, "helpProyect.chm");
            _exMg = new ExceptionManagement(_cul);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que se ejecuta al cargar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Load(object sender, EventArgs e)
        {
            this.Switch_language();
        }

        /// <summary>
        /// Método que actualiza las cadenas según idioma
        /// </summary>
        public void Switch_language()
        {
            //Cambio de idioma de las cadenas
            #region Actualización de cadenas

            this.Text = _res_man.GetString("AboutForm_txt", _cul);
            this.gbAbout.Text = _res_man.GetString("lblAboutTitle_txt", _cul);
            this.lblAboutDesc.Text = _res_man.GetString("lblAboutDesc_txt", _cul);
            this.lblAboutDegree.Text = _res_man.GetString("lblAboutDegree_txt", _cul);
            this.lblAboutUni.Text = _res_man.GetString("lblAboutUni_txt", _cul);
            this.btnAboutAccept.Text = _res_man.GetString("btnSaveConfig_txt", _cul);

            #endregion
        }

        #endregion

        #region Events

        /// <summary>
        /// Evento que se ejecuta al pulsar el botón Aceptar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboutAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que abre el archivo de ayuda del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, _helpProvider.HelpNamespace, HelpNavigator.KeywordIndex, "Acerca de");
            }
            catch (Exception ex)
            {
                _exMg.HandleException(ex);
            }
        }

        #endregion

        #region Miembros de INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Método que actualiza la propiedad cuando esta cambia de valor
        /// </summary>
        /// <param name="name">Propiedad a actualizar</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
