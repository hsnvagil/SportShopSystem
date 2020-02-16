using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Database.EntityFramework;
using Domain.Entities;

namespace Database.Service
{
    public static class GettingService
    {
        public static IEnumerable<Client> GetClients()
        {
            using var db = new ShopDbContext();
            return db.Clients.ToList();
        }

        public static IEnumerable<Seller> GetSellers()
        {
            using var db = new ShopDbContext();
            return db.Sellers.ToList();
        }

        public static IEnumerable<Product> GetProducts()
        {
            using var db = new ShopDbContext();
            return db.Products.ToList();
        }

        public static IEnumerable<Order> GetOrders()
        {
            using var db = new ShopDbContext();
            return db.Orders
                .Include(o => o.Client)
                .Include(o => o.Seller)
                .Include(o => o.Product).ToList();
        }
    }
}