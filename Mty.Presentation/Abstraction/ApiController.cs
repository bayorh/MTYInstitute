
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mty.Presentation.Abstraction;

[ApiController]
public abstract  class ApiController : ControllerBase

{
    protected readonly ISender sender;

    protected ApiController(ISender sender)
    {
        this.sender = sender;
    }
}
