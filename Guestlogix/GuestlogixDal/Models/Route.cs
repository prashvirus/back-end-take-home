using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace GuestlogixDal.Models
{
    [DataContract]
    [Serializable]
    public class Route
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        [ForeignKey("AirlineId")]
        public Airline Airline { get; set; }
        [DataMember]
        public string AirlineId { get; set; }
        [DataMember]
        [ForeignKey("Origin")]
        [InverseProperty("OriginPorts")]
        public Airport OriginPort { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        [ForeignKey("Destination")]
        [InverseProperty("DestinationPorts")]
        public Airport DestinationPort { get; set; }
        [DataMember]
        public string Destination { get; set; }
    }
}
