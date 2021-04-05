using EventsDB;
using EventsDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace EventsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvents(int id)
        {
            return await _eventRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvents([FromBody] Event item)
        {
            var newEvent = await _eventRepository.Create(item);
            return CreatedAtAction(nameof(GetEvents), new { id = newEvent.EventID }, newEvent);
        }

        [HttpPut]
        public async Task<ActionResult> PutEvents(int id, [FromBody] Event item)
        {
            if (id != item.EventID)
            {
                return BadRequest();
            }

            await _eventRepository.Update(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eventToBeDeleted = await _eventRepository.Get(id);
            if (eventToBeDeleted == null)
                return NotFound();

            await _eventRepository.Delete(eventToBeDeleted.EventID);
            return NoContent();
        }
    }
}
