using Microsoft.Extensions.DependencyInjection;
using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Services;
using RadioBrowser.Net.Converters;
using System.Diagnostics;

namespace Rad.io.Client.MAUI;

public partial class MainPage : ContentPage
{
    private readonly IStationService stationService;
    int count = 0;

    public MainPage(IStationService stationService)
    {
        InitializeComponent();
        this.BindingContext = this;
        this.stationService = stationService;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        Guid guid = new Guid("98adecf7-2683-4408-9be7-02d3f9098eb8");
        var bbcStation = await stationService!.FetchByUUIDAsync(guid);
        Debug.WriteLine(bbcStation!.Name);

        RadioNameLabel.Text = bbcStation.Name;

        count++;
        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

    }

    public async Task GetRadioAsync()
    {
        Guid guid = new Guid("98adecf7-2683-4408-9be7-02d3f9098eb8");
        var bbcStation = await stationService!.FetchByUUIDAsync(guid);
        Station station = new Station();
    }
}


