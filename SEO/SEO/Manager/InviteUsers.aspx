<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InviteUsers.aspx.cs" Inherits="Manager_InviteUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div>
        <br />
        <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

    </div>
    <dialog id="popUp">
        <p>Invitat:</p>
        <asp:DropDownList ID="selectOpt" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="submitButton" runat="server" Text="Add" OnClick="SubmitButton_Click" />
    </dialog>

    <input type="hidden" runat="server" id="row" />
    <input type="hidden" runat="server" id="col" />

    <script>
        //console.log("Test");
        //window.onload = function () {
        //    Array.from(document.querySelectorAll(td)).forEach(function (element) {
        //        console.log(element);
        //        element.onclick = function () {
        //            document.getElementById("row").value = this.getAttribute("data-row");
        //            document.getElementById("row").value = document.getElementById("col").value = this.getAttribute("data-col");
        //            document.getElementById("popUp").showModal();
        //        }();
        //    });
        //}
        function openPopUp(element) {
            console.log(element);
            document.getElementById("MainContent_row").value = element.getAttribute("data-row");
            document.getElementById("MainContent_col").value = element.getAttribute("data-col");
            document.getElementById("popUp").showModal();
        }

        function changeColor(x, y) {
            var table = documnet.getElementById("tableMap");
            table.rows[i].cells[j].className = "reserved";
        }
    </script>

</asp:Content>

