using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GuestlogixDal.Models
{
    [DataContract]
    [Serializable]
    public class Airline
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        [Key]
        public string Code2 { get; set; }
        [DataMember]
        public string Code3 { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public List<Route> Routes { get; set; }
    }
}
