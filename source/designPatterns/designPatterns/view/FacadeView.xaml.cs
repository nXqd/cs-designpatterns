using System;
using System.Windows.Controls;
using designPatterns.model;
using designPatterns.viewmodel;

namespace designPatterns.view
{
    /// <summary>
    /// Interaction logic for FacadeView.xaml
    /// </summary>
    public partial class FacadeView {

        private FacadeViewModel _viewModel;

        public FacadeView() {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel = new FacadeViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// Click Turn On button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnOn(object sender, System.Windows.RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.TurnOn());
        }

        /// <summary>
        /// Click Turn off button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnOff(object sender, System.Windows.RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.TurnOff());
        }

        private void DVDInject(object sender, System.Windows.RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.DVDInject());
        }

        private void DVDEject(object sender, System.Windows.RoutedEventArgs e)
        {
            rtbOutput.AppendText(_viewModel.DVDEject());
        }

        private void SetSound(object sender, System.Windows.RoutedEventArgs e) {
            var value = Convert.ToInt32(txtSoundValue.Text);
            var output = _viewModel.SetSound(value);
            rtbOutput.AppendText(output);
        }

        private void SetLight(object sender, System.Windows.RoutedEventArgs e) {
            var value = Convert.ToInt32(txtLightValue.Text);
            var output = _viewModel.SetLight(value);
            rtbOutput.AppendText(output);
        }


    }
}
