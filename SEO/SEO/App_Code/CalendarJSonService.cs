using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public class CalendarJSonService
{
    [OperationContract]
    [WebGet]
    public List<Meeting> GetMeetings()
    {
        return MeetingData.GetMeetings();
    }
}
