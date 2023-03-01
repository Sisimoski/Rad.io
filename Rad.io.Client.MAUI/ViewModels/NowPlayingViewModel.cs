using Newtonsoft.Json;
using System.ComponentModel;

namespace Rad.io.Client.MAUI.ViewModels
{
    internal class NowPlayingViewModel : INotifyPropertyChanged
    {
        private Guid id;
        private string name = "";
        private string url = "";

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        [JsonProperty("stationuuid")]
        public Guid Id
        {
            get => id; set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [JsonProperty("name")]
        public string Name
        {
            get => name; set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        [JsonProperty("url")]
        public string Url
        {
            get => url; set
            {
                url = value;
                OnPropertyChanged(nameof(Url));
            }
        }
    }
}
