using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class RoomData
{
    public static List<Room> GetRooms(int? id = null, int? BuildingId = null, int? Floor = null)
    {
        List<Room> rooms = new List<Room>();

        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spGetRooms", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (id.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmId", id.Value));
            if (BuildingId.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmBuildingId", BuildingId.Value));
            if (Floor.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmFloor", Floor.Value));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Room room = new Room();
                    room.Id = Convert.ToInt32(reader["Id"]);
                    room.BuildingId = Convert.ToInt32(reader["BuildingId"]);
                    room.Name = reader["Name"].ToString();
                    room.Floor = Convert.ToInt32(reader["Floor"]);
                    rooms.Add(room);
                }
            }
            conn.Close();
        }
        return rooms;
    }

    public static List<Room> GetAvailableRooms(DateTime StartTime, DateTime EndTime)
    {
        List<Room> rooms = new List<Room>();

        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spGetAvailableRooms", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@pmId", StartTime));
            cmd.Parameters.Add(new SqlParameter("@pmBuildingId", EndTime));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Room room = new Room();
                    room.Id = Convert.ToInt32(reader["Id"]);
                    room.BuildingId = Convert.ToInt32(reader["BuildingId"]);
                    room.Name = reader["Name"].ToString();
                    room.Floor = Convert.ToInt32(reader["Floor"]);
                    rooms.Add(room);
                }
            }
            conn.Close();
        }

        return rooms;
    }

    public static bool UpdateRoom(Room room)
    {
        bool result;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spUpdateRoom", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", room.Id));
            cmd.Parameters.Add(new SqlParameter("@pmBuildingId", room.BuildingId));
            cmd.Parameters.Add(new SqlParameter("@pmFloor", room.Floor));
            cmd.Parameters.Add(new SqlParameter("@pmName", room.Name));

            int noRows = cmd.ExecuteNonQuery();
            result = (noRows == 0) ? false : true;
            conn.Close();
        }
        return result;
    }

    public static int InsertRoom(Room room)
    {
        int newId;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spInsertRoom", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@pmBuildingId", room.BuildingId));
            cmd.Parameters.Add(new SqlParameter("@pmFloor", room.Floor));
            cmd.Parameters.Add(new SqlParameter("@pmName", room.Name));

            newId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
        return newId;
    }
}