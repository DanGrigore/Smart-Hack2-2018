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
            <asp:RoleGroup Roles="Manager, Admin, User">
                <ContentTemplate>
                    <!-- JS includes -->
                    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
                    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>

                    <script src="//ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js"></script>
                    <script src="//ajax.aspnetcdn.com/ajax/mvc/4.0/jquery.validate.unobtrusive.min.js"></script>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.16.0/moment.min.js"></script>
                    <script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.0.1/fullcalendar.min.js"></script>

                    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.0.1/fullcalendar.min.css">

                    <style type="text/css">
                        .field-validation-error {
                            color: #ff0000;
                        }
                    </style>
                    <script>
                        $(document).ready(function () {
                            var e = [];
                            var userId = $('#hfUserId').val();
                            $.ajax({
                                method: "GET",
                                url: "Services/CalendarJSonService.svc/GetMeetings/id=" + userId,
                                async: false,
                                success: function (data, status) {  
                                    var data = data;
                                    events = data.d;
                                    for (var index = 0; index < events.length; index++) {
                                        var event = {};
                                        event.title = events[index].Name;
                                        event.id = events[index].Id;
                                        event.start = moment(events[index].StartTime).format();
                                        event.end = moment(events[index].EndTime).format();
                                        e.push(event);
                                    }
                                },
                                error: function (data, status) {

                                }
                            });
                            $('#calendar').fullCalendar({
                                header: {
                                    left: 'prev,next today',
                                    center: 'title',
                                    right: 'month,agendaWeek,agendaDay'
                                },
                                selectable: true,
                                defaultView: 'agendaWeek',
                                firstDay: 1, //The day that each week begins (Monday=1)
                                slotMinutes: 60,
                                events: e,
                                eventClick: function (event) {
                                    // TODO TMG redirect for meeting view
                                }
                            });
                        });

                    </script>
                    <a runat="server" href="~/Manager/NewMeeting">Create new meeting</a>
                    <h1>Calendar</h1>
                    <div class="container">
                        <div id='calendar'></div>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
    <asp:HiddenField runat="server" ID="hfUserid" />
</asp:Content>
