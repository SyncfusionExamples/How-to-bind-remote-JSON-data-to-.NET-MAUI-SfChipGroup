# How-to-bind-remote-JSON-data-to-.NET-MAUI-SfChipGroup
This sample explains how to bind remote JSON data to .NET MAUI ChipGroup (SfChipGroup).

Steps

Step 1: Bind the JSON data to the ChipGroup

Bind the data from the remote JSON file in .NET MAUI ChipGroup using the ItemsSource property.

XAML

<chip:SfChipGroup ItemsSource="{Binding Data}"
                  ChipPadding="8,8,0,0"
                  DisplayMemberPath="ShipCity">
            <chip:SfChipGroup.ChipLayout>
                <FlexLayout HorizontalOptions="Start"
                            VerticalOptions="Center"
                            Direction="Row"
                            Wrap="Wrap"
                            JustifyContent="Start"
                            AlignContent="Start"
                            AlignItems="Start"/>
            </chip:SfChipGroup.ChipLayout>
     </chip:SfChipGroup>
     
Step 2: Access the JSON file

Access the JSON file from the remote server and deserialize the object to return as a collection of models.

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
        

