using Microsoft.EntityFrameworkCore;
using PersonRegister.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister.Data
{
    public class PersonRegisterDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<JobInfo> JobInfo { get; set; }

        public PersonRegisterDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<JobInfo>();
        }
    }
}
