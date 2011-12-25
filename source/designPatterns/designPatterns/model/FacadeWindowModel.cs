namespace designPatterns.model
{
    public class FacadeWindowModel : Model
    {
        public FacadeWindowModel()
        {
        }

        #region Facade code behind
        /* To simplify our home theatre system for noob, we use facade pattern*/

        public class HomeTheatre {
        }

        #region Elements of a HomeTheatre
        public class SoundSystem {
            public int Volume { get; set; }

            public void Increase() {
                Volume += 10;
            }

            public void Decrease() {
                if (Volume >= 10)
                    Volume -= 10;
            }
        }

        public class LightSystem {
            public int LightPercent { get; set; }
        }
        #endregion

        #endregion

    }
}
