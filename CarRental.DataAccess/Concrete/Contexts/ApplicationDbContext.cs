using CarRental.Core.Entities.Concrete.Auth;
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

    }
}
