// using Microsoft.AspNetCore.Cors;
// using MySql.Data.MySqlClient;
// namespace api.models
// {
//     public class GenerateActivities
//     {
//         public List<Activity> GetAllActivities() {
//             List<Activity> myActivities = new List<Activity>();
//             Database db = new Database();

//             using var con = new MySqlConnection(db.cs);
//             con.Open();

//             string stm = "SELECT * FROM Activities ORDER BY dateCompleted desc;";
//             using var cmd = new MySqlCommand(stm, con);
//             using MySqlDataReader rdr = cmd.ExecuteReader();
//             while(rdr.Read())
//             {
//                 Activity temp = new Activity(){activityID = rdr.GetInt32(0), activityType = rdr.GetString(1), distance = rdr.GetString(2), dateCompleted = rdr.GetString(3), pinned = rdr.GetString(4), deleted = rdr.GetString(5)};
//                 myActivities.Insert(0, temp);
//             }
//             con.Close();
//             return myActivities;
//         }

//         public Activity GetActivity(int activityID)
//         {
//             Database db = new Database();
//             using var con = new MySqlConnection(db.cs);
//             con.Open();

//             string stm = @"SELECT * FROM Activities WHERE activityID = @activityID;";
//             using var cmd = new MySqlCommand(stm, con);
//             cmd.Parameters.AddWithValue("@activityID", activityID);
            
//             using MySqlDataReader rdr = cmd.ExecuteReader();
    
//             if (rdr.Read())
//             {
//                 return new Activity()
//                 {
//                     activityID = rdr.GetInt32("activityID"),
//                     activityType = rdr.GetString("activityType"),
//                     distance = rdr.GetString("distance"),
//                     dateCompleted = rdr.GetString("dateCompleted"),
//                     pinned = rdr.GetString("pinned"),
//                     deleted = rdr.GetString("deleted") 
//                 };
//             }
            
//             return null;  
//         }
//     }
// }