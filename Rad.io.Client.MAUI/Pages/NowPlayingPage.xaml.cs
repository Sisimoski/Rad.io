using Rad.io.Client.MAUI.ViewModels;
using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Services;
using System.Diagnostics;

namespace Rad.io.Client.MAUI.Pages;

public partial class NowPlayingPage : ContentPage
{
    private readonly IStationService stationService;
    NowPlayingViewModel vm;

    public NowPlayingPage(IStationService stationService)
    {
        InitializeComponent();
        vm = new NowPlayingViewModel();
        this.stationService = stationService;
        GetStation();
        this.BindingContext = vm;
    }

    async void GetStation()
    {
        Guid guid = new("98adecf7-2683-4408-9be7-02d3f9098eb8");

        Station station = await stationService.FetchByUUIDAsync(guid);
        vm.Name = station.Name;
        Debug.WriteLine(vm.Name);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        GetStation();
    }
}