using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GuestlogixDal.Models
{
    [DataContract]
    [Serializable]
    public class Airport
    {
        [DataMember]
        [Key]
        public string Iata3 { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public decimal Longitude { get; set; }
        [DataMember]
        public decimal Latitude { get; set; }
        [DataMember]
        public List<Route> OriginPorts { get; set; }
        [DataMember]
        public List<Route> DestinationPorts { get; set; }
    }
}
