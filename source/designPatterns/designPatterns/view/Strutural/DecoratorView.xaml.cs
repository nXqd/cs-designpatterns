using System.Windows;
using designPatterns.viewmodel.Strutural;

namespace designPatterns.view.Strutural
{
    /// <summary>
    /// Interaction logic for DecoratorView.xaml
    /// </summary>
    public partial class DecoratorView
    {
        #region Properties

        private DecoratorViewModel _viewModel;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public DecoratorView()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Initialization some default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowLoaded(object sender, RoutedEventArgs e) {
            _viewModel = new DecoratorViewModel();
            _viewModel.ConsoleOutput = rtbOutput;
            _viewModel.ImgWeapon = imgWeapon;
            DataContext = _viewModel;
        }
    }
}
