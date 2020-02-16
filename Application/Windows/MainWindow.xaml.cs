using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Database.Service;

namespace Application.Windows
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                Database.Service.Database.Create();
            }
            catch (Exception)
            {
                // ignored
            }

            Initialize();
        }

        private void Initialize()
        {
            ClientDataGrid.ItemsSource = GettingService.GetClients();
            SellerDataGrid.ItemsSource = GettingService.GetSellers();
            ProductDataGrid.ItemsSource = GettingService.GetProducts();
            OrderDataGrid.ItemsSource = GettingService.GetOrders();

            ClientsCmbBox.SelectedIndex = 0;
            SellersCmbBox.SelectedIndex = 0;
            ProductsCmbBox.SelectedIndex = 0;
            OrdersCmbBox.SelectedIndex = 0;
        }

        private void CreateNewClient_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new CreateNewClientPage();
            page.ShowDialog();

            Initialize();
        }

        private void CreateNewSeller_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new CreateNewSellerPage();
            page.ShowDialog();

            Initialize();
        }

        private void CreateNewProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new CreateNewProductPage();
            page.ShowDialog();

            Initialize();
        }

        private void CreateNewOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new CreateNewOrderPage();
            page.ShowDialog();

            Initialize();
        }

        private void EditClient_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new ModifyClientDataPage();
            page.ShowDialog();

            Initialize();
        }

        private void EditSeller_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new ModifySellerDataPage();
            page.ShowDialog();

            Initialize();
        }

        private void EditProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new ModifyProductDataPage();
            page.ShowDialog();

            Initialize();
        }

        private void RemoveClient_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new RemoveClientPage();
            page.ShowDialog();

            Initialize();
        }

        private void RemoveSeller_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new RemoveSellerPage();
            page.ShowDialog();

            Initialize();
        }

        private void RemoveProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new RemoveProductPage();
            page.ShowDialog();

            Initialize();
        }

        private void SearchClient_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime? d;
            try
            {
                d = Convert.ToDateTime(SearchSellerTxtBox.Text);
            }
            catch (Exception)
            {
                d = null;
            }

            switch (ClientsCmbBox.SelectedIndex)
            {
                case 0:
                    ClientDataGrid.ItemsSource = GettingService.GetClients()
                        .Where(c => c.Id.ToString() == SearchClientTxtBox.Text);
                    break;
                case 1:
                    ClientDataGrid.ItemsSource =
                        GettingService.GetClients().Where(c => c.FirstName == SearchClientTxtBox.Text);
                    break;
                case 2:
                    ClientDataGrid.ItemsSource =
                        GettingService.GetClients().Where(c => c.LastName == SearchClientTxtBox.Text);
                    break;
                case 3:
                    ClientDataGrid.ItemsSource = GettingService.GetClients()
                        .Where(c => c.Gender.ToString() == SearchClientTxtBox.Text);
                    break;
                case 4:
                    ClientDataGrid.ItemsSource = GettingService.GetClients().Where(c => c.BirthDate == d);
                    break;
            }
        }

        private void SearchSeller_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime? d;
            try
            {
                d = Convert.ToDateTime(SearchSellerTxtBox.Text);
            }
            catch (Exception)
            {
                d = null;
            }

            switch (SellersCmbBox.SelectedIndex)
            {
                case 0:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers()
                        .Where(s => s.Id.ToString() == SearchSellerTxtBox.Text);
                    break;
                case 1:
                    SellerDataGrid.ItemsSource =
                        GettingService.GetSellers().Where(s => s.FirstName == SearchSellerTxtBox.Text);
                    break;
                case 2:
                    SellerDataGrid.ItemsSource =
                        GettingService.GetSellers().Where(s => s.LastName == SearchSellerTxtBox.Text);
                    break;
                case 3:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers()
                        .Where(s => s.Gender.ToString() == SearchSellerTxtBox.Text);
                    break;
                case 4:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().Where(s => s.BirthDate == d);
                    break;
                case 5:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().Where(s => s.HireDate == d);
                    break;
                case 6:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().Where(s => s.EndDate == d);
                    break;
            }
        }

        private void SearchProduct_OnClick(object sender, RoutedEventArgs e)
        {
            switch (ProductsCmbBox.SelectedIndex)
            {
                case 0:
                    ProductDataGrid.ItemsSource = GettingService.GetProducts()
                        .Where(p => p.Id.ToString() == SearchProductTxtBox.Text);
                    break;
                case 1:
                    ProductDataGrid.ItemsSource =
                        GettingService.GetProducts().Where(p => p.Name == SearchProductTxtBox.Text);
                    break;
                case 2:
                    ProductDataGrid.ItemsSource = GettingService.GetProducts()
                        .Where(p => p.Price.ToString() == SearchProductTxtBox.Text);
                    break;
            }
        }

        private void SearchOrder_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime? d;
            try
            {
                d = Convert.ToDateTime(SearchSellerTxtBox.Text);
            }
            catch (Exception)
            {
                d = null;
            }

            switch (OrdersCmbBox.SelectedIndex)
            {
                case 0:
                    OrderDataGrid.ItemsSource =
                        GettingService.GetOrders().Where(o => o.Id.ToString() == SearchOrderTxtBox.Text);
                    break;
                case 1:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders()
                        .Where(o => o.Client.FirstName == SearchOrderTxtBox.Text);
                    break;
                case 2:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders()
                        .Where(o => o.Client.LastName == SearchOrderTxtBox.Text);
                    break;
                case 3:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders()
                        .Where(o => o.Seller.FirstName == SearchOrderTxtBox.Text);
                    break;
                case 4:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders()
                        .Where(o => o.Seller.LastName == SearchOrderTxtBox.Text);
                    break;
                case 5:
                    OrderDataGrid.ItemsSource =
                        GettingService.GetOrders().Where(o => o.Product.Name == SearchOrderTxtBox.Text);
                    break;
                case 6:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().Where(o => o.OrderDate == d);
                    break;
            }
        }

        private void ClientsCmbBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ClientsCmbBox.SelectedIndex)
            {
                case 0:
                    ClientDataGrid.ItemsSource = GettingService.GetClients().OrderBy(c => c.Id).ToList();
                    break;
                case 1:
                    ClientDataGrid.ItemsSource = GettingService.GetClients().OrderBy(c => c.FirstName).ToList();
                    break;
                case 2:
                    ClientDataGrid.ItemsSource = GettingService.GetClients().OrderBy(c => c.LastName).ToList();
                    break;
                case 3:
                    ClientDataGrid.ItemsSource = GettingService.GetClients().OrderBy(c => c.Gender).ToList();
                    break;
                case 4:
                    ClientDataGrid.ItemsSource = GettingService.GetClients().OrderBy(c => c.BirthDate).ToList();
                    break;
            }

            SearchClientTxtBox.Text = "";
        }

        private void SellersCmbBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SellersCmbBox.SelectedIndex)
            {
                case 0:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.Id).ToList();
                    break;
                case 1:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.FirstName);
                    break;
                case 2:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.LastName).ToList();
                    break;
                case 3:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.Gender).ToList();
                    break;
                case 4:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.BirthDate).ToList();
                    break;
                case 5:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.HireDate).ToList();
                    break;
                case 6:
                    SellerDataGrid.ItemsSource = GettingService.GetSellers().OrderBy(s => s.EndDate).ToList();
                    break;
            }

            SearchSellerTxtBox.Text = "";
        }

        private void ProductsCmbBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ProductsCmbBox.SelectedIndex)
            {
                case 0:
                    ProductDataGrid.ItemsSource = GettingService.GetProducts().OrderBy(p => p.Id).ToList();
                    break;
                case 1:
                    ProductDataGrid.ItemsSource = GettingService.GetProducts().OrderBy(p => p.Name).ToList();
                    break;
                case 2:
                    ProductDataGrid.ItemsSource = GettingService.GetProducts().OrderBy(p => p.Price).ToList();
                    break;
            }

            SearchProductTxtBox.Text = "";
        }

        private void OrdersProductsCmbBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (OrdersCmbBox.SelectedIndex)
            {
                case 0:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.Id).ToList();
                    break;
                case 1:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.Client.FirstName).ToList();
                    break;
                case 2:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.Client.LastName).ToList();
                    break;
                case 3:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.Seller.FirstName).ToList();
                    break;
                case 4:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.Seller.LastName).ToList();
                    break;
                case 5:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.Product.Name).ToList();
                    break;
                case 6:
                    OrderDataGrid.ItemsSource = GettingService.GetOrders().OrderBy(o => o.OrderDate).ToList();
                    break;
            }

            SearchOrderTxtBox.Text = "";
        }
    }
}