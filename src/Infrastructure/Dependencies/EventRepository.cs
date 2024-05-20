using Domain.Dependencies.Repositories;
using Domain.Dependencies.Repositories.Comman;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Dependencies.Comman;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dependencies
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly EventDbContext _context;
        public EventRepository(EventDbContext dbContext):base(dbContext.Set<Event>()) { this._context = dbContext; }

        public async Task<PageList<Event>> GetAll(int pageNumber, int pageSize)
        {
            var source = this._context.Events.AsQueryable();
            var pageList = new PageList<Event>();
            return await pageList.GetPageList(source, pageNumber, pageSize);
            
        }

        public async Task<IEnumerable<Event>> GetCompleteEvents()
        {
           var completeEvents  =  _context.Events.Where(x => x.startDate < DateTime.UtcNow && x.IsComplete == true );
            if(completeEvents.ToList().Count < 0 ) { throw new Exception("No record found"); }
            return (IEnumerable<Event>)completeEvents;
        }

        public async Task<IEnumerable<Event>> GetPedningEvents()
        {
            var completeEvents = _context.Events.Where(x => x.startDate > DateTime.UtcNow && x.IsComplete == false);
            if (completeEvents.ToList().Count < 0) { throw new Exception("No record found"); }
            return (IEnumerable<Event>)completeEvents;
        }
    }
}
