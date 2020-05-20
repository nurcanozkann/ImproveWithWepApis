using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ImproveWithWepApis.Models
{
    [DataContract]
    public class TotalValueModel
    {
        [DataMember]
        public string TotalDeaths { get; set; }

        [DataMember]
        public string TotalCases { get; set; }

        [DataMember]
        public string TotalRecovered { get; set; }
    }
}