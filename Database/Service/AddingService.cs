using System.Data.Entity;
using Database.EntityFramework;
using Domain.Entities;

namespace Database.Service
{
    public static class AddingService
    {
        public static void AddClient(Client client)
        {
            using var db = new ShopDbContext();
            db.Entry(client).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void AddSeller(Seller seller)
        {
            using var db = new ShopDbContext();
            db.Entry(seller).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void AddProduct(Product product)
        {
            using var db = new ShopDbContext();
            db.Entry(product).State = EntityState.Added;
            db.SaveChanges();
        }

        public static void AddOrder(Order order)
        {
            using var db = new ShopDbContext();
            db.Entry(order).State = EntityState.Added;
            db.SaveChanges();
        }
    }
}