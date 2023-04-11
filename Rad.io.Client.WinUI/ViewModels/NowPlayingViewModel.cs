using RadioBrowser.Models;
using RadioBrowser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad.io.Client.WinUI.ViewModels
{
    public class NowPlayingViewModel : INotifyPropertyChanged
    {
        private IRadioBrowserClient radioBrowserClient;
        private StationInfo currentStation;


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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ShowUrl()
        {
            Debug.WriteLine(currentStation.Url);
        }
    }
}
