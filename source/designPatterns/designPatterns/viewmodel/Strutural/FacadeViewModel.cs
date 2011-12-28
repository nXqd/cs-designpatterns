using designPatterns.model;

namespace designPatterns.viewmodel
{
    public class FacadeViewModel:ViewModel<FacadeModel>{

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FacadeViewModel() {
            Model = new FacadeModel();
        }

        /// <summary>
        /// Turn on the Home Theatre 
        /// </summary>
        /// <returns></returns>
        public string TurnOn() {
            var str = Model.TurnOn();
            OnPropertyChanged("SoundValue");
            OnPropertyChanged("LightValue");
            return str;
        }

        /// <summary>
        /// Turn off the Home Theatre
        /// </summary>
        /// <returns></returns>
        public string TurnOff() {
            var str = Model.TurnOff();
            OnPropertyChanged("SoundValue");
            OnPropertyChanged("LightValue");
            return str;
        }

        /// <summary>
        /// Inject DVD
        /// </summary>
        /// <returns></returns>
        public string DVDInject() {
            return Model.DVDInject();
        }

        /// <summary>
        /// Eject DVD
        /// </summary>
        /// <returns></returns>
        public string DVDEject() {
            return Model.DVDEject();
        }

        /// <summary>
        /// Set sound
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetSound(int value) {
            SoundValue = value;
            return Model.SetSound(value);
        }

        /// <summary>
        /// Set Light
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SetLight(int value) {
            LightValue = value;
            return Model.SetLight(value);
        }

        #region Data for binding
        /// <summary>
        /// Binding SoundValue
        /// </summary>
        public int SoundValue
        {
            get { return Model.HomeTheatre.Sound.Value; }
            set
            {
                if (Model.GetSound().Equals(value)) return;
                Model.SetSound(value);
                OnPropertyChanged("SoundValue");
            }
        }  

        /// <summary>
        /// LightValue for binding
        /// </summary>
        public int LightValue
        {
            get { return Model.HomeTheatre.Light.Value; }
            set
            {
                if (Model.GetLight().Equals(value)) return;
                Model.SetLight(value);
                OnPropertyChanged("LightValue");
            }
        }  
        #endregion
    }
}
