using System.Data.Entity;
using GuestlogixDal.Models;

namespace GuestlogixDal.Dal
{
    public class GuestlogixContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Route> Routes { get; set; }
    }
}
