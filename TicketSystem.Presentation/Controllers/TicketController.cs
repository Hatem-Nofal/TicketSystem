using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Tickets.Cmd;
using TicketSystem.Presentation.BackgroundJobs;
using TicketSystem.Presentation.Controllers.Base;

namespace TicketSystem.Presentation.Controllers;
public class TicketController : ApiControllers
{
    private readonly IprocessOutboxMessagesJob _iprocessOutboxMessagesJob;



    public TicketController(ISender sender, IprocessOutboxMessagesJob iprocessOutboxMessagesJob) : base(sender)
    {
        _iprocessOutboxMessagesJob = iprocessOutboxMessagesJob;

    }

    [HttpPost("api/CreateTicket")]
    public async Task<ActionResult> CreateTicket(TicketCreatedCommend request, CancellationToken cancellationToken = default)
    {
        await _sender.Send(request);

        return Ok();
    }

    [HttpPost("api/fire")]
    public async Task<ActionResult> fire(Guid id, CancellationToken cancellationToken = default)
    {
        await _iprocessOutboxMessagesJob.Execute(cancellationToken);
        return Ok();
    }
}
