using EventIntegrator.Model;
using EventsApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {       

        private readonly ILogger<EventsController> _logger;
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository, ILogger<EventsController> logger)
        {
            _eventRepository = eventRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> Get()
        {
            try
            {
                var results = await _eventRepository.GetEventsAsync();
                if (!results.Any()) return NotFound();

                return base.Ok(results);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "DB Issue");
            }
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> Get(string id)
        {
            try
            {
                var result = await _eventRepository.GetEventAsync(id); 
                if (result == null) return NotFound();

                return base.Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "DB Issue");
            }
        }
    }
}
