using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using designPatterns.model;

namespace designPatterns.viewmodel
{
    public class FacadeViewModel:ViewModel {

        private readonly FacadeModel _model;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FacadeViewModel() {
            Model = new FacadeModel();
            _model = (FacadeModel) Model;
        }

        /// <summary>
        /// Turn on the Home Theatre 
        /// </summary>
        /// <returns></returns>
        public string TurnOn() {
            var str = _model.TurnOn();
            OnPropertyChanged("SoundValue");
            OnPropertyChanged("LightValue");
            return str;
        }

        /// <summary>
        /// Turn off the Home Theatre
        /// </summary>
        /// <returns></returns>
        public string TurnOff() {
            var str = _model.TurnOff();
            OnPropertyChanged("SoundValue");
            OnPropertyChanged("LightValue");
            return str;
        }

        /// <summary>
        /// Inject DVD
        /// </summary>
        /// <returns></returns>
        public string DVDInject() {
            return _model.DVDInject();
        }

        /// <summary>
        /// Eject DVD
        /// </summary>
        /// <returns></returns>
        public string DVDEject() {
            return _model.DVDEject();
        }

        /// <summary>
        /// Set sound
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetSound(int value) {
            SoundValue = value;
            return _model.SetSound(value);
        }

        /// <summary>
        /// Set Light
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetLight(int value) {
            LightValue = value;
            return _model.SetLight(value);
        }

        #region Data for binding
        /// <summary>
        /// Binding SoundValue
        /// </summary>
        public int SoundValue
        {
            get { return _model.HomeTheatre.Sound.Value; }
            set
            {
                if (_model.GetSound().Equals(value)) return;
                _model.SetSound(value);
                OnPropertyChanged("SoundValue");
            }
        }  

        /// <summary>
        /// LightValue for binding
        /// </summary>
        public int LightValue
        {
            get { return _model.HomeTheatre.Light.Value; }
            set
            {
                if (_model.GetLight().Equals(value)) return;
                _model.SetLight(value);
                OnPropertyChanged("LightValue");
            }
        }  
        #endregion
    }
}
