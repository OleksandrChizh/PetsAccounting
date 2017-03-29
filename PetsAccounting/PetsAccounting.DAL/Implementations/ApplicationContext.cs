using System.Data.Entity;

using PetsAccounting.DAL.Models;

using SQLite.CodeFirst;

namespace PetsAccounting.DAL.Implementations
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionStringName) : base(connectionStringName)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<ApplicationContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}