using Microsoft.EntityFrameworkCore;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persisten
{
   public class InvenDbContext : DbContext
    {



        public DbSet<Inventario> Inventario { get; set; }

        public InvenDbContext(DbContextOptions<InvenDbContext> options)
            : base(options)
        {
            
        }
    }
}
