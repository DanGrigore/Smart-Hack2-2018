using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

struct Point
{
    public int x, y;
}

public partial class Manager_InviteUsers : System.Web.UI.Page
{
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

    }


    protected void btn_Click(object Sender, EventArgs e)
    {
        CreateRuntime_Table();
    }

    private void CreateRuntime_Table()
    {

        PlaceHolder1.Controls.Clear();

        int tableRows = 9;
        int tableCols = 10;

        Point[] arr = new Point[5];

        arr[0].x = 0;
        arr[0].y = 0;
        arr[1].x = 0;
        arr[1].y = 1;
        arr[2].x = 0;
        arr[2].y = 2;
        arr[3].x = 0;
        arr[3].y = 3;
        arr[4].x = 1;
        arr[4].y = 0;

        Array.Sort<Point>(arr, (a, b) => a.x.CompareTo(b.x));
        int k = 0;

        Table table = new Table();
        table.Attributes["id"] = "tableMap";
        PlaceHolder1.Controls.Add(table);
        for (int i = 0; i < tableRows; i++)
        {
            TableRow tr = new TableRow();
            //tr.CssClass = "trMap";

            for (int j = 0; j < tableCols; j++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "tdMap";
                //TextBox txtBox = new TextBox();
                //txtBox.Text = " " + i + " " + " " + j;
                //tc.Controls.Add(txtBox);
                if (2 * arr[k].x == i && arr[k].y == j)
                {
                    tc.CssClass += " reserved";
                    if (k >= arr.Length - 1) k = -1;
                    k++;
                }
                else
                {
                    if (j == tableCols / 2 || j == tableCols / 2 - 1 || i % 2 == 1)
                        tc.CssClass += " emptyLine";
                    else tc.CssClass += " free";
                    tc.Attributes["onclick"] = "myFunction()";
                }
                tr.Cells.Add(tc);
            }

            table.Rows.Add(tr);

        }


    }
}