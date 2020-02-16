using System.Linq;
using System.Windows;
using Database.Service;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for RemoveProductPage.xaml
    /// </summary>
    public partial class RemoveProductPage
    {
        public RemoveProductPage()
        {
            InitializeComponent();
            foreach (var item in GettingService.GetProducts().ToList()) ProductCmbBox.Items.Add(item.Name);
            ProductCmbBox.SelectedIndex = 0;
        }

        private void RemoveProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var product = GettingService.GetProducts()
                .First(p => p.Name == ProductCmbBox.SelectedItem.ToString());

            RemovingService.RemoveProduct(product);

            if (MessageBox.Show("Product removed") == MessageBoxResult.OK)
                Close();
        }
    }
}