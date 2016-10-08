using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models
{
    public class Location
    {
        public float latitude;
        public float longitude;
        public string address;
        public string city;
        public string state;
        public int floor;
        public string notes;

        public Location()
        {
            latitude = 0;
            longitude = 0;
            address = "";
            city = "";
            state = "";
            floor = 1;
            notes = "";
        }
    }
}