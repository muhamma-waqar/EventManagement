using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dependencies.Repositories.Comman
{
    public interface IUnitOfWork
    {
        public IEventRepository EventRepository { get; }
        Task SaveChanges();
    }
}
