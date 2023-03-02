using Rad.io.Client.MAUI.ViewModels;
using System.Diagnostics;

namespace Rad.io.Client.MAUI.Pages;

public partial class ExploreRadiosPage : ContentPage
{
    public ExploreRadiosPage(ExploreRadiosViewModel radiosViewModel)
    {
        InitializeComponent();
        BindingContext = radiosViewModel;
    }
}
