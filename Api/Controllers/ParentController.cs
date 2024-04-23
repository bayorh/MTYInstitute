using Application.Parents.Commands.CreateParent;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mty.Application.Parents.Queries.GetByEmail;
using Mty.Presentation.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mty.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParentController : ApiController
{
    public ParentController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("{email}")]
    public async Task<IActionResult> GetParentByEmail(string email, CancellationToken cancellationToken)
    {
        var query = new GetParentByEmailQuery(email);
        var response = await sender.Send(query, cancellationToken);
        return response.IsSuccess? Ok(response.Value) : BadRequest(response.Error);
    }

   
    
    [HttpPost]
    public async Task<IActionResult> RegisterParent(CancellationToken cancellationToken)
    {

       var command = new CreateParentCommand(
            new Guid(), "Bayonle Toheeb", "gbonagun street", "ba@gmail.com", 0708909809, Tittle.Mr);
      var result =  await sender.Send(command, cancellationToken);
        return result.IsSuccess ? Ok(command) : BadRequest(result.Error);
       
    }


}