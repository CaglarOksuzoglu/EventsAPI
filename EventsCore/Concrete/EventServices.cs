using EventsDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsCore
{
    class EventServices
    {
        private AppDBContext _context;

        public EventServices(AppDBContext context)
        {
            _context = context;
        }

        public Event CreateEvent(Event item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

       

    }
}
