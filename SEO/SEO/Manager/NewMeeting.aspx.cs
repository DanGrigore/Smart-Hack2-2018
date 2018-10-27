using Microsoft.AspNet.Identity;
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
      List<Building> result = BuildingData.GetAllBuildingsForCompany(1);
      for (int it = 0; it < result.Count; it++)
      {
        Building.Items.Insert(it, new ListItem(result[it].Name, result[it].Id.ToString()));
      }
    }
  }
  protected DateTime GetTime(string inputDatetime)
  {
    if (inputDatetime == "") {
      return new DateTime();
    }
    string[] datetime = inputDatetime.Split(' ');
    string[] date = datetime[0].Split('/');
    string[] time = datetime[1].Split(':');

    DateTime customDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
    return customDate;
  }

  protected void Validate_Time(object sender, ServerValidateEventArgs e)
  {
    DateTime customDate = GetTime(e.Value);
    if (DateTime.TryParse(customDate.ToString(), out DateTime result))
    {
      e.IsValid = true;
    }
    else
    {
      e.IsValid = false;
    }
  }

  protected Boolean CustomTime_Validate(string inputDatetime)
  {
    DateTime customDate = GetTime(inputDatetime);
    if (DateTime.TryParse(customDate.ToString(), out DateTime result))
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  protected void Select_Rooms(object sender, EventArgs e)
  {
    if (StartTime.Text != "" && CustomTime_Validate(StartTime.Text))
    {
      if (EndTime.Text != "" && CustomTime_Validate(EndTime.Text))
      {
        int buildingId = int.Parse(Building.SelectedValue);
        DateTime startTime = GetTime(StartTime.Text);
        DateTime endTime = GetTime(EndTime.Text);

        List<Room> result = RoomData.GetAvailableRooms(startTime, endTime, buildingId);
        for (int it = 0; it < result.Count; it++) {
          Room.Items.Insert(it, new ListItem(result[it].Name, result[it].Id.ToString()));
        }
      }
      else
      {
        ErrorMessage.Text = "Invalid end time.";
      }
    }
    else
    {
      ErrorMessage.Text = "Invalid start time.";
    }
  }

  protected void CreateMeeting_Click(object sender, EventArgs e)
  {
    if (Page.IsValid)
    {
      Meeting newMeeting = new Meeting();

      newMeeting.ManagerId = User.Identity.GetUserId();
      newMeeting.RoomId = int.Parse(Room.SelectedValue);
      newMeeting.StartTime = GetTime(StartTime.Text);
      newMeeting.EndTime = GetTime(EndTime.Text);
      newMeeting.Name = Name.Text;
      newMeeting.Description = Description.Text;

      int newMeetingId = MeetingData.InsertMeeting(newMeeting);
      if (newMeetingId != 0)
      {
        SuccessMessage.Text = "Created new meeting.";
      }
      else {
        ErrorMessage.Text = "Couldn't create new meeting. Try again.";
      }
    }
  }
}