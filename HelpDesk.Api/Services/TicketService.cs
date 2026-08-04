using HelpDesk.Api.Models;

namespace HelpDesk.Api.Services;

public class TicketService
{
    private readonly List<Ticket> _tickets =
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

    public IEnumerable<Ticket> GetAll()
    {
        return _tickets;
    }

    public Ticket? GetById(int id)
    {
        return _tickets.FirstOrDefault(ticket => ticket.Id == id);
    }

    public Ticket Create(Ticket ticket)
    {
        var nextId = _tickets.Max(existingTicket => existingTicket.Id) + 1;

        ticket.Id = nextId;
        ticket.Status = "Open";
        ticket.CreatedAtUtc = DateTime.UtcNow;

        _tickets.Add(ticket);

        return ticket;
    }

    public bool Update(int id, Ticket updatedTicket)
    {
        var existingTicket = GetById(id);

        if (existingTicket is null)
        {
            return false;
        }

        existingTicket.Title = updatedTicket.Title;
        existingTicket.Description = updatedTicket.Description;
        existingTicket.Priority = updatedTicket.Priority;

        return true;
    }

    public bool Delete(int id)
    {
        var ticket = GetById(id);

        if (ticket is null)
        {
            return false;
        }

        _tickets.Remove(ticket);

        return true;
    }
}
