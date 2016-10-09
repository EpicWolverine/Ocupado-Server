using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models {
    public class Stall {
        public int id { get; set; }
        public bool occupied { get; set; }
        public bool attentionNeeded { get; set; }

        public Stall() {
            id = 0;
            occupied = false;
            attentionNeeded = false;
        }

        public Stall(int stallId) {
            id = stallId;
            LoadData(stallId);
        }

        public bool LoadData(int stallId) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString)) {
                con.Open();
                //get bathroom data, list of stalls
                SqlCommand stallCmd = new SqlCommand("SELECT Occupied, AttentionNeeded FROM Stalls WHERE Id = @Id", con);
                stallCmd.Parameters.Add("@Id", SqlDbType.Int).Value = stallId;
                SqlDataReader stallReader = stallCmd.ExecuteReader();
                if (stallReader.HasRows) {
                    while (stallReader.Read()) {
                        id = stallId;
                        occupied = stallReader.GetBoolean(stallReader.GetOrdinal("Occupied"));
                        attentionNeeded = stallReader.GetBoolean(stallReader.GetOrdinal("AttentionNeeded"));
                    }
                }
                else {
                    return false; //No rows found
                }
                stallReader.Close();
            }
            return true;
        }

        public static bool UpdateStatus(Stall update) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString)) {
                con.Open();
                //get bathroom data, list of stalls
                SqlCommand stallCmd = new SqlCommand("UPDATE Stalls SET Occupied = @Occupied, AttentionNeeded = @AttentionNeeded WHERE Id = @Id", con);
                stallCmd.Parameters.Add("@Id", SqlDbType.Int).SqlValue = update.id;
                stallCmd.Parameters.Add("@Occupied", SqlDbType.Bit).SqlValue = update.occupied;
                stallCmd.Parameters.Add("@AttentionNeeded", SqlDbType.Bit).SqlValue = update.attentionNeeded;
                stallCmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}