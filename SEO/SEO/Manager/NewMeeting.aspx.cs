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

  protected void Select_Rooms(object sender, EventArgs e) {

  }
}