using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ImproveWithWebApi.Models
{
    public class ValuesByCountryModel
    {
        public string Country { get; set; }

        public string TotalCases { get; set; }

        public string NewCases{ get; set; }

        public string TotalDeaths { get; set; }

        public string NewDeaths { get; set; }

        public string TotalRecovered { get; set; }

        public string ActiveCases { get; set; }
    }
}