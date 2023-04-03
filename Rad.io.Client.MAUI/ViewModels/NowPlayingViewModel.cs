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
        private MediaElement mediaElement = new MediaElement();

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
        public MediaElement MediaElement {
            get => mediaElement;
            set
            {
                mediaElement = value;
                RaisePropertyChanged();
            }
        }

        public NowPlayingViewModel(IRadioBrowserClient radioBrowserClient)
        {
            this.radioBrowserClient = radioBrowserClient;
        }

        public ICommand OnStopPressed => new Command(() => {
            mediaElement.Stop();
        });

        public ICommand OnPlay => new Command(() =>
        {
            mediaElement.Source = "https://rs9-krk2-cyfronet.rmfstream.pl/RMFMAXXX48";
        });

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
