using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Rad.io.Client.WinUI.Interfaces;
using RadioBrowser;
using RadioBrowser.Models;

namespace Rad.io.Client.WinUI.ViewModels
{
    public class ExploreCountriesViewModel : INotifyPropertyChanged
    {
        private readonly IRadioBrowserClient radioBrowserClient;
        private readonly INavigationService navigationService;
        private List<NameAndCount> _countries;
        private List<NameAndCount> filteredCountries;
        private NameAndCount selectedItem;
        private string entryQuery;
        private bool isLoading;

        public List<NameAndCount> Countries
        {
            get => _countries;
            set
            {
                _countries = value;
                RaisePropertyChanged();
            }
        }
        public List<NameAndCount> FilteredCountries
        {
            get
            {
                return filteredCountries;
            }
            set
            {
                if (EntryQuery is null) filteredCountries = Countries;
                else
                { 
                    filteredCountries = Countries.Where(value => value.Name.Contains(EntryQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                RaisePropertyChanged();
            }
        }

        public NameAndCount SelectedItem { get; set; }
        public string EntryQuery
        {
            get => entryQuery;
            set
            {
                entryQuery = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                RaisePropertyChanged();
            }
        }

        public ExploreCountriesViewModel(IRadioBrowserClient radioBrowserClient, INavigationService navigationService)
        {
            this.radioBrowserClient = radioBrowserClient;
            this.navigationService = navigationService;
        }

        public async Task InitializeDataAsync()
        {
            IsLoading = true;
            try
            {
                Countries = await radioBrowserClient.Lists.GetCountriesAsync();
                foreach (var result in Countries)
                {
                    Debug.WriteLine(result.Name);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

