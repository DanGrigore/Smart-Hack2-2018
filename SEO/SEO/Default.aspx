<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <h1 runat="server" id="Message"></h1>
  <asp:Literal runat="server" ID="UserId" Text="" Visible="false" />
  <asp:LoginView ID="LoginView" runat="server">
    <AnonymousTemplate>
      <div id="slideshow-container">
        <span id="company-name">SEO</span>
        <img class="slideshow" src="/images/img1.jpg" alt="" />
        <img class="slideshow hidden" src="/images/img2.jpg" alt="" />
        <img class="slideshow hidden" src="/images/img3.jpg" alt="" />
        <script>
          let slideshow = document.getElementById("slideshow");
          let images = document.querySelectorAll("#slideshow-container .slideshow");
          let currentImage = 0;

          setInterval(function () {
            if (++currentImage < images.length) {
              images[currentImage - 1].className = "slideshow hidden";
              images[currentImage].className = "slideshow";
            } else {
              currentImage = 0;
              images[images.length - 1].className = "slideshow hidden";
              images[currentImage].className = "slideshow";
            }
          }, 5000);
        </script>
      </div>
    </AnonymousTemplate>
    <LoggedInTemplate>
      <h1>Calendar</h1>
    </LoggedInTemplate>
    <RoleGroups>
      <asp:RoleGroup Roles="Manager, Admin">
        <ContentTemplate>
          <a runat="server" href="~/Manager/NewMeeting">Create new meeting</a>
          <h1>Calendar</h1>
          <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Meetings where ManagerId = @managerId">
            <SelectParameters>
              <asp:ControlParameter Name="managerId" ControlID="UserId" PropertyName="Text" />
            </SelectParameters>
          </asp:SqlDataSource>
          <asp:ListView ID="ListView" runat="server" DataSourceID="SqlDataSource" ItemPlaceholderID="placeholder">
            <LayoutTemplate>
              <table class="table">
                <asp:PlaceHolder runat="server" ID="placeholder" />
              </table>
            </LayoutTemplate>
            <ItemTemplate>
              <tr runat="server">
                <td><%#Eval("Id") %></td>
                <td><%#Eval("StartTime") %></td>
                <td><%#Eval("EndTime") %></td>
                <td><%#Eval("RoomId") %></td>
                <td><a href="/Manager/InviteUsers.aspx?id=<%#Eval("Id") %>">Invite users</a></td>
              </tr>
            </ItemTemplate>
          </asp:ListView>
          <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
  </asp:LoginView>

</asp:Content>
