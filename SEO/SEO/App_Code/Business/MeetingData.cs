using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class MeetingData
{
    public static List<Meeting> GetMeetings(int? id = null, DateTime? StartTime = null, DateTime? EndTime = null, int? ManagerId = null, int? RoomId = null)
    {
        List<Meeting> meetings = new List<Meeting>();
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spGetMeetings", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (id.HasValue)
                cmd.Parameters.Add(new SqlParameter("pmId", id.Value));
            if (StartTime.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmStartTime", StartTime.Value));
            if (EndTime.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmEndTime", EndTime.Value));
            if (ManagerId.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmManagerId", ManagerId.Value));
            if (RoomId.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmRoomId", RoomId.Value));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Meeting meeting = new Meeting();
                    meeting.Id = Convert.ToInt32(reader["Id"]);
                    meeting.ManagerId = Convert.ToInt32(reader["ManagerId"]);
                    meeting.RoomId = Convert.ToInt32(reader["RoomId"]);
                    meeting.Name = reader["Name"].ToString();
                    meeting.StartTime = Convert.ToDateTime(reader["StartTime"]);
                    meeting.EndTime = Convert.ToDateTime(reader["EndTime"]);
                    meeting.Description = reader["Description"].ToString();
                    meetings.Add(meeting);
                }
            }
            conn.Close();
        }
        return meetings;
    }

    public static bool UpdateMeeting(Meeting meeting)
    {
        bool result;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spUpdateMeeting", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", meeting.Id));
            cmd.Parameters.Add(new SqlParameter("@pmManagerId", meeting.ManagerId));
            cmd.Parameters.Add(new SqlParameter("@pmRoomId", meeting.RoomId));
            cmd.Parameters.Add(new SqlParameter("@pmStartTime", meeting.StartTime));
            cmd.Parameters.Add(new SqlParameter("@pmEndTime", meeting.EndTime));
            cmd.Parameters.Add(new SqlParameter("@pmName", meeting.Name));
            cmd.Parameters.Add(new SqlParameter("@pmDescription", meeting.Description));

            int noRows = cmd.ExecuteNonQuery();
            result = (noRows == 0) ? false : true;
            conn.Close();
        }
        return result;
    }

    public static int InsertMeeting(Meeting meeting)
    {
        int newId;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spInsertMeeting", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@pmManagerId", meeting.ManagerId));
            cmd.Parameters.Add(new SqlParameter("@pmRoomId", meeting.RoomId));
            cmd.Parameters.Add(new SqlParameter("@pmStartTime", meeting.StartTime));
            cmd.Parameters.Add(new SqlParameter("@pmEndTime", meeting.EndTime));
            cmd.Parameters.Add(new SqlParameter("@pmName", meeting.Name));
            cmd.Parameters.Add(new SqlParameter("@pmDescription", meeting.Description));

            newId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
        return newId;
    }
}