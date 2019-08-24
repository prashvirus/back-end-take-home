using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using CsvHelper;
using GuestlogixDal.Dal;
using GuestlogixDal.Models;

namespace Guestlogix.Services
{
    public class CreateDataController : ApiController
    {
        // GET: api/CreateData
        public Response Post()
        {
            var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data/routes.csv");
            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader))
                {
                    var records = csv.GetRecords<DataVm>().ToList();
                    var values = new List<Route>();
                    if (records.Any())
                    {
                        using (var db = new GuestlogixContext())
                        {
                            foreach (var record in records)
                            {
                                //var origin =
                                //    db.Airports.FirstOrDefault(c => c.Iata3.ToLower() == record.Origin.ToLower());
                                //var destination = db.Airports.FirstOrDefault(c => c.Iata3.ToLower() == record.Destination.ToLower());
                                //if (origin != null && destination != null)
                                //{
                                    values.Add(new Route()
                                    {
                                        AirlineId = record.AirlineId,
                                        Origin = record.Origin,
                                        Destination = record.Destination
                                    });
                                //}
                            }
                            if (values.Any())
                            {
                                db.Routes.AddRange(values);
                                db.SaveChanges();
                                return new Response()
                                {
                                    Success = true,
                                    Message = values.Count + " Records Added.",
                                    Data = values
                                };
                            }
                        }

                    }
                    return new Response()
                    {
                        Success = false
                    };
                }
            }
        }
    }

    public class DataVm
    {
        public string AirlineId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
