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
}
