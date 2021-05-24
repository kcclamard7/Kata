using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataTest.Models
{
    public class KataDbContex : DbContext
    {
        public KataDbContex(DbContextOptions<KataDbContex> options)
            :base(options)
        {

        }

        public DbSet<Calculation> calculations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KataDbContex).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
