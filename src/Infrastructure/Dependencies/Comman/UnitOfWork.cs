using AutoMapper;
using Domain.Dependencies.Repositories;
using Domain.Dependencies.Repositories.Comman;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dependencies.Comman
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventDbContext _dbContext;
        public IEventRepository EventRepository { get;}

        public UnitOfWork(IEventRepository eventRepository, EventDbContext dbContext) { this._dbContext = dbContext; this.EventRepository = eventRepository; }

        public Task SaveChanges() => _dbContext.SaveChangesAsync();
    }
}
