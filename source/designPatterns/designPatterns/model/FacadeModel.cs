using System;

namespace designPatterns.model
{
    public class FacadeModel : Model {

        public HomeTheatre HomeTheatre { get; set; }

        public FacadeModel() {
            Description = "Facade Model";
            HomeTheatre = new HomeTheatre();
        }

        public string TurnOn() {
            return "#Turn on with default settings" + Environment.NewLine + HomeTheatre.TurnOn();
        }

        public string TurnOff() {
            return "#Turn off whole system" + Environment.NewLine + HomeTheatre.TurnOff();
        }

        public string DVDInject() {
            return HomeTheatre.DVDPlayer.Inject();
        }

        public string DVDEject() {
            return HomeTheatre.DVDPlayer.Eject();
        }

        public string SetSound(int value) {
            return HomeTheatre.Sound.Set(value);
        }

        public int GetSound() {
            return HomeTheatre.Sound.Value;
        }

        public string SetLight(int value) {
            return HomeTheatre.Light.Set(value);
        }

        public int GetLight() {
            return HomeTheatre.Light.Value;
        }


    }

    #region Facade code behind
        /* To simplify our home theatre system for noob, we use facade pattern*/

        public class HomeTheatre {
            public DVDPlayer DVDPlayer { get; set; }
            public Sound Sound { get; set; }
            public Light Light { get; set; }

            public HomeTheatre() {
                DVDPlayer = new DVDPlayer();
                Sound = new Sound();
                Light = new Light();
            }

            /// <summary>
            /// Turn the whole system on
            /// </summary>
            public string TurnOn() {
                var res = DVDPlayer.Inject();
                res += Sound.Set(80);
                res += Light.Set(70);
                return res;
            }

            /// <summary>
            /// Turn off the whole system
            /// </summary>
            /// <returns>log string to output</returns>
            public string TurnOff() {
                var res = DVDPlayer.Eject();
                res += Sound.Set(0);
                res += Light.Set(0);
                return res;
            }

        }

    }

        #region Elements of a HomeTheatre

        /// <summary>
        /// DVD Player: One of Home Theatre component
        /// </summary>
        public class DVDPlayer {
            /// <summary>
            /// Inject DVD to system
            /// </summary>
            /// <returns></returns>
             public string Inject() {
                 return "Inject DVD" + Environment.NewLine;
             }

            /// <summary>
            /// Eject DVD out of system
            /// </summary>
            /// <returns></returns>
             public string Eject() {
                 return "Eject DVD" + Environment.NewLine;
             }
        }

        /// <summary>
        /// Interface for common Component of Home Theatre
        /// </summary>
        public abstract class Component {
            public int Value { get; private set; }

            /// <summary>
            /// Set specific value
            /// </summary>
            /// <param name="value">intput value</param>
            /// <returns></returns>
            public virtual string Set(int value) {
                Value = value;
                return GetType().Name + " is at " + Value + Environment.NewLine;
            }

            /// <summary>
            ///  Increase a value
            ///  </summary><returns></returns>
            public virtual string Increase() {
                if (Value <= 90) {
                    Value += 10;
                } else {
                    Value = 100;
                }
                return "Increase " + GetType().Name + " 10: " + Value;
            }

            /// <summary>
            ///  Decrease a value
            ///  </summary><returns></returns>
            public virtual string Decrease() {
                if (Value >= 10) {
                    Value -= 10;
                } else {
                    Value = 0;
                }
                return "Decrease "+ GetType().Name +" 10: " + Value;
            }
        }

        /// <summary>
        /// Sound system: One of Home Theatre component
        /// </summary>
        public class Sound:Component {
        }

        /// <summary>
        /// Light System: One of Home Theatre component
        /// </summary>
        public class Light:Component {
        }

        #endregion

        #endregion
