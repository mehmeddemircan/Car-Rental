using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Concrete.Contexts
{
    public class ApplicationDbContext : DbContext
    {

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=CarRental;Trusted_Connection=true");

            //optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=CarRental;User Id=postgres;Password=Sd635241;");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<SellerForm> SellerForms { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CarImage> CarImage { get; set; }



        

    }
}
