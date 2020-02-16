using System;
using System.Windows;
using Database.Service;
using Domain.Entities;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for CreateNewProductPage.xaml
    /// </summary>
    public partial class CreateNewProductPage
    {
        public CreateNewProductPage()
        {
            InitializeComponent();
        }

        private void Btn_Create_OnClick(object sender, RoutedEventArgs e)
        {
            var newProduct = new Product
            {
                Name = TxtName.Text,
                Price = Convert.ToDecimal(TxtPrice.Text)
            };

            AddingService.AddProduct(newProduct);

            if (MessageBox.Show("New product created") == MessageBoxResult.OK)
                Close();
        }
    }
}