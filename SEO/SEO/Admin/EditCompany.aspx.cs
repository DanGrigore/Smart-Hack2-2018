using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_EditCompany : System.Web.UI.Page
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
          "from Companies " +
          "where Id = @companyId";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        try
        {
          SqlCommand statement = new SqlCommand(query, connection);
          statement.Parameters.AddWithValue("companyId", companyId);

          SqlDataReader result = statement.ExecuteReader();
          if (result.Read())
          {
            Name.Text = result["Name"].ToString();
            Address.Text = result["Address"].ToString();
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

  protected void UpdateCompany_Click(object sender, EventArgs e)
  {
    if (Page.IsValid)
    {
      bool error = false;

      string name = Name.Text;
      string address = Address.Text;

      if (name == "")
      {
        ErrorMessage.Text = "Name field can't empty";
        error = true;
      }
      else if (address == "")
      {
        ErrorMessage.Text = "Address field can't empty";
        error = true;
      }

      if (!error)
      {
        string query = "" +
          "update Companies " +
          "set Name = @name, Address = @address " +
          "where Id = @companyId;";

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();

        try
        {
          SqlCommand statement = new SqlCommand(query, connection);
          statement.Parameters.AddWithValue("name", name);
          statement.Parameters.AddWithValue("address", address);
          statement.Parameters.AddWithValue("companyId", Request.Params["id"]);

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