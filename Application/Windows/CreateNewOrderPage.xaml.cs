using System;
using System.Linq;
using System.Windows;
using Database.Service;
using Domain.Entities;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for CreateNewOrderPage.xaml
    /// </summary>
    public partial class CreateNewOrderPage
    {
        public CreateNewOrderPage()
        {
            InitializeComponent();

            foreach (var item in GettingService.GetClients()) CmbClient.Items.Add(item.FirstName + " " + item.LastName);

            foreach (var item in GettingService.GetSellers()) CmbSeller.Items.Add(item.FirstName + " " + item.LastName);

            foreach (var item in GettingService.GetProducts()) CmbProduct.Items.Add(item.Name);
        }

        private void Btn_Create_OnClick(object sender, RoutedEventArgs e)
        {
            var clientId = GettingService.GetClients()
                .First(c => c.FirstName + " " + c.LastName == CmbClient.SelectedItem.ToString()).Id;
            var sellerId = GettingService.GetSellers()
                .First(s => s.FirstName + " " + s.LastName == CmbSeller.SelectedItem.ToString()).Id;
            var productId = GettingService.GetProducts().First(p => p.Name == CmbProduct.SelectedItem.ToString()).Id;

            var newOrder = new Order
            {
                ClientId = clientId,
                SellerId = sellerId,
                ProductId = productId,
                OrderDate = Convert.ToDateTime(DtpOrderDate.ToString())
            };

            AddingService.AddOrder(newOrder);

            if (MessageBox.Show("New order created") == MessageBoxResult.OK)
                Close();
        }
    }
}