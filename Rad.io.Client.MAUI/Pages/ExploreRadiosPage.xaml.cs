using Rad.io.Client.MAUI.ViewModels;
using System.Diagnostics;

namespace Rad.io.Client.MAUI.Pages;

public partial class ExploreRadiosPage : ContentPage
{
    private readonly ExploreRadiosViewModel exploreRadiosViewModel;
    public ExploreRadiosPage(ExploreRadiosViewModel exploreRadiosViewModel)
    {
        InitializeComponent();
        this.exploreRadiosViewModel = exploreRadiosViewModel;
        BindingContext = exploreRadiosViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        exploreRadiosViewModel.InitializeData();
    }
}
