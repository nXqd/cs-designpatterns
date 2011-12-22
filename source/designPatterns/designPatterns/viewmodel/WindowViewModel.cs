using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using designPatterns.model;

namespace designPatterns.viewmodel
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        private readonly WindowModel _model;

        public WindowViewModel(WindowModel model)
        {
            _model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public String ConsoleOutput { 
            get { return _model.ConsoleOutput; }
            set {
                if (_model.ConsoleOutput == value) return;
                _model.ConsoleOutput = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("ConsoleOutput"));
            }
        }

        public String Description { 
            get { return _model.Description; }
            set {
                if (_model.Description == value) return;
                _model.Description = value;
                if (PropertyChanged == null) return;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

    }
}
