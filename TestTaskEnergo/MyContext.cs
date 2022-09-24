using Microsoft.EntityFrameworkCore;
using TestTaskEnergo.Entities;

namespace TestTaskEnergo
{
    public class MyContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DbSet<Company> Companies => Set<Company>();

        public DbSet<User> Users => Set<User>();



        public MyContext(IConfiguration configuration)
        {
            Configuration = configuration;

        //    Database.EnsureDeleted();
            Database.EnsureCreated();
            FillDB();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration["ConnectionStrings:TestDB"]);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //FillDB();
        //    //Company microsoft = new Company { Name = "Microsoft" };
        //    //Company google = new Company { Name = "Google" };
        //    //modelBuilder.Entity<Company>().HasData(microsoft, google);

        //    //User tom = new User { Name = "Tom", Company = microsoft };
        //    //User bob = new User { Name = "Bob", Company = microsoft };
        //    //User alice = new User { Name = "Alice", Company = google };
        //    //modelBuilder.Entity<User>().HasData(tom, bob, alice);
    
        //}

        private void FillDB()
        {
            using (var db = new MyContext(Configuration))
            {
                // создание и добавление моделей
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Company = microsoft };
                User bob = new User { Name = "Bob", Company = microsoft };
                User alice = new User { Name = "Alice", Company = google };
                db.Users.AddRange(tom, bob, alice);
                db.SaveChanges();

            }
        }

    }
}
