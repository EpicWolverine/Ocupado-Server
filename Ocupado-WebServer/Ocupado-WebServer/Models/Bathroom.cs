using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models
{
    public class Bathroom
    {
        private int id;
        public Location location { get; private set; }
        public List<Stall> stalls { get; private set; }
        public int numberWaiting { get; private set; }

        public Bathroom()
        {

        }

        public bool LoadData(int bathroomId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
            //get bathroom data, list of stalls
            //load stalls
            return true;
        }
    }
}