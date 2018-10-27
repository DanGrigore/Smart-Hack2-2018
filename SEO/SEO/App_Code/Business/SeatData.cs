using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class SeatData
{
    public static List<Seat> GetSeats(int? id = null, int? RoomId = null, int? Ox = null, int? Oy = null)
    {
        List<Seat> seats = new List<Seat>();

        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("'spGetSeats", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (id.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmId", id.Value));
            if (RoomId.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmRoomId", RoomId.Value));
            if (Ox.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmOx", Ox.Value));
            if (Oy.HasValue)
                cmd.Parameters.Add(new SqlParameter("@pmOy", Oy.Value));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Seat seat = new Seat();
                    seat.Id = Convert.ToInt32(reader["Id"]);
                    seat.RoomId = Convert.ToInt32(reader["RoomId"]);
                    seat.Ox = Convert.ToInt32(reader["Ox"]);
                    seat.Oy = Convert.ToInt32(reader["Oy"]);
                    seats.Add(seat);
                }
            }
            conn.Close();
        }

        return seats;
    }

    public static bool UpdateSeat(Seat seat)
    {
        bool result;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spUpdateSeat", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", seat.Id));
            cmd.Parameters.Add(new SqlParameter("@pmRoomId", seat.RoomId));
            cmd.Parameters.Add(new SqlParameter("@pmOx", seat.Ox));
            cmd.Parameters.Add(new SqlParameter("@pmOy", seat.Oy));

            int noRows = cmd.ExecuteNonQuery();
            result = (noRows == 0) ? false : true;
            conn.Close();
        }
        return result;
    }

    public static int InsertSeat(Seat seat)
    {
        int newId;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spInsertRoom", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmRoomId", seat.RoomId));
            cmd.Parameters.Add(new SqlParameter("@pmOx", seat.Ox));
            cmd.Parameters.Add(new SqlParameter("@pmOy", seat.Oy));

            newId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
        return newId;
    }
}