using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ScheduleData
/// </summary>
public class ScheduleData
{
    public static void InsertSchedule(String userId, int meetingId, int seatId)
    {
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spInsertSchedules", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmUserId", userId));
            cmd.Parameters.Add(new SqlParameter("@pmMeetingId", meetingId));
            cmd.Parameters.Add(new SqlParameter("@pmSeatId", seatId));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    public static List<Schedule> GetSchedules(String UserId = null, int? MeetingId = null, int? SeatId = null)
    {
        List<Schedule> schedules = new List<Schedule>();

        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spGetSeatsByMeetingId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //if (UserId != null)
            //    cmd.Parameters.Add(new SqlParameter("@pmId", UserId));
            if (MeetingId.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmMeetingId", MeetingId.Value));
            //if (SeatId.HasValue)
            //    cmd.Parameters.Add(new SqlParameter("@pmSeatId", SeatId.Value));
            

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Schedule schedule = new Schedule();
                  //  schedule.UserId = reader["UserId"].ToString();
                    schedule.MeetingId = 2;
                    schedule.SeatId = Convert.ToInt32(reader["SeatId"]);
                    
                    schedules.Add(schedule);
                }
            }
            conn.Close();
        }

        return schedules;
    }
}