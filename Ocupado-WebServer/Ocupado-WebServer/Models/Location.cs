using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models
{
    public class Location
    {
        public float latitude { get; private set; }
        public float longitude { get; private set; }
        public string address { get; private set; }
        public string city { get; private set; }
        public string state { get; private set; }
        public int floor { get; private set; }
        public string notes { get; private set; }

        public Location()
        {
            latitude = 0;
            longitude = 0;
            address = "";
            city = "";
            state = "";
            floor = 0; //-1 = basement, 0 = ground floor if not first floor, 1 = first floor
            notes = "";
        }

        public bool LoadData(int bathroomId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
            return true;
        }
    }
}