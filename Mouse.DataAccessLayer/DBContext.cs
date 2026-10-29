using System.Data.Entity;
using Mouse.Core.Models;

namespace Mouse.DataAccessLayer
{
    public class DBContext : DbContext
    {
        static DBContext()
        {
            Database.SetInitializer(
                new CreateDatabaseIfNotExists<DBContext>());
        }

        public DBContext() : base("name=MouseDatabase")
        {
        }

        public DbSet<Mouse.Core.Models.Mouse> Mice { get; set; }
    }
}
