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
using System.Diagnostics;
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
    public sealed partial class ExploreRadiosPage : Page
    {
        public ExploreRadiosViewModel ExploreRadiosViewModel { get; set; }
        public NowPlayingViewModel NowPlayingViewModel { get; set; }
        public ExploreRadiosPage()
        {
            this.InitializeComponent();
            this.ExploreRadiosViewModel = App.Current.Services.GetService<ExploreRadiosViewModel>();
            this.NowPlayingViewModel = App.Current.Services.GetService<NowPlayingViewModel>();
            this.DataContext = ExploreRadiosViewModel;
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            ExploreRadiosViewModel.SelectedCountry = e.Parameter as NameAndCount;
            base.OnNavigatedTo(e);
            //await ExploreRadiosViewModel.InitializeDataAsync();
        }

        private void RadiosListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NowPlayingViewModel.CurrentStation = (RadioBrowser.Models.StationInfo)RadiosListView.SelectedItem;
            Debug.WriteLine(RadiosListView.SelectedItem.ToString());
            Debug.WriteLine(NowPlayingViewModel.CurrentStation.Url);
            Debug.WriteLine(NowPlayingViewModel.CurrentStation.Url.AbsoluteUri);
            NowPlayingViewModel.ShowUrl();
        }
    }
}
