using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Database.Service;
using Domain.Entities;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for ModifySellerDataPage.xaml
    /// </summary>
    public partial class ModifySellerDataPage
    {
        public ModifySellerDataPage()
        {
            InitializeComponent();
            foreach (var item in GettingService.GetSellers())
                SellerCmbBox.Items.Add(item.FirstName + " " + item.LastName);
            SellerCmbBox.SelectedIndex = 0;
        }

        private void Btn_Modify_OnClick(object sender, RoutedEventArgs e)
        {
            var seller = GettingService.GetSellers()
                .First(s => s.FirstName + " " + s.LastName == SellerCmbBox.SelectedItem.ToString());
            var gender = RBtnMale.IsChecked == true ? Gender.Male : Gender.Female;

            seller.FirstName = TxtFirstName.Text;
            seller.LastName = TxtLastName.Text;
            seller.BirthDate = Convert.ToDateTime(DtpBirthDate.SelectedDate);
            seller.HireDate = Convert.ToDateTime(DtpHireDate.SelectedDate);
            seller.Gender = gender;

            //seller.EndDate = Convert.ToDateTime(DtpEndDate.SelectedDate) ?? null;
            try
            {
                seller.EndDate = Convert.ToDateTime(DtpEndDate.ToString());
            }
            catch (Exception)
            {
                seller.EndDate = null;
            }

            ModifyingService.ModifySeller(seller);
            if (MessageBox.Show("Seller modified") == MessageBoxResult.OK)
                Close();
        }

        private void SellerCmbBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var seller = GettingService.GetSellers()
                .First(s => s.FirstName + " " + s.LastName == SellerCmbBox.SelectedItem.ToString());

            TxtFirstName.Text = seller.FirstName;
            TxtLastName.Text = seller.LastName;
            DtpBirthDate.SelectedDate = seller.BirthDate.Date;
            DtpHireDate.SelectedDate = seller.HireDate.Date;
            DtpEndDate.SelectedDate = seller.EndDate ?? null;

            if (seller.Gender != Gender.Male)
                RBtnFemale.IsChecked = true;
            else
                RBtnMale.IsChecked = true;
        }
    }
}