using EventIntegrator.Api;
using EventIntegrator.Controller;
using EventIntegrator.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EventIntegrator
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ApiHelper.InitializeClient();
            EventController eC = new EventController();
            eC.Add(GetTicketMasterEvents());
            eC.Add(GetEventBriteEventsAsync());
        }



        private static List<EventModel> GetTicketMasterEvents()
        {
            TicketmasterRequests tm = new TicketmasterRequests();
            List<EventModel> events = tm.GetEvents().Result;
            return events; 
        }

        private static List<EventModel> GetEventBriteEventsAsync()
        {
            SeatGeekRequests sg = new SeatGeekRequests();
            List<EventModel> events = sg.GetEvents().Result;
            return events;
        }

    }
}        
    



