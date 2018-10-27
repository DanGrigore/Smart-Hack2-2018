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
      List <Building> result = BuildingData.GetAllBuildingsForCompany(1);
      for (int it = 0; it < result.Count; it++) {
        Building.Items.Insert(it, new ListItem(result[it].Name, result[it].Id.ToString()));
      }
    }
  }

  protected void Validate_Time(object sender, ServerValidateEventArgs e)
  {
    string[] datetime = e.Value.Split(' ');
    string[] date = datetime[0].Split('/');
    string[] time = datetime[1].Split(':');

    DateTime customDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
    if (DateTime.TryParse(customDate.ToString(), out DateTime result))
    {
      e.IsValid = true;
    }
    else {
      e.IsValid = false;
    }
  }

  protected void Select_Rooms(object sender, EventArgs e) {

  }

  protected void CreateMeeting_Click(object sender, EventArgs e)
  {

  }
}