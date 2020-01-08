using System;
using System.Collections.Generic;

namespace Location_Service.Models
{
    public class RawLocation
    {
        public class Kommuner
        {
            public string href { get; set; }
            public string kode { get; set; }
            public string navn { get; set; }
        }

        public string href { get; set; }
        public string nr { get; set; }
        public string navn { get; set; }
        public object stormodtageradresser { get; set; }
        public List<double> bbox { get; set; }
        public List<double> visueltcenter { get; set; }
        public List<Kommuner> kommuner { get; set; }
        public DateTime __invalid_name__ændret { get; set; }
        public DateTime __invalid_name__geo_ændret { get; set; }
        public int geo_version { get; set; }
        public string dagi_id { get; set; }
    }
}