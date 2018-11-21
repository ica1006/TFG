﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PlantaPiloto
{
    class Proyect
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

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged("Description"); }
        }

        private Image _imagePath;

        public Image ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; OnPropertyChanged("ImagePath"); }
        }

        private ObservableCollection<Variable> _variables;

        public ObservableCollection<Variable> Variables
        {
            get { return _variables; }
            set { _variables = value; OnPropertyChanged("Variables"); }
        }

        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }

        #endregion

        #region Constructor

        public Proyect()
        {
            Variables = new ObservableCollection<Variable>();
        }

        public Proyect(string name, string desc, Image imgPath)
        {
            Name = name;
            Description = desc;
            ImagePath = imgPath;
            Variables = new ObservableCollection<Variable>();
        }

        #endregion

        #region Methods

        public bool IsAValidProyect()
        {
            if (Name == null)
            {
                Error = _res_man.GetString("ErrorNoProyectName", _cul);
                return false;
            }
            else
                return true;
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