using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Presentation;
using Horizon_Adventure_Park.Domin;
public static class CorePrint
{
    public static void PrintTicket(Ticket ticket)
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"user with ID {ticket.VisitorId} Ticket");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Ticket Id :{ticket.Id}");
        Console.WriteLine($"Price :{ticket.Price}");
        Console.WriteLine($"Category :{ticket.Category}");
        Console.WriteLine($"status :{ticket.Status}");
        Console.WriteLine($"Issude In {ticket.IssuedIn}");
        Console.WriteLine($"expired In {ticket.ExpiresOn}");
        Console.WriteLine("-------------------------------------------");

    }
    
    
}