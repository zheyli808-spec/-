using System.Data.Entity;

namespace Mouse.DataAccessLayer
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var db = new DBContext())
            {
                db.Database.Initialize(false);
            }
        }
    }
}