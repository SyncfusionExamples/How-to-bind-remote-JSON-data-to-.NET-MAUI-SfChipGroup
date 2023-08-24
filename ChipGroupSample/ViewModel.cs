using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChipGroupSample
{
    public class ViewModel : INotifyPropertyChanged 
    {
        private const string Url = "https://ej2services.syncfusion.com/production/web-services/api/Orders";//This url is a free public api intended for demos
        private readonly HttpClient _client = new HttpClient();//Creating a new instance of HttpClient. (Microsoft.Net.Http)

        private ObservableCollection<Model> data;
        
        public ObservableCollection<Model> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }
        
        public ViewModel()
        {
            Data = new ObservableCollection<Model>();
            GetData();
        }
        
        async void GetData()
        {
            string content = await _client.GetStringAsync(Url); //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation
            var json_Datas = JsonConvert.DeserializeObject<ObservableCollection<Model>>(content); //Deserializes or converts JSON String into a collection of Post
            Data = json_Datas;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
