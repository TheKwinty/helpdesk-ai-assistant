using HelpDesk.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private static readonly List<Ticket> Tickets =
    [
        new()
        {
            Id = 1,
            Title = "Cannot sign in",
            Description = "The user cannot sign in to the HelpDesk portal.",
            Status = "Open",
            Priority = "High",
            CreatedAtUtc = new DateTime(2026, 7, 28, 8, 30, 0, DateTimeKind.Utc)
        },
        new()
        {
            Id = 2,
            Title = "Printer is offline",
            Description = "The office printer is not available on the network.",
            Status = "In Progress",
            Priority = "Medium",
            CreatedAtUtc = new DateTime(2026, 7, 28, 9, 15, 0, DateTimeKind.Utc)
        }
    ];

    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetAll()
    {
        return Ok(Tickets);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Ticket> GetById(int id)
    {
        var ticket = Tickets.FirstOrDefault(ticket => ticket.Id == id);

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpPost]
    public ActionResult<Ticket> Create([FromBody] Ticket ticket)
    {
        var nextId = Tickets.Max(existingTicket => existingTicket.Id) + 1;

        ticket.Id = nextId;
        ticket.Status = "Open";
        ticket.CreatedAtUtc = DateTime.UtcNow;

        Tickets.Add(ticket);

        return CreatedAtAction(
            nameof(GetById),
            new { id = ticket.Id },
            ticket);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Ticket updatedTicket)
    {
        var existingTicket =
            Tickets.FirstOrDefault(ticket => ticket.Id == id);

        if (existingTicket is null)
        {
            return NotFound();
        }

        existingTicket.Title = updatedTicket.Title;
        existingTicket.Description = updatedTicket.Description;
        existingTicket.Priority = updatedTicket.Priority;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var ticket = Tickets.FirstOrDefault(ticket => ticket.Id == id);

        if (ticket is null)
        {
            return NotFound();
        }

        Tickets.Remove(ticket);

        return NoContent();
    }
}
