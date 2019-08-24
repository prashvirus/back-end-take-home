using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using GuestlogixDal.Dal;
using GuestlogixDal.Models;

namespace Guestlogix.Services
{
    public static class Utility
    {
        public static Airport GetAirport(string code)
        {
            using (var db = new GuestlogixContext())
            {
                var codeParam = new SqlParameter("@Code", code);
                var result = db.Database
                    .SqlQuery<Airport>("GetAirport @Code", codeParam).FirstOrDefault();
                return result;
            }
        }

        public static List<Airport> GetAirports()
        {
            using (var db = new GuestlogixContext())
            {
                var result = db.Database
                    .SqlQuery<Airport>("GetAirports").ToList();
                return result;
            }
        }

        public static List<Route> GetRoutes()
        {
            using (var db = new GuestlogixContext())
            {
                var result = db.Database
                    .SqlQuery<Route>("GetRoutes").ToList();
                return result;
            }
        }

        public static Route GetRoute(string origin, string destination)
        {
            using (var db = new GuestlogixContext())
            {
                var originParam = new SqlParameter("@Origin", origin);
                var destParam = new SqlParameter("@Dest", destination);
                var result = db.Database
                    .SqlQuery<Route>("GetRoute @Origin,@Dest", originParam, destParam).FirstOrDefault();
                return result;
            }
        }
        public static Response GetShortestPath(string origin, string destination)
        {

            var t = new Travel<string>();
            var itenaries = new List<Itenary<string>>();
            var airports = GetAirports();
            if (airports.Any())
            {
                foreach (var airport in airports)
                {
                    itenaries.Add(new Itenary<string>(airport.Iata3));
                }
            }
            var originNode = itenaries.FirstOrDefault(c => c.Value == origin);
            var destNode = itenaries.FirstOrDefault(c => c.Value == destination);
            var routes = GetRoutes();
            if (routes.Any())
            {
                foreach (var route in routes)
                {
                    var originPort = itenaries.FirstOrDefault(c => c.Value == route.Origin);
                    var destPort = itenaries.FirstOrDefault(c => c.Value == route.Destination);
                    t.AddRoute(originPort, destPort);
                }
            }
            var path = t.ShortestPath(originNode, destNode);
            if (path.Count <= 0)
            {
                return new Response()
                {
                    Success = false,
                    Message = "No Record."
                };
            }
            var data = $"{string.Join(" -> ", path)}";
            return new Response()
            {
                Success = true,
                Message = "Record Found.",
                Data = data
            };

        }
    }
}