using RadioBrowser;
using RadioBrowser.Models;
using RadioBrowser.Net.Entities;
using RadioBrowser.Net.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;

namespace Rad.io.Client.MAUI.ViewModels;

[QueryProperty(nameof(SelectedCountry), "SelectedCountry")]
public class ExploreRadiosViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName = null)
    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private readonly IRadioBrowserClient radioBrowserClient;
    private NameAndCount selectedCountry;
    private List<StationInfo> stations;
    public List<StationInfo> Stations
    {
        get => stations;
        set
        {
            stations = value;
            RaisePropertyChanged();
        }
    }
    public NameAndCount SelectedCountry
    {
        get => selectedCountry;
        set
        {
            selectedCountry = value;
            RaisePropertyChanged();
        }
    }
    public ExploreRadiosViewModel(IRadioBrowserClient radioBrowserClient)
    {
        this.radioBrowserClient = radioBrowserClient;
    }

    public async Task InitializeData()
    {
        try
        {
            Stations = await radioBrowserClient.Search.AdvancedAsync(new AdvancedSearchOptions
            {
                Country = SelectedCountry.Name
            });
            foreach (var result in Stations)
            {
                Debug.WriteLine(result.Name);
            }

        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }
}