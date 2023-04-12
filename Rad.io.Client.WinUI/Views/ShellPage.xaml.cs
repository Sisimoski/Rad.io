using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Rad.io.Client.WinUI.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Rad.io.Client.WinUI.Views;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ShellPage : Page
{
    public ShellViewModel ShellViewModel { get; set; }
    public NowPlayingViewModel NowPlayingViewModel { get; set; }
    public ShellPage()
    {
        this.ShellViewModel = App.Current.Services.GetService<ShellViewModel>();
        this.NowPlayingViewModel = App.Current.Services.GetService<NowPlayingViewModel>();
        
        this.InitializeComponent();

        RootFrame.Content = new ExploreCountriesPage();
    }

    private void PlayButton_Click(object sender, RoutedEventArgs e)
    {
        NowPlayingViewModel.ShowUrl();
        MediaPlayerElement.Source = MediaSource.CreateFromUri(NowPlayingViewModel.CurrentStation.Url);
        MediaPlayerElement.MediaPlayer.Play();
    }

    private void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        switch (args.InvokedItemContainer.Tag)
        {
            case "Explore":
                RootFrame.Navigate(typeof(ExploreCountriesPage));
                break;
            case "Library":
                RootFrame.Navigate(typeof(LibraryPage));
                break;
            case "Now Playing":
                break;
        }
    }
    private void NavigationViewControl_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        var item = (NavigationViewItem)args.SelectedItem;
        if ((string)item.Tag == "Explore")
        {
            RootFrame.Navigate(typeof(ExploreCountriesPage));
        }
    }

    private void NavigationViewControl_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        if (RootFrame.CanGoBack)
        {
            RootFrame.GoBack();
        }
    }

    private void NavigationViewControl_Loaded(object sender, RoutedEventArgs e)
    {
        NavigationViewControl.SelectedItem = NavigationViewControl.MenuItems[1];
    }
}
