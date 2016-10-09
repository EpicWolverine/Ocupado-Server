using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models {
    public class Location {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int floor { get; set; }
        public string notes { get; set; }

        public Location() {
            latitude = 0;
            longitude = 0;
            address = "";
            city = "";
            state = "";
            floor = 0; //-1 = basement, 0 = ground floor if not first floor, 1 = first floor
            notes = "";
        }
    }
}