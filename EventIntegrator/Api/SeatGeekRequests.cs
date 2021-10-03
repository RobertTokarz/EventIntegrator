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
    public class SeatGeekRequests
    {
        private static SeatGeekApiConfig _config;


        public async Task<List<EventModel>> GetEvents()
        {
            _config = new SeatGeekApiConfig("events", HttpMethod.Get);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(_config.RequestMessage()))
            {
                if (response.IsSuccessStatusCode)
                {
                    var eventsResponse = await response.Content.ReadAsStringAsync();
                    JObject jEventsObject = JObject.Parse(eventsResponse);
                    JArray jEvents = (JArray)jEventsObject["events"];
                    List<EventModel> events = jEvents.Select(x => new EventModel
                    {
                        Id = "EB-" + (string)x["id"],
                        Name = (string)x["title"],
                        EventId = (string)x["id"],
                        Date = GetDate(x), 
                        Time = GetTime(x),
                        Venue = (string)x["venue"]["name"],                        
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

        private string GetDate(JToken x)
        {
            return DateTime.Parse((string)x["datetime_local"]).ToString("yyyy-MM-dd");
        }

        private string GetTime(JToken x)
        {
            return DateTime.Parse((string)x["datetime_local"]).ToString("HH:mm");
        }
    }
}
