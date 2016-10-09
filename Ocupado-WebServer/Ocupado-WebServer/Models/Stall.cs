using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models
{
    public class Stall
    {
        public int id { get; private set; }
        public bool occupied { get; set; }
        public bool attentionNeeded { get; set; }

        public Stall()
        {
            id = 0;
            occupied = false;
            attentionNeeded = false;
        }

        public Stall(int stallId)
        {
            id = stallId;
            LoadData(stallId);
        }

        public bool LoadData(int stallId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
            {
                con.Open();
                //get bathroom data, list of stalls
                SqlCommand stallCmd = new SqlCommand("SELECT Occupied, AttentionNeeded FROM Stalls WHERE Id = @Id", con);
                stallCmd.Parameters.Add("@Id", SqlDbType.Int).SqlValue = stallId;
                SqlDataReader stallReader = stallCmd.ExecuteReader();
                if (stallReader.HasRows)
                {
                    while (stallReader.Read())
                    {
                        id = stallReader.GetInt32(0);
                        occupied = stallReader.GetBoolean(1);
                        attentionNeeded = stallReader.GetBoolean(2);
                    }
                }
                else
                {
                    return false; //No rows found
                }
                stallReader.Close();
            }
            return true;
        }
    }
}