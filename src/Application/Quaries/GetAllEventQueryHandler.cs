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
    public class GetAllEventQueryHandler : IRequestHandler<GetAllEventQuery, PageList<Event>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllEventQueryHandler(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }

        public async Task<PageList<Event>> Handle(GetAllEventQuery request, CancellationToken cancellationToken)
        {
            return await this._unitOfWork.EventRepository.GetAll(request.pageNumber, request.pageSize);
        }
    }
}
