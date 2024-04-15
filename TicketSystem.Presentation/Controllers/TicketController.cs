using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Tickets.Cmd;
using TicketSystem.Presentation.Controllers.Base;

namespace TicketSystem.Presentation.Controllers;
public class TicketController : ApiControllers
{



    public TicketController(ISender sender) : base(sender)
    {

    }

    [HttpPost("api/CreateTicket")]
    public async Task<ActionResult> CreateTicket(TicketCreatedCommend request, CancellationToken cancellationToken = default)
    {
        await _sender.Send(request);

        return Ok();
    }
    [HttpPut("api/CreateTicket")]
    public async Task<ActionResult> UpdateTicket(TicketCreatedCommend request, CancellationToken cancellationToken = default)
    {
        await _sender.Send(request);

        return Ok();
    }


}
