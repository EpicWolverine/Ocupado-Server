using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ocupado_WebServer.Models {
    public class Bathroom {
        public int id { get; private set; }
        public Location location { get; private set; }
        public List<Stall> stalls { get; private set; }
        public int numberWaiting { get; private set; }

        public Bathroom() {
            id = 0;
            location = new Location();
            stalls = new List<Stall>();
            numberWaiting = 0;
        }

        public bool LoadData(int bathroomId) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString)) {
                con.Open();
                //get bathroom data, list of stalls
                SqlCommand bathroomCmd = new SqlCommand("SELECT [Id], [NumberWaiting], [GPS].Lat, [GPS].Long, [Address], [City], [State], [Floor], [Notes] FROM Bathrooms WHERE [Id] = @Id", con);
                bathroomCmd.Parameters.Add("@Id", SqlDbType.Int).SqlValue = bathroomId;
                SqlDataReader bathroomReader = bathroomCmd.ExecuteReader();
                if (bathroomReader.HasRows) {
                    while (bathroomReader.Read()) {
                        id = bathroomReader.GetInt32(0);
                        numberWaiting = bathroomReader.GetInt32(1);
                        location.latitude = bathroomReader.GetDecimal(2);
                        location.longitude = bathroomReader.GetDecimal(3);
                        location.address = bathroomReader.GetString(4);
                        location.city = bathroomReader.GetString(5);
                        location.state = bathroomReader.GetString(6);
                        location.floor = bathroomReader.GetInt32(7);
                        location.notes = bathroomReader.GetString(8);
                    }
                }
                else {
                    return false; //No rows found
                }
                bathroomReader.Close();

                //load stalls
                SqlCommand stallsCmd = new SqlCommand("SELECT StallId FROM StallsInBathrooms WHERE BathroomId = @BathroomId", con);
                bathroomCmd.Parameters.Add("@BathroomId", SqlDbType.Int).SqlValue = bathroomId;
                SqlDataReader stallsReader = stallsCmd.ExecuteReader();
                if (stallsReader.HasRows) {
                    while (stallsReader.Read()) {
                        stalls.Add(new Stall(stallsReader.GetInt32(0)));
                    }
                }
                else {
                    return false; //No rows found
                }
                stallsReader.Close();

                return true;
            }
        }

        public static List<Bathroom> LoadAll() {
            List<Bathroom> bathrooms = new List<Bathroom>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString)) {
                con.Open();

                //get bathroom data, list of stalls
                SqlCommand bathroomCmd = new SqlCommand("SELECT [Id], [NumberWaiting], [GPS].Lat, [GPS].Long, [Address], [City], [State], [Floor], [Notes] FROM Bathrooms", con);
                SqlDataReader bathroomReader = bathroomCmd.ExecuteReader();
                if (bathroomReader.HasRows) {
                    while (bathroomReader.Read()) {
                        Bathroom tempBathroom = new Bathroom();
                        tempBathroom.id = bathroomReader.GetInt32(0);
                        tempBathroom.numberWaiting = bathroomReader.GetInt32(1);
                        tempBathroom.location.latitude = bathroomReader.GetDecimal(2);
                        tempBathroom.location.longitude = bathroomReader.GetDecimal(3);
                        tempBathroom.location.address = bathroomReader.GetString(4);
                        tempBathroom.location.city = bathroomReader.GetString(5);
                        tempBathroom.location.state = bathroomReader.GetString(6);
                        tempBathroom.location.floor = bathroomReader.GetInt32(7);
                        tempBathroom.location.notes = bathroomReader.GetString(8);

                        //load stalls
                        SqlCommand stallsCmd = new SqlCommand("SELECT StallId FROM StallsInBathrooms WHERE BathroomId = @BathroomId", con);
                        bathroomCmd.Parameters.Add("@BathroomId", SqlDbType.Int).SqlValue = tempBathroom.id;
                        SqlDataReader stallsReader = stallsCmd.ExecuteReader();
                        if (stallsReader.HasRows) {
                            while (stallsReader.Read()) {
                                tempBathroom.stalls.Add(new Stall(stallsReader.GetInt32(0)));
                            }
                        }
                        stallsReader.Close();

                        bathrooms.Add(tempBathroom);
                    }
                }
                bathroomReader.Close();

                return bathrooms;
            }
        }
    }
}