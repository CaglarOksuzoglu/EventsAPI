using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsDB.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> Get();
        Task<Event> Get(int id);

        Task<Event> Create(Event item);
        Task Update(Event item);
        Task Delete(int id);
    }
}
