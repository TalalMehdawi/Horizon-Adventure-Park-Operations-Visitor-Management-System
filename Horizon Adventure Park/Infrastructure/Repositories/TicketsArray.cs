using Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Infrastructure.Repositories;

public class TicketsArray
{
    private Ticket[] _ticketsArray = new Ticket[100];

    private int numberOfTickets = 0;

    public string Add(Ticket ticket)
    {
        ticket.Id = $"T-{100 + numberOfTickets + 1}";
        _ticketsArray[numberOfTickets] = ticket;
        numberOfTickets++;
        return ticket.Id;
    }
    
    public Ticket? FindById(string Id)
    {
        for (int i = 0; i < numberOfTickets; i++)
        {
            if (_ticketsArray[i].Id == Id)
            {
                return _ticketsArray[i];
            }

        }
        return null;

    }

    public bool EditStatusById(enTicketStatus status, string id)
    {
        Ticket ticket = FindById(id);

        if (ticket == null)
        {
            return false;
        }
        ticket.Status = status;
        return true;
    }

    
}