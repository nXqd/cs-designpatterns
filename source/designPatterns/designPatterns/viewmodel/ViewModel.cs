using System;
using System.ComponentModel;
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

    /// <summary>
    /// Use Generic
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class ViewModel<TModel> : PropertyChangedBase where TModel : Model, new()
    {
        public TModel Model { get; set; }

        public ViewModel(TModel model)
        {
            Model = model;
        }

        protected ViewModel() {
            Model = new TModel();
        }

        #region Get data for binding

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
