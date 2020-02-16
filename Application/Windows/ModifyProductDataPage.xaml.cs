using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Database.Service;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for ModifyProductDataPage.xaml
    /// </summary>
    public partial class ModifyProductDataPage
    {
        public ModifyProductDataPage()
        {
            InitializeComponent();
            foreach (var item in GettingService.GetProducts()) ProductCmbBox.Items.Add(item.Name);

            ProductCmbBox.SelectedIndex = 0;
        }

        private void ProductCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = GettingService.GetProducts().First(p => p.Name == ProductCmbBox.SelectedItem.ToString());

            TxtName.Text = product.Name;
            TxtPrice.Text = product.Price.ToString();
        }

        private void Btn_Modify_OnClick(object sender, RoutedEventArgs e)
        {
            var product = GettingService.GetProducts().First(p => p.Name == ProductCmbBox.SelectedItem.ToString());

            product.Name = TxtName.Text;
            product.Price = Convert.ToDecimal(TxtPrice.Text);

            ModifyingService.ModifyProduct(product);
            if (MessageBox.Show("Product modified") == MessageBoxResult.OK)
                Close();
        }
    }
}