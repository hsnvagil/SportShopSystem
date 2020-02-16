using System;
using System.Windows;
using Database.Service;
using Domain.Entities;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for CreateNewSellerPage.xaml
    /// </summary>
    public partial class CreateNewSellerPage
    {
        public CreateNewSellerPage()
        {
            InitializeComponent();
        }

        private void Btn_Create_OnClick(object sender, RoutedEventArgs e)
        {
            var gender = RBtnMale.IsChecked == true ? Gender.Male : Gender.Female;

            var newSeller = new Seller
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                Gender = gender,
                BirthDate = Convert.ToDateTime(DtpBirthDate.ToString()),
                HireDate = Convert.ToDateTime(DtpHireDate.ToString())
            };
            try
            {
                newSeller.EndDate = Convert.ToDateTime(DtpEndDate.ToString());
            }
            catch (Exception)
            {
                newSeller.EndDate = null;
            }

            AddingService.AddSeller(newSeller);

            if (MessageBox.Show("New seller created") == MessageBoxResult.OK)
                Close();
        }
    }
}