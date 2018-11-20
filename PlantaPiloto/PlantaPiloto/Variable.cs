using System;
using System.Collections.Generic;
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
                _cul = value;
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _access;

        public string Access
        {
            get { return _access; }
            set { _access = value; }
        }

        private string _boardUnits;

        public string BoardUnits
        {
            get { return _boardUnits; }
            set { _boardUnits = value; }
        }

        private string _interfaceUnits;

        public string InterfaceUnits
        {
            get { return _interfaceUnits; }
            set { _interfaceUnits = value; }
        }

        private float? _linearAdjustA;

        public float? LinearAdjustA
        {
            get { return _linearAdjustA; }
            set { _linearAdjustA = value; }
        }

        private float? _linearAdjustB;

        public float? LinearAdjustB
        {
            get { return _linearAdjustB; }
            set { _linearAdjustB = value; }
        }

        private float? _rangeLow;

        public float? RangeLow
        {
            get { return _rangeLow; }
            set { _rangeLow = value; }
        }

        private float? _rangeHigh;

        public float? RangeHigh
        {
            get { return _rangeHigh; }
            set { _rangeHigh = value; }
        }

        private string _connectionType;

        public string ConnectionType
        {
            get { return _connectionType; }
            set { _connectionType = value; }
        }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }


        #endregion

        #region Constructor 

        public Variable() { }

        public Variable(string name, string type, string desc, string access, string boardUn, string interfaceUn, float? linearAdjA, float? linearAdjB, float? rangeLow, float? rangeHigh, string conType, CultureInfo cul)
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
            ConnectionType = conType;
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
            if ( Name == null 
                || Type == null
                || Access == null
                || ConnectionType == null
                || ((Type == "int" || Type == "float") && (RangeLow == null || RangeHigh == null)))
            {
                if (Name == null)
                {
                    Error = _res_man.GetString("ErrorNoVarName", _cul);
                }
                if (Type == null)
                {
                    Error = _res_man.GetString("ErrorNoVarType", _cul);
                }
                if (Access == null)
                {
                    Error = _res_man.GetString("ErrorNoVarAccess", _cul);
                }
                if (ConnectionType == null)
                {
                    Error = _res_man.GetString("ErrorNoVarConnectionType", _cul);
                }
                if ((Type == "int" || Type == "float") && (RangeLow == null || RangeHigh == null))
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


    }
}
