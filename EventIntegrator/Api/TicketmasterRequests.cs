using EventIntegrator.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventIntegrator.Api
{
    public class TicketmasterRequests 
    {
        private static TicketmasterApiConfig _config;


        public async Task<List<EventModel>> GetEvents()
        {
            _config = new TicketmasterApiConfig("events", HttpMethod.Get);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(_config.RequestMessage()))
            {
                if (response.IsSuccessStatusCode)
                {
                    var eventsResponse = await response.Content.ReadAsStringAsync();
                    JObject jEventsObject = JObject.Parse(eventsResponse);
                    JArray jEvents = (JArray)jEventsObject["_embedded"]["events"];


                    List<EventModel> events = jEvents.Select(x => new EventModel {
                        Id = "TM-" + (string)x["id"],
                        Name = (string)x["name"],
                        EventId = (string)x["id"],
                        Date = (string)x["dates"]["start"]["localDate"],
                        Time = (string)x["dates"]["start"]["localTime"],
                        Venue = (string)x["_embedded"]["venues"][0]["name"],
                        Promoter = GetPromoter(x),
                        Type = (string)x["type"]
                    }).ToList();
                    return events;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        private string GetPromoter(JToken x)
        {
            if( x["promoter"] != null)
            {
                return (string)x["promoter"]["name"];
            }

            return null;
        }
    }
}
