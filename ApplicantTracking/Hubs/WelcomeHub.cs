using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ApplicantTracking
{
    public class WelcomeHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}