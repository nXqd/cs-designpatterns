using System.Windows;
using designPatterns.model;
using designPatterns.model.Behavioural;
using designPatterns.viewmodel;

namespace designPatterns.view
{
    /// <summary>
    /// Interaction logic for HandlerView.xaml
    /// </summary>
    public partial class HandlerView {

        private Model _model;
        private ViewModel _viewModel;

        public HandlerView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Init Some data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowLoaded(object sender, RoutedEventArgs e) {
            _model = new HandlerModel();
            _viewModel = new HandlerViewModel(_model);
            DataContext = _viewModel;
        }

        /// <summary>
        /// Add job when we click Add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJob(object sender, RoutedEventArgs e) {
            var viewModel = (HandlerViewModel) _viewModel;
            var output = viewModel.AddJob();
            rtbOutput.AppendText(output);
        }
    }
}
