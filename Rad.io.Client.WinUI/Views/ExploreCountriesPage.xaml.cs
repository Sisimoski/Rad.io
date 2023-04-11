using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Rad.io.Client.WinUI.ViewModels;
using RadioBrowser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Rad.io.Client.WinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExploreCountriesPage : Page
    {
        public ExploreCountriesViewModel CountriesViewModel { get; set; }
        public ExploreCountriesPage()
        {
            this.InitializeComponent();
            this.CountriesViewModel = App.Current.Services.GetService<ExploreCountriesViewModel>();
            this.DataContext = CountriesViewModel;
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await CountriesViewModel.InitializeDataAsync();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CountriesViewModel.SelectedItem = (RadioBrowser.Models.NameAndCount)CountriesListView.SelectedItem;
            //this.Frame.Navigate(typeof(ExploreRadiosPage), CountriesViewModel.SelectedItem);
        }

        private void CountriesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            NameAndCount selectedItem = e.ClickedItem as NameAndCount;
            App.ContentFrame.Navigate(typeof(ExploreRadiosPage), selectedItem);
        }
    }
}
