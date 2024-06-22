using Core.Model;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace Core.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ActivatedAlarm> ActivatedAlarms { get; set; }
        public DbSet<TagEntity> TagValues { get; set; }
        public DatabaseContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
