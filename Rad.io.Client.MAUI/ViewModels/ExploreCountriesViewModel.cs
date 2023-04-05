using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Rad.io.Client.MAUI.Pages;
using RadioBrowser;
using RadioBrowser.Models;
using RadioBrowser.Net.Services;

namespace Rad.io.Client.MAUI.ViewModels
{
    public class ExploreCountriesViewModel : INotifyPropertyChanged
    {
        private readonly IRadioBrowserClient radioBrowserClient;
        private List<NameAndCount> _countries;
        private List<NameAndCount> filteredCountries;
        private string entryQuery;

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
                if (EntryQuery is null) return Countries;
                return Countries.Where(value => value.Name.Contains(EntryQuery, StringComparison.OrdinalIgnoreCase)).ToList();
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

        public ExploreCountriesViewModel(IRadioBrowserClient radioBrowserClient)
        {
            this.radioBrowserClient = radioBrowserClient;

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

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public ICommand NavigateTo => new Command(async (SelectedItem) => {
            var navParam = new Dictionary<string, object>
            {
                {"SelectedCountry", SelectedItem }
            };
            //await App.Current.MainPage.Navigation.PushAsync(new ExploreRadiosPage());
            await Shell.Current.GoToAsync($"{nameof(ExploreRadiosPage)}", navParam);
        });

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

