using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Context
{
    public class TravelaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JTNUQFE\\SQLEXPRESS;initial catalog=TravelaDb;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }

    }
}
