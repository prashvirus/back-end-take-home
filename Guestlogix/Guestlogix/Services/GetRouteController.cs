using System.Web.Http;
using Microsoft.Ajax.Utilities;

namespace Guestlogix.Services
{
    public class GetRouteController : ApiController
    {
        // GET: api/GetRoute

        public Response Get()
        {
            return new Response()
            {
                Success = false,
                Message = "Please Pass Origin And Destination."
            };
        }
        public Response Get(string origin, string destination)
        {
            if (origin.IsNullOrWhiteSpace() && destination.IsNullOrWhiteSpace())
            {
                return new Response()
                {
                    Success = false,
                    Message = "Please Pass Origin And Destination."
                };
            }
            if (origin?.ToUpper() == destination?.ToUpper())
            {
                return new Response()
                {
                    Success = false,
                    Message = "Origin/Destination Cannot Be Same."
                };
            }
            var originPort = Utility.GetAirport(origin?.ToUpper());
            if (originPort == null)
            {
                return new Response()
                {
                    Success = false,
                    Message = "Invalid Origin."
                };
            }
            var destinationPort = Utility.GetAirport(destination?.ToUpper());
            if (destinationPort == null)
            {
                return new Response()
                {
                    Success = false,
                    Message = "Invalid Destination."
                };
            }
            var route = Utility.GetRoute(origin?.ToUpper(), destination?.ToUpper());
            if (route != null)
            {
                var data = route.Origin + " -> " + route.Destination;
                return new Response()
                {
                    Success = true,
                    Message = "Record Found.",
                    Data = data
                };
            }
            return Utility.GetShortestPath(origin?.ToUpper(), destination?.ToUpper());
        }
    }
}
