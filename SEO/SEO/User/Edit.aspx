<%@ Page Title="Edit info" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="User_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
  <p class="text-danger">
    <asp:Literal runat="server" ID="ErrorMessage" />
  </p>
  <p class="text-success">
    <asp:Literal runat="server" ID="SuccessMessage" />
  </p>

  <div class="form-horizontal">
    <h3>Edit information</h3>
    <p>
      <a href="/Account/Manage" title="Change your password">Change password</a>
    </p>
    <hr />
    <asp:ValidationSummary runat="server" CssClass="text-danger" />
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First name</asp:Label>
      <div class="col-md-10">
        <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
          CssClass="text-danger" ErrorMessage="The first name field is required." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last name</asp:Label>
      <div class="col-md-10">
        <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
          CssClass="text-danger" ErrorMessage="The last name field is required." />
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
      <div class="col-md-10">
        <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
          CssClass="text-danger" ErrorMessage="The email field is required." />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="Email" ErrorMessage="Enter a valid email address." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
      </div>
    </div>
    <div class="form-group" runat="server">
      <asp:Label runat="server" AssociatedControlID="PhoneNumber" CssClass="col-md-2 control-label">Phone number</asp:Label>
      <div class="col-md-10">
        <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
          CssClass="text-danger" ErrorMessage="The phone number field is required." />
      </div>
    </div>
    <div class="form-group">
      <div class="col-md-offset-2 col-md-10">
        <asp:Button runat="server" OnClick="SaveUser_Click" Text="Save" CssClass="btn btn-default" />
      </div>
    </div>
  </div>

</asp:Content>

