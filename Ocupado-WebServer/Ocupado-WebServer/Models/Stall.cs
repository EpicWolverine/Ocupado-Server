using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models
{
    public class Stall
    {
        private int id;
        public bool occupied { get; set; }
        public bool attentionNeeded { get; set; }

        public Stall()
        {
            id = 0;
            occupied = false;
            attentionNeeded = false;
        }

        public bool LoadData(int stallId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
            return true;
        }
    }
}