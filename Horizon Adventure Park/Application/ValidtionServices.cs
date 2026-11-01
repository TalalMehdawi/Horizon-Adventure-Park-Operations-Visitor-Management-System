using Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Application;
using Horizon_Adventure_Park.Domin.Entities;
public static class ValidtionServices
{
  public static bool ValidateRideAccsess(Ticket ticket, Ride ride,Visitor visitor)
  {
    if (!ride.IsAgeValid(visitor.Age) || !ride.IsHeightValid(visitor.Height) ||
        !ride.IsTicketCategoryValid(ticket.Category)||ticket.ExpiresOn<DateTime.Now)
    {
      return false;
    }

    if (!visitor.HasAccompanyingAdult && visitor.Category == VisitorCategory.child && ride.ShlouldHasAccompanyingAdulte)
      return false;
    if (ride.Status != enRideStatus.Open || ticket.Status != enTicketStatus.Active)
      return false;
    
    return true;

  }
  public static bool ValidateRideAccsessWithMassage(Ticket ticket, Ride ride,Visitor visitor)
  {
    if (!ride.IsAgeValid(visitor.Age))
    {
      Console.WriteLine("your Age is not Valid for this ride");
      return false;
    }

    if (!ride.IsHeightValid(visitor.Height))
    {
      Console.WriteLine("your Height is not Valid for this ride");
      return false;

    }

    if (!ride.IsTicketCategoryValid(ticket.Category))
    {
      Console.WriteLine("your Category is not Valid for this ride");
      return false;
    }
      if(ticket.ExpiresOn<DateTime.Now)
    {
      Console.WriteLine("your Ticket is expired");
      return false;
    }

    if (!visitor.HasAccompanyingAdult && visitor.Category == VisitorCategory.child &&
        ride.ShlouldHasAccompanyingAdulte)
    {
      Console.WriteLine("you should have an adult whit you to ride this ride");
      return false;

    }

    if (ride.Status != enRideStatus.Open)
    {
      Console.WriteLine("Ride is not open");
      return false;
    }

    if (ticket.Status != enTicketStatus.Active)
    {
      Console.WriteLine("your ticket is not active ");
      return false;

    }
    
    
    return true;

  }
  
}