using System.Linq;
using System.Windows;
using Database.Service;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for RemoveSellerPage.xaml
    /// </summary>
    public partial class RemoveSellerPage
    {
        public RemoveSellerPage()
        {
            InitializeComponent();
            foreach (var item in GettingService.GetSellers())
                SellerCmbBox.Items.Add(item.FirstName + " " + item.LastName);
            SellerCmbBox.SelectedIndex = 0;
        }

        private void RemoveSeller_OnClick(object sender, RoutedEventArgs e)
        {
            var seller = GettingService.GetSellers()
                .First(s => s.FirstName + " " + s.LastName == SellerCmbBox.SelectedItem.ToString());

            RemovingService.RemoveSeller(seller);

            if (MessageBox.Show("Seller removed") == MessageBoxResult.OK)
                Close();
        }
    }
}