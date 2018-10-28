using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

struct Point
{
    public int x, y;
}

struct Person
{
    public string FirstName, LastName, clientId;
}

public partial class Manager_InviteUsers : System.Web.UI.Page
{
    private List<Point> seatsAll;
    private bool added;
    protected int Rows
    {
        get { return ViewState["Rows"] != null ? (int)ViewState["Rows"] : 0; }
        set { ViewState["Rows"] = value; }
    }

    protected int Columns
    {
        get { return ViewState["Columns"] != null ? (int)ViewState["Columns"] : 0; }
        set { ViewState["Columns"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        CreateRuntime_Table();
        string rowVal = row.Value;
        string colVal = col.Value;
        List<Person> persons = new List<Person>();
        string query = "" +
            "select * " +
            "from AspNetUsers" +
            "";

        if (!Page.IsPostBack)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();
            try
            {
                SqlCommand statement = new SqlCommand(query, connection);

                SqlDataReader result = statement.ExecuteReader();
                while (result.Read())
                {
                    Person x;
                    x.FirstName = result["FIRSTNAME"].ToString();
                    x.LastName = result["LASTNAME"].ToString();
                    x.clientId = result["ID"].ToString();
                    persons.Add(x);
                }

            }
            catch (Exception exc)
            {

            }
        }

        for (int i = 0; i < persons.Count; i++)
            selectOpt.Items.Insert(i, new ListItem(persons[i].FirstName + " " + persons[i].LastName, persons[i].clientId));


    }

    private List<Point> refresh(int meetingId)
    {
        List<Point> points = new List<Point>(); ;
        if (seatsAll == null)
        {
            List<Schedule> schedules = ScheduleData.GetSchedules(MeetingId: 2);

            for (int i = 0; i < schedules.Count; i++)
            {
                Seat seat = SeatData.GetSeats(id: schedules[i].SeatId)[0];
                Point obj;
                obj.x = seat.Ox;
                obj.y = seat.Oy;
                points.Add(obj);
            }
            seatsAll = points.ToList<Point>();
        }
        else
            points = seatsAll;
          
        return points;
    }


    private void CreateRuntime_Table()
    {

        PlaceHolder1.Controls.Clear();

        int tableRows = 9;
        int tableCols = 10;

        List<Point> arr = refresh(2);
        if (arr == null)
        {
            Point plm;
            plm.x = 1;
            plm.y = 1;
            arr.Add(plm);
        }
            
        //Array.Sort<Point>(arr, (a, b) => a.x.CompareTo(b.x));
        arr.Sort((s1, s2) => s1.x.CompareTo(s2.x));
        int k = 0;

        Table table = new Table();
        table.Attributes["id"] = "tableMap";

        PlaceHolder1.Controls.Add(table);
        for (int i = 0; i < tableRows; i++)
        {
            TableRow tr = new TableRow();

            for (int j = 0; j < tableCols; j++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "tdMap";
                //tc.Attributes["location"] = i.ToString() + " " + j.ToString();
                tc.Attributes["data-row"] = i.ToString();
                tc.Attributes["data-col"] = j.ToString();
                
                if (2 * arr[k].x == i && arr[k].y == j && k < arr.Count())
                {
                    tc.CssClass += " reserved";
                    if (k >= arr.Count - 1) k = -1;
                    k++;
                }
                else
                {
                    if (j == tableCols / 2 || j == tableCols / 2 - 1 || i % 2 == 1)
                        tc.CssClass += " emptyLine";
                    else
                    {
                        tc.CssClass += " free";
                        tc.Attributes["onclick"] = "openPopUp(this)";
                    }
                }
                tr.Cells.Add(tc);
            }

            table.Rows.Add(tr);

        }


    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        String userId = selectOpt.SelectedValue;
        Seat seat = new Seat();
        seat.RoomId = MeetingData.GetMeetings(id: int.Parse(Request.Params["id"]))[0].RoomId;

        seat.Ox = int.Parse(row.Value);
        seat.Oy = int.Parse(col.Value);

        Seat seats = SeatData.GetSeats().Where(t => t.Ox == seat.Ox && t.Oy == seat.Oy && t.RoomId == seat.RoomId).FirstOrDefault();

        //string function = "changecolor(" + seat.ox.tostring() + "," + seat.oy.tostring() + ")";
        //page.clientscript.registerstartupscript(this.gettype(),"function", function, true);

        ScheduleData.InsertSchedule(userId, int.Parse(Request.Params["id"]), seats.Id);
        Seat temp = SeatData.GetSeats(seats.Id)[0];
        Point obj;
        obj.x = temp.Ox;
        obj.y = temp.Oy;

        seatsAll.Add(obj);
        CreateRuntime_Table();
    }
}