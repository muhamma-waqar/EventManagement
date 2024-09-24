using Application.Commands;
using Application.Quaries;
using Domain.Dependencies.Repositories.Comman;
using Domain.Entities;
using Grpc.Net.Client;
using Infrastructure.Identity.Core.Services;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Security.Principal;

namespace WebAPI.Controllers
{
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProvider _userIdProvider;

       // private readonly School.Student.TestGrpc.TestGrpcClient _testGrpcClient;
       private readonly School.Student.TestGrpcStream.TestGrpcStreamClient _testGrpcStreamClient;
        public EventController(IMediator mediator, IUserProvider userProvider, School.Student.TestGrpcStream.TestGrpcStreamClient client) 
        { 
            this._testGrpcStreamClient = client;
            this._mediator = mediator;
            this._userIdProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
        }

        [HttpPost]
        [Route("event/create")]
        public async Task<ActionResult> CreateAsync([FromBody] AddEventCommand command)
        {
            //using var channel = GrpcChannel.ForAddress("https://localhost:7299");
            var response =  this._testGrpcStreamClient.GetStudentStream(new School.Student.StudentSteamingRequest { Id = "1" });
            command.UserId = this._userIdProvider.GetUserId();
            //response.ResponseStream.Current
            //var resutl = new Event()
            //var result = await this._mediator.Send(command);
            return Ok(response.ResponseStream.Current);
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

        [HttpPost]
        [Route("getAll/events")]
        public async Task<ActionResult<PageList<Event>>> GetAll([FromQuery] GetAllEventQuery query)
        {
            var events = await this._mediator.Send(query);
            return Ok(events);
        }
    }
}
