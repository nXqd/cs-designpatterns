using designPatterns.model;
using designPatterns.viewmodel;

namespace designPatterns.view
{
    /// <summary>
    /// Interaction logic for WindowView.xaml
    /// </summary>
    public partial class WindowView
    {
        public WindowView()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var model = new FacadeWindowModel();
            var viewModel = new WindowViewModel(model);
            DataContext = viewModel;
        }

    }
}
