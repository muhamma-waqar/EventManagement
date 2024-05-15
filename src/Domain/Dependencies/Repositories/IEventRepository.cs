using Domain.Dependencies.Repositories.Comman;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dependencies.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<IEnumerable<Event>> GetPedningEvents();
        Task<IEnumerable<Event>> GetCompleteEvents();

    }
}
