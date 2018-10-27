<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <asp:LoginView runat="server">
    <AnonymousTemplate>
      <h1>Slide show</h1>
    </AnonymousTemplate>
    <LoggedInTemplate>
      <h1>Calendar</h1>
    </LoggedInTemplate>
    <RoleGroups>
      <asp:RoleGroup Roles="Manager, Admin">
        <ContentTemplate>
          <a runat="server" href="~/Manager/NewMeeting">Create new meeting</a>
          <h1>Calendar</h1>
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
  </asp:LoginView>  

</asp:Content>
