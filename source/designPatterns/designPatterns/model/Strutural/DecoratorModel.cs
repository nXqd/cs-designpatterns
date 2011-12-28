/* Decorator design pattern */

using System;

namespace designPatterns.model.Strutural
{
    public class DecoratorModel : Model
    {

        public Character MyCharacter { get; set; }

        public DecoratorModel() {
            Description = "Decorator Pattern";
            MyCharacter = new Character();
        }

        /// <summary>
        /// UnActivate skil
        /// </summary>
        /// <returns></returns>
        public string UnActivateSpecialSkill() {
            return MyCharacter.UnActivateWeaponSpecialSkill();
        }

        /// <summary>
        /// Check if skill is activated
        /// </summary>
        /// <returns></returns>
        public bool IsSkillActivated() {
            return MyCharacter.IsSkillActivated();
        }

        /// <summary>
        /// Change weapon
        /// </summary>
        /// <returns></returns>
        public string ChangeWeapon() {
            return MyCharacter.ChangeWeapon();
        }

        /// <summary>
        /// Activate Special Skill
        /// </summary>
        public string ActivateSpecialSkill() {
            return MyCharacter.ActivateWeaponSpecialSkill();
        }

        /// <summary>
        /// Check if the weapon have special skill
        /// </summary>
        /// <returns></returns>
        public bool HaveSpecialSkill() {
            return MyCharacter.HaveSpecialSkill();
        }

        /// <summary>
        /// Get Attack Value
        /// </summary>
        /// <returns></returns>
        public float GetAttackValue() {
            return MyCharacter.Attack;
        }

        /// <summary>
        /// Get Defense valuej
        /// </summary>
        /// <returns></returns>
        public float GetDefenseValue() {
            return MyCharacter.Defense;
        }
        #region Decorator pattern code behind
        
        /// <summary>
        /// Legacy Item
        /// </summary>
        public class GameItem {
            #region Properties
            public float Damage { get; set; }
            public float Defense { get; set; }
            #endregion

            public GameItem(GameItem item) {
                Damage = item.Damage;
                Defense = item.Defense;
            }

            public GameItem() {
                Damage  = 300;
                Defense = 300;
            }
        }

        /// <summary>
        /// **Decorator**
        /// New God Item with the ability to activate the strength of God
        /// </summary>
        public class GodGameItem: GameItem {

            public bool SkillActivated { get; set; }

            #region Constructor
            public GodGameItem(GameItem item) : base(item) {
            }
            #endregion

            /// <summary>
            /// Activate special skill
            /// </summary>
            /// <returns></returns>
            public string ActivateWeaponSpecialSkill()
            {
                Damage += 200;
                Defense -= 200;
                SkillActivated = true;

                return "Sức mạnh của chúa được bật ! " + Environment.NewLine +
                    "Sức mạnh tăng 200" + Environment.NewLine +
                    "Phòng thủ giảm 200" + Environment.NewLine;
            }

            /// <summary>
            /// UnActivate special skill
            /// </summary>
            /// <returns>the log to write out to console output</returns>
            public string UnActivateSpecialSkill() {
                Damage -= 200;
                Defense += 200;
                SkillActivated = false;

                return "Sức mạnh của chúa được tắt ! " + Environment.NewLine +
                    "Sức mạnh giảm 200" + Environment.NewLine +
                    "Phòng thủ tăng 200" + Environment.NewLine;
            }

        }

        public class Character {

            public GameItem Item { get; set; }
            public float Defense {get { return Item.Defense; }}
            public float Attack { get { return Item.Damage; } }
            public string WeaponName { get { return Item.GetType().Name; }}

            public Character() {
                Item = new GameItem();
            }

            /// <summary>
            /// Change weapon
            /// </summary>
            /// <returns></returns>
            public string ChangeWeapon() {
                string str;

                // Check and change weaponj
                if (Item.GetType().Name.Equals("GameItem")) {
                    str  = "Vũ khí đã được nâng cấp thành kiếm chúa" + Environment.NewLine;
                    Item = new GodGameItem(Item);
                }
                else {
                    str  = "Vũ khí đã bị xuống cấp thành kiếm thường" + Environment.NewLine;
                    Item = new GameItem(Item);
                }
                return str;
            }

            /// <summary>
            /// Activate Special Skill of current item
            /// </summary>
            /// <returns></returns>
            public string ActivateWeaponSpecialSkill() {
                return ((GodGameItem) Item).ActivateWeaponSpecialSkill();
            }

            /// <summary>
            /// Activate Special Skill of current item
            /// </summary>
            /// <returns></returns>
            public string UnActivateWeaponSpecialSkill() {
                return ((GodGameItem) Item).UnActivateSpecialSkill();
            }

            /// <summary>
            /// Check if user have special skill
            /// It may be from a weapon
            /// </summary>
            /// <returns></returns>
            public bool HaveSpecialSkill() {
                return !Item.GetType().Name.Equals("GameItem");
            }

            /// <summary>
            /// Check if a skill is activated
            /// </summary>
            /// <returns></returns>
            public bool IsSkillActivated() {
                var item = (GodGameItem) Item;
                return item.SkillActivated;
            }
        }

        #endregion

    }
}
