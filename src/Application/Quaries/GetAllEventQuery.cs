using Domain.Dependencies.Repositories.Comman;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Quaries
{
    public class GetAllEventQuery : IRequest<PageList<Event>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
