using Domain.Dependencies.Repositories;
using Domain.Dependencies.Repositories.Comman;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Dependencies.Comman;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Dependencies
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly EventDbContext _context;
        private readonly IRedisCacheService _redisCache;
        private const string key = "events";
        public EventRepository(EventDbContext dbContext, IRedisCacheService redisCache):base(dbContext.Set<Event>()) { this._context = dbContext; _redisCache = redisCache; }

        public async Task<PageList<Event>> GetAll(int pageNumber, int pageSize)
        {
            IQueryable<Event> events;
            var pageList = new PageList<Event>();
            var data = _redisCache.Get<EventDto>(key);
            List<Event> result = new List<Event>();
            foreach (var item in data.ToList())
            {
                result.Add(Event.Create(item.Name, (int)item.Type, item.Address, item.City, item.Region, item.PostalCode, item.Country, item.Phone, item.startDate, item.endDate, item.UserId));
            }
            if(data is null)
            {
                events = this._context.Events.AsQueryable();
                _redisCache.Set(key, events);
               
                return await pageList.GetPageList(events, pageNumber, pageSize);
            }
            return await pageList.GetPageList(result.AsQueryable(), pageNumber, pageSize);
        }

        public async Task<IEnumerable<Event>> GetCompleteEvents()
        {
           var completeEvents  =  _context.Events.Where(x => x.startDate < DateTime.UtcNow);
            if(completeEvents.ToList().Count < 0 ) { throw new Exception("No record found"); }
            return (IEnumerable<Event>)completeEvents;
        }

        public async Task<IEnumerable<Event>> GetPedningEvents()
        {
            var completeEvents = _context.Events.Where(x => x.startDate > DateTime.UtcNow);
            if (completeEvents.ToList().Count < 0) { throw new Exception("No record found"); }
            return (IEnumerable<Event>)completeEvents;
        }
    }
}
