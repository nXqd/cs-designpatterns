/* Decorator design pattern */
namespace designPatterns.model.Strutural
{
    public class DecoratorWindowModel : WindowModel
    {
        public DecoratorWindowModel(string desc) : base(desc)
        {
        }

        #region Decorator pattern
        
        /// <summary>
        /// Legacy GameItem
        /// </summary>
        public class GameItem {
            public float Endurance { get; set; }
            public float Damage { get; set; }
            public float Defense { get; set; }
        }

        /// <summary>
        /// **Decorator**
        /// New God Item with the ability to activate the strength of God
        /// </summary>
        public class GodGameItem: GameItem {

            private readonly GameItem _item;

            public GodGameItem(GameItem item) {
                _item = item;
            }

            /// <summary>
            /// Decorate the old item with new ability
            /// </summary>
            /// <returns>the log to write out to console output</returns>
            public string ActivateGodStrength() {
                _item.Damage += 200;
                _item.Defense -= 200;

                return "God mode activated\n Damage increases 200 \n Defense decreases 200";
            }
        }
        #endregion
    }
}
