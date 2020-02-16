using System.Data.Entity;
using Database.EntityFramework;
using Domain.Entities;

namespace Database.Service
{
    public static class RemovingService
    {
        public static void RemoveClient(Client client)
        {
            using var db = new ShopDbContext();
            db.Entry(client).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public static void RemoveSeller(Seller seller)
        {
            using var db = new ShopDbContext();
            db.Entry(seller).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public static void RemoveProduct(Product product)
        {
            using var db = new ShopDbContext();
            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}