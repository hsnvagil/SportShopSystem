using System.Data.Entity;
using Database.EntityFramework;
using Domain.Entities;

namespace Database.Service
{
    public static class ModifyingService
    {
        public static void ModifyClient(Client modifiedClient)
        {
            using var db = new ShopDbContext();
            db.Entry(modifiedClient).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void ModifySeller(Seller modifiedSeller)
        {
            using var db = new ShopDbContext();
            db.Entry(modifiedSeller).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void ModifyProduct(Product modifiedProduct)
        {
            using var db = new ShopDbContext();
            db.Entry(modifiedProduct).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}