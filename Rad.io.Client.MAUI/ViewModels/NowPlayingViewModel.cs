using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using RadioBrowser;
using RadioBrowser.Models;

namespace Rad.io.Client.MAUI.ViewModels
{
    [QueryProperty(nameof(CurrentStation), "CurrentStation")]
    public class NowPlayingViewModel : INotifyPropertyChanged
    {
        private IRadioBrowserClient radioBrowserClient;
        private StationInfo currentStation;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public StationInfo CurrentStation
        {
            get => currentStation;
            set
            {
                currentStation = value;
                RaisePropertyChanged();
            }
        }

        public NowPlayingViewModel(IRadioBrowserClient radioBrowserClient)
        {
            this.radioBrowserClient = radioBrowserClient;
        }

        private async Task InitializeDataAsync()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
