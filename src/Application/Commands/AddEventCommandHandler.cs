using Domain.Dependencies.Repositories.Comman;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand, Event>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddEventCommandHandler(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }
        public async Task<Event> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var eventData = Event.Create(request.Name, request.Description, (int)request.Type, request.Address, request.City, request.Region, request.PostalCode, request.Country, request.Phone, request.startDate, request.endDate);
            var result = await _unitOfWork.EventRepository.Add(eventData);
            return result;
        }
    }
}
