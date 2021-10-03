using EventIntegrator.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventsApi.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDBContext _context;
        private readonly ILogger<EventRepository> _logger;

        public EventRepository(EventDBContext context, ILogger<EventRepository> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<EventModel> GetEventAsync(string id)
        {
            _logger.LogInformation($"Get event specified by id from DB.");
            IQueryable<EventModel> query = _context.Events.Where(x => x.Id == id);
           
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EventModel>> GetEventsAsync()
        {
            _logger.LogInformation($"Get all events from DB.");
            IQueryable<EventModel> query = _context.Events;

            return await query.ToListAsync();
        }
    }
}
