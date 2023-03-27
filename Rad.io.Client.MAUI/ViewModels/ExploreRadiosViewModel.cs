using RadioBrowser;
using RadioBrowser.Models;
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
    private readonly IRadioBrowserClient radioBrowserClient;
    private List<NameAndCount> _countries;
    public List<NameAndCount> Countries
    {
        get => _countries;
        set
        {
            _countries = value;
            RaisePropertyChanged();
        }
    }

    private readonly IStationService stationService;
    private readonly ICountryService countryService;

    public event PropertyChangedEventHandler PropertyChanged;

    public ExploreRadiosViewModel()
    {
    }

    public ExploreRadiosViewModel(IRadioBrowserClient radioBrowserClient, IStationService stationService, ICountryService countryService)
    {
        this.radioBrowserClient = radioBrowserClient;
        this.stationService = stationService;
        this.countryService = countryService;

        InitializeDataAsync();
    }

    private async Task InitializeDataAsync()
    {
        try
        {
            Countries = await radioBrowserClient.Lists.GetCountriesAsync();
            foreach (var result in Countries)
            {
                Debug.WriteLine(result.Name);
            }

        } catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    protected void RaisePropertyChanged(string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}