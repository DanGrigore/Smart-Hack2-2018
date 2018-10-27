using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Edit : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!Page.IsPostBack) {
      string userId = User.Identity.GetUserId();
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
        else {
          ErrorMessage.Text = "No data.";
        }
      }
      catch (Exception exc) {
        ErrorMessage.Text = "Error: " + exc.Message;
      }
    }
  }

  protected void SaveUser_Click(object sender, EventArgs e)
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
          statement.Parameters.AddWithValue("userId", User.Identity.GetUserId());

          int updated = statement.ExecuteNonQuery();

          if (updated > 0)
          {
            SuccessMessage.Text = "Updated data";
          }
          else
          {
            ErrorMessage.Text = "Error updating data.";
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