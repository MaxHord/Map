using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Map.Models.DB;

namespace Map.Models
{
    public class MainContext : DbContext
    {
        static MainContext()
        {
            Database.SetInitializer<MainContext>(new ContextInit());
        }

        public MainContext() : base("DbMap") { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Reside> Resides { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
