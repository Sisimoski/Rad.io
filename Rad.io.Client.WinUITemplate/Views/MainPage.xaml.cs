using Microsoft.UI.Xaml.Controls;

using Rad.io.Client.WinUITemplate.ViewModels;

namespace Rad.io.Client.WinUITemplate.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
