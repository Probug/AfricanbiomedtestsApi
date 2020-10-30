using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Africanbiomedtests.Entities;

namespace Africanbiomedtests.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<HealthcareProvider> HealthcareProviders { get; set; }
        public DbSet<Newborn> Newborns { get; set; }
        //public DbSet<MedTests> MedTests { get; set; }
        //public DbSet<MedTestsOrder> MedTestsOrders { get; set; } 
        //public DbSet<MedTestsResults> MedTestsResults { get; set; }
        
        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}