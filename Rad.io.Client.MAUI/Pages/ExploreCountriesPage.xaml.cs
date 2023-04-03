using Rad.io.Client.MAUI.ViewModels;

namespace Rad.io.Client.MAUI.Pages;

public partial class ExploreCountriesPage : ContentPage
{
    private readonly ExploreCountriesViewModel viewModel;
	public ExploreCountriesPage(ExploreCountriesViewModel exploreCountriesViewModel)
	{
		InitializeComponent();
        BindingContext = exploreCountriesViewModel;
    }

    //async void CountriesList_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    //{
    //    //await Navigation.PushAsync(new ExploreRadiosPage
    //    //{
    //    //    BindingContext = e.CurrentSelection.FirstOrDefault()
    //    //});
    //    //var data = ((ExploreCountriesViewModel)BindingContext).SelectedItem;
    //    //Navigation.PushAsync(new ExploreRadiosPage
    //    //{
    //    //    BindingContext = new ExploreRadiosViewModel { SelectedCountry = data }
    //    //});
    //}
}
