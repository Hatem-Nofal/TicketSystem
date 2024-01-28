using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Presentation.Controllers.Base;
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllers : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiControllers(ISender sender)
    {
        _sender = sender;
    }
}
