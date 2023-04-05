using Rad.io.Client.MAUI.Pages;
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
using System.Windows.Input;

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
    private List<StationInfo> filteredStations;
    private string entryQuery;

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

    public string EntryQuery
    {
        get => entryQuery;
        set
        {
            entryQuery = value;
            RaisePropertyChanged();
        }
    }
    public List<StationInfo> FilteredStations
    {
        get
        {
            if (entryQuery is null) return Stations;
            return Stations.Where(value => value.Name.Contains(EntryQuery, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
    public ExploreRadiosViewModel(IRadioBrowserClient radioBrowserClient)
    {
        this.radioBrowserClient = radioBrowserClient;
    }

    public async Task InitializeDataAsync()
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

    public ICommand NavigateTo => new Command(async (value) => {
        var navParam = new Dictionary<string, object>
            {
                {"CurrentStation", value }
            };
        await Shell.Current.GoToAsync($"{nameof(NowPlayingPage)}", false, navParam);
    });
}