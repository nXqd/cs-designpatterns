using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using designPatterns.model;

namespace designPatterns.viewmodel
{
    public abstract class PropertyChangedBase: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public abstract class ViewModel : PropertyChangedBase
    {
        protected Model Model;

        public ViewModel(Model model)
        {
            Model = model;
        }

        protected ViewModel() {
        }

        #region Get data for binding

        public String ConsoleOutput { 
            get { return Model.ConsoleOutput; }
            set {
                if (Model.ConsoleOutput == value) return;
                Model.ConsoleOutput = value;
                OnPropertyChanged("ConsoleOutput");
            }
        }

        public String Description { 
            get { return Model.Description; }
            set {
                if (Model.Description == value) return;
                Model.Description = value;
                OnPropertyChanged("Description");
            }
        }
        #endregion

    }
}
