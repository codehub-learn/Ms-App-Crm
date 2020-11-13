using Microsoft.EntityFrameworkCore;
using ModelCrm.Models;
using System;
using System.Collections.Generic;
using System.Text;
/*
 * 
 *  Using the NuGet Package manager console
 *  add-migration <name of migration>
 *  update-database
 *
 * Using CLI  (not covered)
 *
 *
 */




namespace ModelCrm.CrmDbContext
{
    public class CrmAppDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        private readonly string connectionString =
            "Server =localhost; " +
            "Database =crm; " +
            "User Id =sa; " +
            "Password =passw0rd;";

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public CrmAppDbContext(DbContextOptions<CrmAppDbContext> options)
              : base(options)
        { }
        public CrmAppDbContext()
        { }
    }
}
