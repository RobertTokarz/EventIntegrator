using EventIntegrator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApi.Data
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventModel>> GetEventsAsync();
        Task<EventModel> GetEventAsync(string id);
    }
}
