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
        private NameAndCount selectedItem;
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
        public NameAndCount SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
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

        public ICommand NavigateTo => new Command(() => {
            var navParam = new Dictionary<string, object>
            {
                {"SelectedCountry", SelectedItem }
            };
            Shell.Current.GoToAsync($"{nameof(ExploreRadiosPage)}", navParam);
        });

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

