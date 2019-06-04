using System.Collections.Generic;
using System.Windows;
using RestSharp;
using TimeAPIClient.Helper;


namespace TimeAPIClient
{
    public partial class EditDescriptor : Window
    {
        private long descriptorId;
        private bool isUpdated;

        public EditDescriptor()
        {
            InitializeComponent();
            this.Title = "Add descriptor";
        }

        public EditDescriptor(long id)
        {
            
            descriptorId = id;
            isUpdated = true;
            InitializeComponent();
            this.Title = "Edit descriptor";
            LoaddescriptorById(descriptorId);
        }

        public void LoaddescriptorById(long id)
        {
            var descriptor = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Descriptor + id, Method.GET);
            var descriptorData = descriptor.Execute<Descriptor>(request).Data;
            if (descriptorData != null)
            {
                txtId.Text = descriptorData.Id.ToString();
                txtId.IsEnabled = false;

                txtName.Text = descriptorData.Name;
                txtIdentifier.Text = descriptorData.Identifier;
            }
            else
            {
                MessageBox.Show("The selected descriptor does not exist... ");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isUpdated)
            {
                UpdateDescriptor();
            }
            else
            {
                AddDescriptor();
            }
        }

        private void UpdateDescriptor()
        {
            var client = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Descriptor + descriptorId, Method.PUT);
            request.RequestFormat = RestSharp.DataFormat.Json;

#pragma warning disable 618
            request.AddBody(new Descriptor
#pragma warning restore 618
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Identifier = txtIdentifier.Text
            });
            HandleResponse(client, request);
        }

        private void HandleResponse(RestClient client, RestRequest request)
        {
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

        private void AddDescriptor()
        {
            var client = new RestClient(RestSharpHelper.ApiUrl);
            var request = new RestRequest(RestSharpHelper.Descriptor, Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
#pragma warning disable 618
            request.AddBody(new Descriptor
#pragma warning restore 618
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Identifier = txtIdentifier.Text,
                DescriptorMatters = new List<DescriptorEntry>()
            });
            HandleResponse(client, request);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
