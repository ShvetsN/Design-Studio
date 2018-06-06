using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DesignContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Work> Portfolio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=DesignStudioDB; Trusted_Connection=True;");
        }
    }
}
