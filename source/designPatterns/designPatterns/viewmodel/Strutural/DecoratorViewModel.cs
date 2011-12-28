using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using designPatterns.model.Strutural;

namespace designPatterns.viewmodel.Strutural
{
    public class DecoratorViewModel : ViewModel<DecoratorModel>
    {

        #region Properties

        public ICommand ChangeWeapon { get; set; }
        public ICommand ActivateSkill { get; set; }

        /* We should bind these elements below to
         * but it's quite expensive, so we just have their references */
        public RichTextBox ConsoleOutput { get; set; }
        public Image ImgWeapon { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor from base class
        /// </summary>
        /// <param name="model"></param>
        public DecoratorViewModel(DecoratorModel model) : base(model) {
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DecoratorViewModel() {
            Model = new DecoratorModel();
            SpecialSkillButtonText = "Bật kĩ năng đặc biệt";

            // Create Commands
            ChangeWeapon = new Command {
                                           CanExcuteDelegate = x => true,
                                           ExecuteDelegate = x => {

                                                                 ConsoleOutput.AppendText(Model.ChangeWeapon());
                                                                 OnPropertyChanged("HaveSpecialSkill");

                                                                 // set sword picture
                                                                 var swordName = Model.MyCharacter.WeaponName;
                                                                 var uriSource =
                                                                     new Uri(
                                                                         @"/designPatterns;component/public/images/" +
                                                                         swordName + ".png", UriKind.Relative);
                                                                 ImgWeapon.Source = new BitmapImage(uriSource);
                                                             }
                                       };
            ActivateSkill = new Command {
                                            CanExcuteDelegate = x => HaveSpecialSkill,
                                            ExecuteDelegate = x => {
                                                                  if (Model.IsSkillActivated()) {
                                                                      ConsoleOutput.AppendText(Model.UnActivateSpecialSkill());
                                                                      SpecialSkillButtonText = "Bật kĩ năng đặc biệt";
                                                                  }
                                                                  else {
                                                                      ConsoleOutput.AppendText(Model.ActivateSpecialSkill());
                                                                      SpecialSkillButtonText = "Tắt kĩ năng đặc biệt";
                                                                  }

                                                                  OnPropertyChanged("DefenseValue");
                                                                  OnPropertyChanged("AttackValue");
                                                                  OnPropertyChanged("SpecialSkillButtonText");
                                                              }
                                        };

        }

        #endregion

        #region Data for binding

        /// <summary>
        /// User Attack value
        /// </summary>
        public float AttackValue {
            get { return Model.GetAttackValue(); }
        }  

        /// <summary>
        /// User Defense Value
        /// </summary>
        public float DefenseValue {
            get { return Model.GetDefenseValue(); }
        }

        /// <summary>
        /// Check if this user has a special skill to use
        /// </summary>
        public bool HaveSpecialSkill {
            get { return Model.HaveSpecialSkill(); }
        }

        public string SpecialSkillButtonText { get; set; }
        #endregion
    }
}
