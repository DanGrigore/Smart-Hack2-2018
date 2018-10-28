﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditRoom.aspx.cs" Inherits="Admin_EditRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Edit user information.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group" runat="server">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
            </div>
        </div>
        <div class="form-group" runat="server">
            <asp:Label runat="server" AssociatedControlID="Floor" CssClass="col-md-2 control-label">Floor</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Floor" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Floor"
                    CssClass="text-danger" ErrorMessage="The floor field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="UpdateRoom_Click" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

