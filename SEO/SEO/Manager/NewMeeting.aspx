<%@ Page Title="New meeting" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NewMeeting.aspx.cs" Inherits="Manager_NewMeeting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
  <p class="text-danger">
    <asp:Literal runat="server" ID="ErrorMessage" />
  </p>

  <div class="form-horizontal">
    <h4>Create a new meeting.</h4>
    <hr />
    <asp:ValidationSummary runat="server" CssClass="text-danger" />
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="Building" CssClass="col-md-2 control-label">Building</asp:Label>
      <div class="col-md-10">
        <asp:DropDownList ID="Building" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Select_Rooms">
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Building"
          CssClass="text-danger" ErrorMessage="You must select a building." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="StartTime" CssClass="col-md-2 control-label">Start time</asp:Label>
      <div class="col-md-10">
        <asp:TextBox ID="StartTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Select_Rooms"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="StartTime"
          CssClass="text-danger" ErrorMessage="The start time field can't be empty." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="EndTime" CssClass="col-md-2 control-label">End time</asp:Label>
      <div class="col-md-10">
        <asp:TextBox ID="EndTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Select_Rooms"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="EndTime"
          CssClass="text-danger" ErrorMessage="The end time field can't be empty." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="Rooms" CssClass="col-md-2 control-label">Rooms</asp:Label>
      <div class="col-md-10">
        <asp:DropDownList ID="Rooms" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Building"
          CssClass="text-danger" ErrorMessage="You must select a room." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
      <div class="col-md-10">
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
          CssClass="text-danger" ErrorMessage="The name field can't be empty." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
      <div class="col-md-10">
        <asp:TextBox ID="Description" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
          CssClass="text-danger" ErrorMessage="The description field can't be empty." />
      </div>
    </div>
  </div>
</asp:Content>
