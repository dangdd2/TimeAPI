using System.Collections.Generic;
using System.Windows;
using RestSharp;
using TimeAPIClient.Helper;

namespace TimeAPIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridClient.AutoGenerateColumns = false;
            dataGridClient.IsReadOnly = true;
            dataGridClient.ItemsSource = LoadCollectionData();
        }

        private List<Client> LoadCollectionData()
        {
            var client = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Client, Method.GET);
            return client.Execute<List<Client>>(request).Data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var editClient = new EditClient();
            editClient.ShowDialog();
            LoadData();
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var clientRow = dataGridClient.SelectedItem as Client;

                var client = new RestClient(RestSharpHelper.ApiUrl);
                var request = new RestRequest("api/client/"+ clientRow.id, Method.DELETE);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage,"Error");
                }
                
            }
        }

        private void EditClient_OnClick(object sender, RoutedEventArgs e)
        {
            var clientRow = dataGridClient.SelectedItem as Client;

            var editClient = new EditClient(clientRow.id);
            editClient.ShowDialog();
            LoadData();
        }
    }
}
