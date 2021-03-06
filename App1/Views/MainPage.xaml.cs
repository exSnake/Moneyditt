﻿using Windows.UI.Xaml.Controls;
using App1.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            viewModel = new MainViewModel();
        }

        private MainViewModel viewModel { get; set; }
    }
}
