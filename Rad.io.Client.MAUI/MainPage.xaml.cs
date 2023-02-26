using Microsoft.Extensions.DependencyInjection;
using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Services;
using RadioBrowser.Net.Converters;

namespace Rad.io.Client.MAUI;

public partial class MainPage : ContentPage
{
    private readonly IStationService stationService;
    int count = 0;

    public MainPage()
    {
        //this.stationService = stationService;
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}


