using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditUsers : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!Page.IsPostBack)
    {
      if (Request.Params["id"] != "")
      {
        string userId = Request.Params["id"];
        string query = "" +
          "select * " +
          "from AspNetUsers " +
          "where Id = @userId";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        try
        {
          SqlCommand statement = new SqlCommand(query, connection);
          statement.Parameters.AddWithValue("userId", userId);

          SqlDataReader result = statement.ExecuteReader();
          if (result.Read())
          {
            FirstName.Text = result["FirstName"].ToString();
            LastName.Text = result["LastName"].ToString();
            Email.Text = result["Email"].ToString();
            PhoneNumber.Text = result["PhoneNumber"].ToString();
          }
          else
          {
            ErrorMessage.Text = "No data.";
          }
        }
        catch (Exception exc)
        {
          ErrorMessage.Text = "Error: " + exc.Message;
        }
        finally
        {
          connection.Close();
        }
      }
    }
  }

  protected void UpdateUser_Click(object sender, EventArgs e)
  {
    if (Page.IsValid)
    {
      bool error = false;

      string firstName = FirstName.Text;
      string lastName = LastName.Text;
      string email = Email.Text;
      string phone = PhoneNumber.Text;

      Console.WriteLine(firstName);

      if (firstName == "")
      {
        ErrorMessage.Text = "First name field can't empty";
        error = true;
      }
      else if (lastName == "")
      {
        ErrorMessage.Text = "Last name field can't empty";
        error = true;
      }
      else if (email == "")
      {
        ErrorMessage.Text = "Email field can't empty";
        error = true;
      }
      else if (phone == "")
      {
        ErrorMessage.Text = "Phone number field can't empty";
        error = true;
      }

      if (!error)
      {
        string query = "" +
          "update AspNetUsers " +
          "set FirstName = @firstName, LastName = @lastName, Email = @email, PhoneNumber = @phone " +
          "where Id = @userId;";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();

        try
        {
          SqlCommand statement = new SqlCommand(query, connection);
          statement.Parameters.AddWithValue("firstName", firstName);
          statement.Parameters.AddWithValue("lastName", lastName);
          statement.Parameters.AddWithValue("email", email);
          statement.Parameters.AddWithValue("phone", phone);
          statement.Parameters.AddWithValue("userId", Request.Params["id"]);

          string selectedRole = Role.SelectedValue;
          if (selectedRole != "")
          {
            bool result;
            string connectionString = Database.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
              conn.Open();

              SqlCommand cmd = new SqlCommand("spUpdateRole", conn);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.Add(new SqlParameter("@pmUserId", Request.Params["id"]));
              cmd.Parameters.Add(new SqlParameter("@pmRoleName", selectedRole));

              int noRows = cmd.ExecuteNonQuery();
              result = (noRows == 0) ? false : true;
              conn.Close();
              if (result)
              {
                SuccessMessage.Text = "Updated role.";
              }
              else {
                ErrorMessage.Text = "Failed to update role.";
              }
            }
          }

          int updated = statement.ExecuteNonQuery();

          if (updated > 0)
          {
            SuccessMessage.Text += "Updated data.";
          }
          else
          {
            ErrorMessage.Text += "Error updating data.";
          }
        }
        catch (Exception exc)
        {
          ErrorMessage.Text = "Error: " + exc.Message;
        }
        finally
        {
          connection.Close();
        }
      }
    }
    else
    {
      ErrorMessage.Text = "Page not valid";
    }
  }
}