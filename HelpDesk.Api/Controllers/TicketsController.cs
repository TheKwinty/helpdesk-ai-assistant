using HelpDesk.Api.Models;
using HelpDesk.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly TicketService _ticketService;

    public TicketsController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetAll()
    {
        return Ok(_ticketService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Ticket> GetById(int id)
    {
        var ticket = _ticketService.GetById(id);

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpPost]
    public ActionResult<Ticket> Create([FromBody] Ticket ticket)
    {
        var createdTicket = _ticketService.Create(ticket);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdTicket.Id },
            createdTicket);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Ticket updatedTicket)
    {
        if (!_ticketService.Update(id, updatedTicket))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_ticketService.Delete(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}
