using System.Windows;
using RestSharp;
using TimeAPIClient.Helper;


namespace TimeAPIClient
{
    public partial class EditClient : Window
    {
        private int clientId;
        private bool isUpdated;

        public EditClient()
        {
            InitializeComponent();
            this.Title = "Add client";
        }

        public EditClient(int id)
        {
            
            clientId = id;
            isUpdated = true;
            InitializeComponent();
            this.Title = "Edit client";
            LoadClientById(clientId);
        }

        public void LoadClientById(int id)
        {
            var client = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Client + id, Method.GET);
            var clientData = client.Execute<Client>(request).Data;
            if (clientData != null)
            {
                txtId.Text = clientData.id.ToString();
                txtId.IsEnabled = false;

                txtName.Text = clientData.name;
                txtIdentifier.Text = clientData.identifier;
            }
            else
            {
                MessageBox.Show("The selected client does not exist... ");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isUpdated)
            {
                UpdateClient();
            }
            else
            {
                AddClient();
            }
        }

        private void UpdateClient()
        {
            var client = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Client + clientId, Method.PUT);
            request.RequestFormat = RestSharp.DataFormat.Json;

#pragma warning disable 618
            request.AddBody(new Client
#pragma warning restore 618
            {
                id = int.Parse(txtId.Text),
                name = txtName.Text,
                identifier = txtIdentifier.Text
            });
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(response.ErrorMessage);
            }
        }

        private void AddClient()
        {
            var client = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Client, Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
#pragma warning disable 618
            request.AddBody(new Client
#pragma warning restore 618
            {
                id = int.Parse(txtId.Text),
                name = txtName.Text,
                identifier = txtIdentifier.Text
            });
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show(response.ErrorMessage);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
