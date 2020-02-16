using System;
using System.Windows;
using Database.Service;
using Domain.Entities;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for CreateNewClientPage.xaml
    /// </summary>
    public partial class CreateNewClientPage
    {
        public CreateNewClientPage()
        {
            InitializeComponent();
        }

        private void Btn_Create_OnClick(object sender, RoutedEventArgs e)
        {
            var gender = RBtnMale.IsChecked == true ? Gender.Male : Gender.Female;

            var newClient = new Client
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                Gender = gender,
                BirthDate = Convert.ToDateTime(DtpBirthDate.SelectedDate)
            };

            AddingService.AddClient(newClient);

            if (MessageBox.Show("New client created") == MessageBoxResult.OK)
                Close();
        }
    }
}