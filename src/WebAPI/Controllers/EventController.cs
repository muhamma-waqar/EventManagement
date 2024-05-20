using Application.Commands;
using Application.Quaries;
using Domain.Dependencies.Repositories.Comman;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator) { this._mediator = mediator; }

        [HttpPost]
        [Route("event/create")]
        public async Task<ActionResult<Event>> Create([FromBody] AddEventCommand command)
        {
           var result = await this._mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("event/getcompleteevent")]
        public async Task<ActionResult<IEnumerable<Event>>> GetompleteEvent([FromQuery] GetCompleteEventQuery query)
        {
            var completeEvents = await this._mediator.Send(query);
            return Ok(completeEvents);
        }

        [HttpGet]
        [Route("event/getpendingevent")]
        public async Task<ActionResult<IEnumerable<Event>>> GetPendingEvent([FromQuery] GetPedningEventQuery query)
        {
            var pendingEvents = await this._mediator.Send(query);
            return Ok(pendingEvents);
        }

        [HttpGet]
        [Route("getAll/events")]
        public async Task<ActionResult<PageList<Event>>> GetAll([FromQuery] GetAllEventQuery query)
        {
            var events = await this._mediator.Send(query);
            return Ok(events);
        }
    }
}
