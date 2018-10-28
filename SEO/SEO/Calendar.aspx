﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

<!DOCTYPE html>
<!-- template from http://getbootstrap.com/getting-started -->

<html lang="en">
	<head>
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<title>Bootstrap 101 Template</title>

		<!-- CSS Includes -->
		<link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css">
		<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.0.1/fullcalendar.min.css">
			
		<style type="text/css">

			.field-validation-error {
				color: #ff0000;
			}

		</style>
	</head>
	
	<body>
		<div class="container">
			<div id='calendar'></div>
		</div>

		<!-- JS includes -->
		<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
		<script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
	
		<script src="//ajax.aspnetcdn.com/ajax/jquery.validate/1.11.1/jquery.validate.min.js"></script>
		<script src="//ajax.aspnetcdn.com/ajax/mvc/4.0/jquery.validate.unobtrusive.min.js"></script>
		<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.16.0/moment.min.js"></script>
		<script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.0.1/fullcalendar.min.js"></script>
		
		<script type="text/javascript">	
            $(document).ready(function () {
                var e = [];
                $.ajax({
                    method: "GET",
                    url: "Services/TestJSonService.svc/GetMeetings",
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
                            console.log(e);
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
	</body>
</html>