using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prohelika.Application.Commands;
using Prohelika.Application.Dtos;
using Prohelika.Application.Queries;
using Prohelika.Domain.Entities;

namespace Prohelika.API.Controllers;

public class PersonController(IMediator mediator) : Controller(mediator)
{
    [HttpPost]
    public async Task<ActionResult<Person>> Post([FromBody] CreatePersonDto dto)
    {
        var result = await mediator.Send(new AddPerson(dto));
        
        return CreatedAtAction(nameof(Get), new {personId = result.Id}, result);
        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> Get()
    {
        var result = await mediator.Send(new GetAllPerson());
        
        return Ok(result);
    }

    [HttpGet("{personId}")]
    public async Task<ActionResult<Person>> Get(int personId)
    {
        var result = await mediator.Send(new GetPersonById(personId));
        
        return Ok(result);
    }

    [HttpPut("{personId}")]
    public async Task<ActionResult<Person>> Put(int personId, [FromBody] UpdatePersonDto dto)
    {
        var result = await mediator.Send(new UpdatePerson(personId, dto));
        
        return Ok(result);
    }
    
    [HttpDelete("{personId}")]
    public async Task<ActionResult> Delete(int personId)
    {
        await mediator.Send(new DeletePerson(personId));
        
        return NoContent();
    }
}