using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Rad.io.Client.MAUI.ViewModels;

public class ExploreRadiosViewModel : INotifyPropertyChanged
{
    private readonly IStationService stationService;
    private readonly ICountryService countryService;

    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public IEnumerable<Country> Countries { get; set; }

    public ExploreRadiosViewModel(IStationService stationService, ICountryService countryService)
    {
        this.stationService = stationService;
        this.countryService = countryService;

        InitializeData();
        
    }

    async void InitializeData()
    {
        Countries = await countryService.FetchAsync();
        foreach (Country country in Countries)
        {
            Debug.WriteLine(country.Name);
        }
    }
}