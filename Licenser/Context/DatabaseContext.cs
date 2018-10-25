using Licenser.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Licenser.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("LicenserDatabase")
        { }
    
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}