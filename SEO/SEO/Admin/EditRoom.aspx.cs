using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditRoom : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!Page.IsPostBack)
    {
      if (Request.Params["id"] != "")
      {
        string companyId = Request.Params["id"];
        string query = "" +
          "select * " +
          "from Rooms " +
          "where Id = @roomId";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        try
        {
          SqlCommand statement = new SqlCommand(query, connection);
          statement.Parameters.AddWithValue("roomId", companyId);

          SqlDataReader result = statement.ExecuteReader();
          if (result.Read())
          {
            Name.Text = result["Name"].ToString();
            Floor.Text = result["Floor"].ToString();
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

  protected void UpdateRoom_Click(object sender, EventArgs e)
  {
    if (Page.IsValid)
    {
      bool error = false;

      string name = Name.Text;
      string floor = Floor.Text;

      if (name == "")
      {
        ErrorMessage.Text = "Name field can't empty";
        error = true;
      }
      else if (floor == "")
      {
        ErrorMessage.Text = "Floor field can't empty";
        error = true;
      }

      if (!error)
      {
        string query = "" +
          "update Rooms " +
          "set Name = @name, Floor = @floor " +
          "where Id = @roomId;";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();

        try
        {
          SqlCommand statement = new SqlCommand(query, connection);
          statement.Parameters.AddWithValue("name", name);
          statement.Parameters.AddWithValue("floor", floor);
          statement.Parameters.AddWithValue("roomId", Request.Params["id"]);

          int updated = statement.ExecuteNonQuery();

          if (updated > 0)
          {
            SuccessMessage.Text = "Updated data.";
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