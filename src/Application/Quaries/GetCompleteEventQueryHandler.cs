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
    public class GetCompleteEventQueryHandler : IRequestHandler<GetCompleteEventQuery,IEnumerable<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCompleteEventQueryHandler(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }

        public async Task<IEnumerable<Event>> Handle(GetCompleteEventQuery request, CancellationToken cancellationToken)
        {
            return await this._unitOfWork.EventRepository.GetCompleteEvents();
        }
    }
}
