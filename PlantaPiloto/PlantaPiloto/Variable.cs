using PlantaPiloto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PlantaPiloto
{
    class Variable
    {

        #region Properties

        private ResourceManager _res_man = new ResourceManager("PlantaPiloto.Resources.Res", typeof(MainForm).Assembly);   // declare Resource manager to access to specific cultureinfo
        private CultureInfo _cul;

        public CultureInfo Cul
        {
            get { return _cul; }
            set
            {
                _cul = value; OnPropertyChanged("Cul");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private EnumVarType _type;

        public EnumVarType Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("Type"); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }

        private EnumVarAccess _access;

        public EnumVarAccess Access
        {
            get { return _access; }
            set { _access = value; OnPropertyChanged("Access"); }
        }

        private string _boardUnits;

        public string BoardUnits
        {
            get { return _boardUnits; }
            set { _boardUnits = value; OnPropertyChanged("BoardUnits"); }
        }

        private string _interfaceUnits;

        public string InterfaceUnits
        {
            get { return _interfaceUnits; }
            set { _interfaceUnits = value; OnPropertyChanged("InterfaceUnits"); }
        }

        private float? _linearAdjustA;

        public float? LinearAdjustA
        {
            get { return _linearAdjustA; }
            set { _linearAdjustA = value; OnPropertyChanged("LinearAdjustA"); }
        }

        private float? _linearAdjustB;

        public float? LinearAdjustB
        {
            get { return _linearAdjustB; }
            set { _linearAdjustB = value; OnPropertyChanged("LinearAdjustB"); }
        }

        private float? _rangeLow;

        public float? RangeLow
        {
            get { return _rangeLow; }
            set { _rangeLow = value; OnPropertyChanged("RangeLow"); }
        }

        private float? _rangeHigh;

        public float? RangeHigh
        {
            get { return _rangeHigh; }
            set { _rangeHigh = value; OnPropertyChanged("RangeHigh"); }
        }

        private EnumVarCommunicationType _communicationType;

        public EnumVarCommunicationType CommunicationType
        {
            get { return _communicationType; }
            set { _communicationType = value; OnPropertyChanged("ConnectionType"); }
        }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }

        #endregion

        #region Constructor 

        public Variable() { }

        public Variable(string name, EnumVarType type, string desc, EnumVarAccess access, string boardUn, string interfaceUn, float? linearAdjA, float? linearAdjB, float? rangeLow, float? rangeHigh, EnumVarCommunicationType comType, CultureInfo cul)
        {
            Name = name;
            Type = type;
            Description = desc;
            Access = access;
            BoardUnits = boardUn;
            InterfaceUnits = interfaceUn;
            LinearAdjustA = linearAdjA;
            LinearAdjustB = linearAdjB;
            RangeLow = rangeLow;
            RangeHigh = rangeHigh;
            CommunicationType = comType;
            Cul = cul;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que calcula el ajuste lineal que tiene que sufrir una variable para ser mostrada
        /// </summary>
        /// <returns></returns>
        public float GetLinearAdjustment(float origin)
        {
            return this.LinearAdjustA.Value*origin + this.LinearAdjustB.Value;
        }

        /// <summary>
        /// Método que válida los campos de la variable
        /// </summary>
        /// <returns>Devuelve verdadero si la variable es válida</returns>
        public bool IsAValidVariable()
        {
            //Falta: validación que sean números los rangos y los linear adjs. diferenciar por typo de variable (string o no)
            if ( Name == "" 
                || ((Type == EnumVarType.Integer || Type == EnumVarType.Float) && (RangeLow == null || RangeHigh == null)))
            {
                if (Name == "")
                {
                    Error = _res_man.GetString("ErrorNoVarName", _cul);
                }
                if ((Type == EnumVarType.Integer || Type == EnumVarType.Float) && (RangeLow == null || RangeHigh == null))
                {
                    Error = _res_man.GetString("ErrorNoVarRange", _cul);
                }

                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Miembros de INotifyPropertyChanged


        public event PropertyChangedEventHandler PropertyChanged;



        protected void OnPropertyChanged(string name)

        {

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)

            {

                handler(this, new PropertyChangedEventArgs(name));

            }

        }

        #endregion

    }
}
