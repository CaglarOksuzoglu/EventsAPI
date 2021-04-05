using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsDB.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int id);

        Task<User> Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
