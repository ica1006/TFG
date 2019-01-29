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
    public class Variable
    {

        #region Properties

        private CultureInfo _cul;

        public CultureInfo Cul
        {
            get { return _cul; }
            set
            {
                _cul = value; OnPropertyChangedVariable("Cul");
            }
        }

        private string _name;

        /// <summary>
        /// Nombre de la variable
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChangedVariable("Name"); }
        }

        private EnumVarType _type;

        /// <summary>
        /// Tipo de variable
        /// </summary>
        public EnumVarType Type
        {
            get { return _type; }
            set { _type = value; OnPropertyChangedVariable("Type"); }
        }

        private string _description;

        /// <summary>
        /// Descripción de la variable
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChangedVariable("Description"); }
        }

        private EnumVarAccess _access;

        /// <summary>
        /// Tipo de acceso a la variable
        /// </summary>
        public EnumVarAccess Access
        {
            get { return _access; }
            set { _access = value; OnPropertyChangedVariable("Access"); }
        }

        private string _boardUnits;

        /// <summary>
        /// Unidades en las que se trabaja en la placa
        /// </summary>
        public string BoardUnits
        {
            get { return _boardUnits; }
            set { _boardUnits = value; OnPropertyChangedVariable("BoardUnits"); }
        }

        private string _interfaceUnits;

        /// <summary>
        /// Unidades en las que se trabaja en la interfaz
        /// </summary>
        public string InterfaceUnits
        {
            get { return _interfaceUnits; }
            set { _interfaceUnits = value; OnPropertyChangedVariable("InterfaceUnits"); }
        }

        private float? _linearAdjustA;

        /// <summary>
        /// Argumento "a" de la fórmula de ajuste linear entre las unidades de la placa y las de la interfaz
        /// </summary>
        public float? LinearAdjustA
        {
            get { return _linearAdjustA; }
            set { _linearAdjustA = value; OnPropertyChangedVariable("LinearAdjustA"); }
        }

        private float? _linearAdjustB;

        /// <summary>
        /// Argumento "b"de la fórmula de ajuste linear entre las unidades de la placa y las de la interfaz
        /// </summary>
        public float? LinearAdjustB
        {
            get { return _linearAdjustB; }
            set { _linearAdjustB = value; OnPropertyChangedVariable("LinearAdjustB"); }
        }

        private float? _rangeLow;

        /// <summary>
        /// Valor mínimo que puede alcanzar la variable
        /// </summary>
        public float? RangeLow
        {
            get { return _rangeLow; }
            set { _rangeLow = value; OnPropertyChangedVariable("RangeLow"); }
        }

        private float? _rangeHigh;

        /// <summary>
        /// Valor máximo que puede alcanzar la variable
        /// </summary>
        public float? RangeHigh
        {
            get { return _rangeHigh; }
            set { _rangeHigh = value; OnPropertyChangedVariable("RangeHigh"); }
        }

        private EnumVarCommunicationType _communicationType;

        /// <summary>
        /// Tipo de conexión que utiliza la variable
        /// </summary>
        public EnumVarCommunicationType CommunicationType
        {
            get { return _communicationType; }
            set { _communicationType = value; OnPropertyChangedVariable("ConnectionType"); }
        }

        private string _value;

        /// <summary>
        /// Valor de la variable
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChangedVariable("Value"); }
        }

        private int? _boardMoment;

        /// <summary>
        /// Propiedad que almacena el momento en el que se definió la variable
        /// </summary>
        public int? BoardMoment
        {
            get { return _boardMoment; }
            set { _boardMoment = value; OnPropertyChangedVariable("Time"); }
        }

        #endregion

        #region Constructor 

        public Variable() { }

        public Variable(string name, EnumVarType type, string desc, EnumVarAccess access, 
            string boardUn, string interfaceUn, float? linearAdjA, float? linearAdjB, 
            float? rangeLow, float? rangeHigh, EnumVarCommunicationType comType, string value,
            int? time, CultureInfo cul)
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
            Value = value;
            BoardMoment = time;
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

        #endregion

        #region Miembros de INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Método que actualiza la propiedad cuando esta cambia
        /// </summary>
        /// <param name="name">Propiedad a actualizar</param>
        protected void OnPropertyChangedVariable(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
