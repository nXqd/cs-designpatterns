﻿using System.Windows;
using designPatterns.viewmodel;

namespace designPatterns.view
{
    /// <summary>
    /// Interaction logic for HandlerView.xaml
    /// </summary>
    public partial class HandlerView {

        private HandlerViewModel _viewModel;

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
            _viewModel = new HandlerViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// Add job when we click Add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJob(object sender, RoutedEventArgs e) {
            var output = _viewModel.AddJob();
            rtbOutput.AppendText(output);
        }
    }
}
