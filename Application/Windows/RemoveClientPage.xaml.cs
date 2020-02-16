using System.Linq;
using System.Windows;
using Database.Service;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for RemoveClientPage.xaml
    /// </summary>
    public partial class RemoveClientPage
    {
        public RemoveClientPage()
        {
            InitializeComponent();
            foreach (var item in GettingService.GetClients())
                ClientCmbBox.Items.Add(item.FirstName + " " + item.LastName);
            ClientCmbBox.SelectedIndex = 0;
        }

        private void RemoveClient_OnClick(object sender, RoutedEventArgs e)
        {
            var client = GettingService.GetClients()
                .First(c => c.FirstName + " " + c.LastName == ClientCmbBox.SelectedItem.ToString());

            RemovingService.RemoveClient(client);

            if (MessageBox.Show("Client removed") == MessageBoxResult.OK)
                Close();
        }
    }
}