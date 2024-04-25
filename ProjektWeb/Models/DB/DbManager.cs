using Microsoft.EntityFrameworkCore;

namespace ProjektWeb.Models.DB
{

    public class DbManager : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // für den Pomelo-MySQL-Treiber
            string connectionString = "Server=localhost;database=Web_Projekt_db;user=root;password=root";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }


    }
}
