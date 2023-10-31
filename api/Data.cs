using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using api.models;

namespace api
{
    public class Data
    {
        public static List<Activity> GetAllActivities()
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            List<Activity> activity = new List<Activity>();

            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Activities WHERE Deleted = 0 ORDER BY DateCompleted DESC;", con))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        activity.Add(new Activity
                        {
                            activityID = reader.GetInt32("ActivityID"),
                            activityType = reader.GetString("ActivityName"),
                            distance = reader.GetDouble("Distance"),
                            dateCompleted = reader.GetDateTime("DateCompleted").ToShortDateString(),
                            pinned = reader.GetBoolean("Pinned"),
                            deleted = reader.GetBoolean("Deleted")
                        });
                    }
                }
            }

            con.Close();
            return activity;
        }

    // public static Activity GetActivity(int activityID)
    // {
    //     Activity activity = null;

    //     Database db = new Database();
    //     using var con = new MySqlConnection(db.cs);
    //     con.Open();

    //     string stm = @"SELECT * FROM Activity WHERE activityID = @activityID";
    //     using var cmd = new MySqlCommand(stm, con);
    //     cmd.Parameters.AddWithValue("@activityID", activityID);

    //     using MySqlDataReader rdr = cmd.ExecuteReader();

    //     if (rdr.Read())
    //     {
    //         activity = new Activity
    //         {
    //             activityID = rdr.GetInt32("activityID"),
    //             activityType = rdr.GetString("activityType"),
    //             distance = rdr.GetDouble("distanceMiles"),
    //             dateCompleted = rdr.GetString("dateCompleted"),
    //             pinned = rdr.GetBoolean("pinned"),
    //             deleted = rdr.GetBoolean("deleted")
    //         };
    //     }

    //     con.Close();
    //     return activity;
    // }

        public static void AddActivity(Activity newActivity)
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = "INSERT INTO Activities(ActivityName, Distance, DateCompleted, Pinned, Deleted) VALUES(@ActivityName, @Distance, @DateCompleted, @Pinned, @Deleted)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ActivityName", newActivity.activityType);
            cmd.Parameters.AddWithValue("@Distance", newActivity.distance);
            cmd.Parameters.AddWithValue("@DateCompleted", DateTime.Parse(newActivity.dateCompleted));
            cmd.Parameters.AddWithValue("@Pinned", newActivity.pinned);
            cmd.Parameters.AddWithValue("@Deleted", newActivity.deleted);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void DeleteActivity(int activityID)
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = @"UPDATE Activities SET Deleted = !Deleted WHERE ActivityID = @ActivityID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ActivityID", activityID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void PinActivity(int activityID)
        {
            Database db = new Database();
            using var con = new MySqlConnection(db.cs);
            con.Open();

            string stm = @"UPDATE Activities SET Pinned = !Pinned WHERE ActivityID = @ActivityID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@ActivityID", activityID);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}