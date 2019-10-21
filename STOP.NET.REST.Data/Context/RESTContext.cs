using Microsoft.EntityFrameworkCore;
using STOP.NET.REST.Models;

namespace STOP.NET.REST.Data.Context
{
    public class RESTContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public RESTContext(DbContextOptions<RESTContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
