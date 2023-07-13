using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class DatabaseContext:DbContext
    {
        //public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        //{ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; Database = DirectoryApp; Username = postgres; Password = sa123");
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

    }
}
