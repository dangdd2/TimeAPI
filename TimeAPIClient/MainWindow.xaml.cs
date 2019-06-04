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
            InitDescriptorGrid();
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
                var request = new RestRequest(RestSharpHelper.Client + clientRow.id, Method.DELETE);
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

        // Descriptor
        private void InitDescriptorGrid()
        {
            descriptorGrid.AutoGenerateColumns = false;
            descriptorGrid.IsReadOnly = true;
            descriptorGrid.ItemsSource = LoadDescriptorData();
        }

        private List<Descriptor> LoadDescriptorData()
        {
            var descriptor = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Descriptor, Method.GET);
            var data = descriptor.Execute<List<Descriptor>>(request).Data;
            return data;
        }

        private void ButtonDescriptor_Click(object sender, RoutedEventArgs e)
        {
            var addDes = new EditDescriptor();
            addDes.ShowDialog();
            InitDescriptorGrid();
        }

        private void EditDescriptor_OnClick(object sender, RoutedEventArgs e)
        {
            var desRow = descriptorGrid.SelectedItem as Descriptor;

            var editDes = new EditDescriptor(desRow.Id);
            editDes.ShowDialog();
            InitDescriptorGrid();
        }

        private void ButtonDescriptor_Delete(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var desRow = descriptorGrid.SelectedItem as Descriptor;

                var client = new RestClient(RestSharpHelper.ApiUrl);
                var request = new RestRequest(RestSharpHelper.Descriptor + desRow.Id, Method.DELETE);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    InitDescriptorGrid();
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage, "Error");
                }
            }
        }
    }
}
