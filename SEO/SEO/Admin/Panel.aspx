<%@ Page Title="Admin panel" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="Admin_Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

  <h1>view tables</h1>

  <h2>Companies</h2>
  <asp:SqlDataSource ID="CompanySDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Companies"></asp:SqlDataSource>
  <asp:ListView ID="Companies" runat="server" DataSourceID="CompanySDS" ItemPlaceholderID="CompanyPlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">CUI</th>
          <th runat="server">Name</th>
          <th runat="server">Address</th>
        </tr>
        <tr runat="server" ID="CompanyPlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("Id") %></td>
        <td><%# Eval("Cui") %></td>      
        <td><%# Eval("Name") %></td>
        <td><%# Eval("Address") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

  <h2>Buildings</h2>
  <asp:SqlDataSource ID="BuildingSDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Buildings"></asp:SqlDataSource>
  <asp:ListView ID="ListView1" runat="server" DataSourceID="BuildingSDS" ItemPlaceholderID="BuildingPlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">CompanyId</th>
          <th runat="server">Name</th>
          <th runat="server">Address</th>
        </tr>
        <tr runat="server" ID="BuildingPlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("Id") %></td>
        <td><%# Eval("CompanyId") %></td>      
        <td><%# Eval("Name") %></td>
        <td><%# Eval("Address") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

  <h2>Rooms</h2>
  <asp:SqlDataSource ID="RoomSDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Rooms"></asp:SqlDataSource>
  <asp:ListView ID="ListView2" runat="server" DataSourceID="RoomSDS" ItemPlaceholderID="RoomPlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">BuildingId</th>
          <th runat="server">Name</th>
          <th runat="server">Floor</th>
        </tr>
        <tr runat="server" ID="RoomPlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("Id") %></td>
        <td><%# Eval("BuildingId") %></td>      
        <td><%# Eval("Name") %></td>
        <td><%# Eval("Floor") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

  <h2>Seats</h2>
  <asp:SqlDataSource ID="SeatSDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Seats"></asp:SqlDataSource>
  <asp:ListView ID="ListView3" runat="server" DataSourceID="SeatSDS" ItemPlaceholderID="SeatPlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">RoomId</th>
          <th runat="server">Ox</th>
          <th runat="server">Oy</th>
        </tr>
        <tr runat="server" ID="SeatPlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("Id") %></td>
        <td><%# Eval("RoomId") %></td>      
        <td><%# Eval("Ox") %></td>
        <td><%# Eval("Oy") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

  <h2>Meetings</h2>
  <asp:SqlDataSource ID="MeetingSDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Meetings"></asp:SqlDataSource>
  <asp:ListView ID="ListView6" runat="server" DataSourceID="MeetingSDS" ItemPlaceholderID="MeetingPlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">RoomId</th>
          <th runat="server">Start time</th>
          <th runat="server">End time</th>
          <th runat="server">Name</th>
          <th runat="server">Description</th>
        </tr>
        <tr runat="server" ID="MeetingPlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("Id") %></td>
        <td><%# Eval("RoomId") %></td>      
        <td><%# Eval("StartTime") %></td>
        <td><%# Eval("EndTime") %></td>  
        <td><%# Eval("Name") %></td>
        <td><%# Eval("Description") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

  <h2>Schedules</h2>
  <asp:SqlDataSource ID="ScheduleSDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from Schedules"></asp:SqlDataSource>
  <asp:ListView ID="ListView4" runat="server" DataSourceID="ScheduleSDS" ItemPlaceholderID="SchedulePlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">UserId</th>
          <th runat="server">MeetingId</th>
          <th runat="server">SeatId</th>
          <th runat="server">Confirmed</th>
        </tr>
        <tr runat="server" ID="SchedulePlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("UserId") %></td>
        <td><%# Eval("MeetingId") %></td>      
        <td><%# Eval("SeatId") %></td>
        <td><%# Eval("Confirmed") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

  <h2>Users</h2>
  <asp:SqlDataSource ID="UserSDS" runat="server" ConnectionString='<%$ connectionStrings:DefaultConnection %>' SelectCommand="select * from AspNetUsers"></asp:SqlDataSource>
  <asp:ListView ID="ListView5" runat="server" DataSourceID="UserSDS" ItemPlaceholderID="UserPlaceholder" >
    <LayoutTemplate>
      <table class="database-table" runat="server">
        <tr runat="server">
          <th runat="server">Id</th>
          <th runat="server">First name</th>
          <th runat="server">Last name</th>
          <th runat="server">Username</th>
          <th runat="server">Password</th>
          <th runat="server">Email</th>
          <th runat="server">Phone number</th>
        </tr>
        <tr runat="server" ID="UserPlaceholder"></tr>
      </table>
    </LayoutTemplate>
    <ItemTemplate>
      <tr>
        <td><%# Eval("Id") %></td>
        <td><%# Eval("FirstName") %></td>      
        <td><%# Eval("LastName") %></td>
        <td><%# Eval("Username") %></td>  
        <td><%# Eval("PasswordHash") %></td>
        <td><%# Eval("Email") %></td>
        <td><%# Eval("PhoneNumber") %></td>
      </tr>
    </ItemTemplate>
  </asp:ListView>

</asp:Content>

