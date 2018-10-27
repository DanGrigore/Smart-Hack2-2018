using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class CompanyData
{
    public static List<Company> GetAllCompanies()
    {
        List<Company> result = new List<Company>();
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spGetAllCompanies", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Company company = new Company();
                    company.Id = Convert.ToInt32(reader["Id"]);
                    company.Cui = reader["Cui"].ToString();
                    company.Name = reader["Name"].ToString();
                    company.Address = reader["Address"].ToString();
                    result.Add(company);
                }
            }
            conn.Close();
        }
        return result;
    }

    public static Company SelectCompanyFromId(int id)
    {
        Company company = new Company();
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spSelectCompanyFromId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", id));

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    company.Id = id;
                    company.Cui = reader["Cui"].ToString();
                    company.Name = reader["Name"].ToString();
                    company.Address = reader["Address"].ToString();
                }
            }
            conn.Close();
        }
        return company;
    }

    public static bool UpdateCompany(Company company)
    {
        bool result;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spUpdateCompany", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmId", company.Id));
            cmd.Parameters.Add(new SqlParameter("@pmAddress", company.Address));
            cmd.Parameters.Add(new SqlParameter("@pmCui", company.Cui));
            cmd.Parameters.Add(new SqlParameter("@pmName", company.Name));

            int noRows = cmd.ExecuteNonQuery();
            result = (noRows == 0) ? false : true;
            conn.Close();
        }
        return result;
    }

    public static int InsertCompany(Company company)
    {
        int newId;
        string connectionString = Database.GetConnectionString();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("spInsertCompany", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@pmAddress", company.Address));
            cmd.Parameters.Add(new SqlParameter("@pmCui", company.Cui));
            cmd.Parameters.Add(new SqlParameter("@pmName", company.Name));

            newId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
        }
        return newId;
    }
}