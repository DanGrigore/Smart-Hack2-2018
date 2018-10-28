<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InviteUsers.aspx.cs" Inherits="Manager_InviteUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div>
        <br /><br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
       
    </div>
    <dialog id="myDialog">
        <select>
            <option value="volvo">Volvo</option>
            <option value="saab">Saab</option>
            <option value="mercedes">Mercedes</option>
            <option value="audi">Audi</option>
        </select>This is a dialog window
    </dialog>

    <script>
        function myFunction() {
            document.getElementById("myDialog").showModal();
        }
    </script>

</asp:Content>

