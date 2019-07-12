using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetBankDB.Models
{
    public class NetBankContext : DbContext
    {
        public NetBankContext(DbContextOptions<NetBankContext> context)
            : base(context)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=NetBankDb;integrated security=True;MultipleActiveResultSets=True;");
            }
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
