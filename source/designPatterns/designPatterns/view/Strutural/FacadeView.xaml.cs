using System;
using System.Windows;
using designPatterns.viewmodel;

namespace designPatterns.view
{
    /// <summary>
    /// Interaction logic for FacadeView.xaml
    /// </summary>
    public partial class FacadeView {

        #region Prperties
        private FacadeViewModel _viewModel;
        
        #endregion
        public FacadeView() {
            InitializeComponent();
        }

        /// <summary>
        /// Initialization when window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = new FacadeViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// Click Turn On button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnOn(object sender, RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.TurnOn());
        }

        /// <summary>
        /// Click Turn off button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnOff(object sender, RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.TurnOff());
        }

        /// <summary>
        /// Eject the DVD and append output text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DVDInject(object sender, RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.DVDInject());
        }

        /// <summary>
        /// Inject the DVD and append output text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DVDEject(object sender, RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.DVDEject());
        }

        /// <summary>
        /// Set sound value for the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSound(object sender, RoutedEventArgs e) {
            var value = Convert.ToInt32(txtSoundValue.Text);
            var output = _viewModel.SetSound(value);
            rtbOutput.AppendText(output);
        }

        /// <summary>
        /// Set light value for the system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetLight(object sender, RoutedEventArgs e) {
            var value = Convert.ToInt32(txtLightValue.Text);
            var output = _viewModel.SetLight(value);
            rtbOutput.AppendText(output);
        }


    }
}
