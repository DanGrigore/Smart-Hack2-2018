using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_NewMeeting : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!Page.IsPostBack)
    {
      string query = "" +
        "select * " +
        "from Buildings;";

      SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
      connection.Open();
      try
      {
        SqlCommand statement = new SqlCommand(query, connection);
        SqlDataReader result = statement.ExecuteReader();

        while (result.Read()) {
          Building.Items.Insert(Building.Items.Count, new ListItem(result["Name"].ToString(), result["Id"].ToString()));
        }
      }
      catch (Exception exc) {
        ErrorMessage.Text = "Error: " + exc.Message;
      } finally {
        connection.Close();
      }
    }
  }

  protected void Select_Rooms(object sender, EventArgs e) {

  }
}