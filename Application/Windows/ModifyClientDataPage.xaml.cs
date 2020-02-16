using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Database.Service;
using Domain.Entities;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for ModifyClientDataPage.xaml
    /// </summary>
    public partial class ModifyClientDataPage
    {
        public ModifyClientDataPage()
        {
            InitializeComponent();
            foreach (var item in GettingService.GetClients())
                ClientCmbBox.Items.Add(item.FirstName + " " + item.LastName);
            ClientCmbBox.SelectedIndex = 0;
        }

        private void ClientCmbBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var client = GettingService.GetClients()
                .First(c => c.FirstName + " " + c.LastName == ClientCmbBox.SelectedItem.ToString());

            TxtFirstName.Text = client.FirstName;
            TxtLastName.Text = client.LastName;
            DtpBirthDate.SelectedDate = client.BirthDate.Date;

            if (client.Gender != Gender.Male)
                RBtnFemale.IsChecked = true;
            else
                RBtnMale.IsChecked = true;
        }

        private void Btn_Modify_OnClick(object sender, RoutedEventArgs e)
        {
            var client = GettingService.GetClients()
                .First(c => c.FirstName + " " + c.LastName == ClientCmbBox.SelectedItem.ToString());
            var gender = RBtnMale.IsChecked == true ? Gender.Male : Gender.Female;
            client.FirstName = TxtFirstName.Text;
            client.LastName = TxtLastName.Text;
            client.BirthDate = Convert.ToDateTime(DtpBirthDate.SelectedDate);
            client.Gender = gender;

            ModifyingService.ModifyClient(client);
            if (MessageBox.Show("Client modified") == MessageBoxResult.OK)
                Close();
        }
    }
}