using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Prohelika.API.Controllers;
[ApiController]
[Route("[controller]")]
public abstract class Controller(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;
}