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
    public class GetPedndingEventHandler : IRequestHandler<GetPedningEventQuery, IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPedndingEventHandler(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }
        public Task<IEnumerable<Event>> Handle(GetPedningEventQuery request, CancellationToken cancellationToken)
        {
            return this._unitOfWork.EventRepository.GetPedningEvents();
        }
    }
}
