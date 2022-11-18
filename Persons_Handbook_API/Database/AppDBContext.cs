using Microsoft.EntityFrameworkCore;

namespace Persons_Handbook_API.Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base() { }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Photos> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-064MSHH\\SQLEXPRESS; Initial Catalog=TBC-Persons_Handbook; Integrated Security=True; TrustServerCertificate=True;");
            }
        }

    }
}
