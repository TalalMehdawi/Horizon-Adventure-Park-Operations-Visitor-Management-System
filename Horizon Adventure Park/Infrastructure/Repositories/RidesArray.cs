using Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Enums;
using Horizon_Adventure_Park.Domin.Entities;
namespace Horizon_Adventure_Park.Infrastructure.Repositories;

public class RidesArray
{
    private Ride[] _ridesArray = new Ride[50];

    private int numberOfRides = 0;

    public string Add(Ride ride)
    {
        ride.Id = $"R-{100 + numberOfRides + 1}";
        _ridesArray[numberOfRides] = ride;
        numberOfRides++;
        return ride.Id;
    }

    public Ride? FindById(string Id)
    {
        for (int i = 0; i < numberOfRides; i++)
        {
            if (_ridesArray[i].Id == Id)
            {
                return _ridesArray[i];
            }
        }
        return null;
    }

    public void PrintAll()
    {
        Console.WriteLine("-----------------------------------------------------------------------------");
        Console.WriteLine($"{"ID",-8} {"Name",-20} {"Status",-16} {"MinAge",-7} {"MinHeight",-10} {"MinTicket",-10}");
        Console.WriteLine("-----------------------------------------------------------------------------");
        for (int i = 0; i < numberOfRides; i++)
        {
            Ride r = _ridesArray[i];
            Console.WriteLine($"{r.Id,-8} {r.Name,-20} {r.Status,-16} {r.MinAge,-7} {r.MinHeight,-10} {r.MinTicketStatus,-10}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------");
    }

    public void Seed()
    {
        Add(new Ride("Sky Screamer",   20, enRideStatus.Open,             12, 140, VisitorCategory.child, false));
        Add(new Ride("Splash Lagoon",  30, enRideStatus.Open,              6, 110, VisitorCategory.general, false));
        Add(new Ride("Kiddie Carousel",25, enRideStatus.Open,              3,  90, VisitorCategory.senior, true));
        Add(new Ride("Dragon Coaster", 16, enRideStatus.UnderMaintenance, 14, 150, VisitorCategory.general, false));
        Add(new Ride("Giant Wheel",    40, enRideStatus.Closed,            5, 100, VisitorCategory.VIP, true));
    }
}
