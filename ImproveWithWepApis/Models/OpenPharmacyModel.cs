using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ImproveWithWepApis.Models
{
    [DataContract]
    public class OpenPharmacyModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Dist { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Phone { get; set; }
    }
}