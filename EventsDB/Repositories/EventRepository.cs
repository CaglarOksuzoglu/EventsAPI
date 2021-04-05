using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsDB.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDBContext _context;

        public EventRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<Event> Create(Event item)
        {
            _context.Events.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var eventToBeDeleted = await _context.Events.FindAsync(id);
            _context.Events.Remove(eventToBeDeleted);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> Get()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task Update(Event item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
