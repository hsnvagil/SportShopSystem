using Database.EntityFramework;

namespace Database.Service
{
    public static class Database
    {
        public static void Create()
        {
            using var db = new ShopDbContext();
            db.Database.Create();
        }
    }
}