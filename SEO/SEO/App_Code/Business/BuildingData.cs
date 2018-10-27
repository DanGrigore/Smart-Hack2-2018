using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEO;

public class BuildingData
{
    public static List<Building> GetAllBuildingsForCompany(int CompanyId)
    {
        List<Building> result = new List<Building>();
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spGetAllBuildingsForCompany", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmCompanyId", CompanyId));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Building b = new Building();
                    b.Id = Convert.ToInt32(reader["Id"]);
                    b.CompanyId = CompanyId;
                    b.Name = reader["Name"].ToString();
                    b.Address = reader["Address"].ToString();
                    result.Add(b);
                }
            }
            conn.Close();
        }
        return result;
    }

    public static Building SelectBuildingFromId(int id)
    {
        Building newBuilding = new Building();
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spSelectBuildingFromId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", id));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    newBuilding.Id = id;
                    newBuilding.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                    newBuilding.Name = reader["Name"].ToString();
                    newBuilding.Address = reader["Address"].ToString();
                }
            }
            conn.Close();
        }
        return newBuilding;
    }

    public static bool UpdateBuilding(Building building)
    {
        bool result;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spUpdateBuilding", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", building.Id));
            cmd.Parameters.Add(new SqlParameter("@pmAddress", building.Address));
            cmd.Parameters.Add(new SqlParameter("@pmCompanyId", building.CompanyId));
            cmd.Parameters.Add(new SqlParameter("@pmName", building.Name));

            int noRows = cmd.ExecuteNonQuery();
            result = (noRows == 0) ? false : true;
            conn.Close();
        }
        return result;
    }

    public static int InsertBuilding(Building building)
    {
        int newId;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spInsertBuilding", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add(new SqlParameter("@pmAddress", building.Address));
            cmd.Parameters.Add(new SqlParameter("@pmCompanyId", building.CompanyId));
            cmd.Parameters.Add(new SqlParameter("@pmName", building.Name));

            newId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
        return newId;
    }
}