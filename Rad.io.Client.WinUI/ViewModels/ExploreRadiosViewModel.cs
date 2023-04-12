using RadioBrowser;
using RadioBrowser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace Rad.io.Client.WinUI.ViewModels;

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
            if (SelectedCountry == null) return;
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