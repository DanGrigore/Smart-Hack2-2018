<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <asp:LoginView runat="server">
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
          <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
  </asp:LoginView>

</asp:Content>
