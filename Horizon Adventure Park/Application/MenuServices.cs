using Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Entities;

namespace Horizon_Adventure_Park.Application;
using Horizon_Adventure_Park.Application;
using Horizon_Adventure_Park.Presentation;
using Horizon_Adventure_Park.Domin.Enums;
using Horizon_Adventure_Park.Infrastructure.Repositories;

public class MenuServices
{
    private EmpArray _employeeRepo = new EmpArray();
    private int userChoice;
    private VisitorsArray VisitorsRepo = new VisitorsArray();
    private TicketsArray TicketsRepo = new TicketsArray();
    private RidesArray RidesRepo = new RidesArray();
    private ReservationArray ReservationRepo = new ReservationArray();
    private EmpAssignArray _empAssginRepo = new EmpAssignArray();
    public MenuServices()
    {
        RidesRepo.Seed();
        _employeeRepo.Seed();
    }

    private void StopScreen()
    {
        Console.Write("Press any key to continue........ ");
        Console.ReadKey();
        Console.Clear();
    }
    public void PerformMainMenu()
    {
        do
        {
            
            MainMenu.PrintMainMenu();
            this.userChoice = InputServices.ReadNumberInRange(1,12);
            Console.Clear();
            ExcuteUserChoice();   
        }
        while (this.userChoice != 12) ;
    }

    private void ExcuteUserChoice()
    {
        enMainMenu choice = (enMainMenu)this.userChoice;
        
        switch (choice)
        {
            case enMainMenu.AddVisitor:
                AddVisitor();
                StopScreen();
                break;
            case enMainMenu.IssueTicket:
                IssueTicket();
                StopScreen();
                break;
            case enMainMenu.EditTicketStatus:
                EditTicketStatus();
                StopScreen();
                break;
            case enMainMenu.ValidateRideAccess:
                ValidateRideAccess();
                StopScreen();
                break;
            case enMainMenu.CreatReservation:
                CreatReservation();
                StopScreen();
                break;
            case enMainMenu.CancelRideReservtion:
                CancelRideReservtion();
                StopScreen();
                break;
            case enMainMenu.ViewRidesOccupancy:
                ViewRidesOccupancy();
                StopScreen();
                break;
            case enMainMenu.AddNewRide:
                AddNewRide();
                StopScreen();
                break;
            case enMainMenu.ManageRideStatus:
                ManageRideStatus();
                StopScreen();
                break;
            case enMainMenu.AssignStaff:
                AssignStaff();
                StopScreen();
                break;
            case enMainMenu.PrintAssinedStaff:
                PrintAssinedStaff();
                StopScreen();
                break;
            case enMainMenu.Exit:

                break;
            
            default:
                Console.WriteLine("the number is not valid !!!!");
                break;
        }
        
    }

    private void PrintAssinedStaff()
    {
        for (int i = 0; i < _empAssginRepo._numberOfEmpAssgin; i++)
        {
            EmpAssgin assign = _empAssginRepo[i];
            Ride ride = RidesRepo.FindById(assign.RideId);
            Employee employee = _employeeRepo.FindById(assign.EmpId);

            Console.WriteLine($"Employee {employee.Name} ({employee.Id}) is assigned to Ride {ride.Name} ({ride.Id}) in the {assign.Slot} slot");
        }
    }
    private void AddVisitor()
    {
       // Console.WriteLine("Add Visitor Screen will be here...!");
        string id=VisitorsRepo.Add(InputServices.ReadVisitorInfo());
        Console.WriteLine($"Visitor added with ID {id}!"); 
    }
    private void AssignStaff()
    {
       // Console.WriteLine("Assign Staff Screen will be here...!");
       
       
       RidesRepo.PrintAll();

       Console.Write("Please chooce a Ride By typing it's ID :");
       string RID = Console.ReadLine();
       Ride ride = RidesRepo.FindById(RID);

       if (ride == null)
       {
           Console.WriteLine("ride Is not found......!");
           return;
       }
       
       Console.Clear();
       
       Console.WriteLine("enter the time slot :");
       Console.WriteLine("[1]Morning [2]Afternoon [3]Evening");
       enTimeSlot timeSlot = (enTimeSlot)InputServices.ReadNumberInRange(1, 3);
       
       _employeeRepo.PrintAll();
       
       Console.Write("Please chooce a employee By typing his ID :");
       string empId = Console.ReadLine();

       Employee employee = _employeeRepo.FindById(empId);
       
       if (employee == null)
       {
           Console.WriteLine("employee Is not found......!");
           return;
       }

       if (_empAssginRepo.HasDuplicate(empId, timeSlot, ride.Id))
       {
           Console.WriteLine("these operation is not valid.....!");
           return;
       }

       _empAssginRepo.Add(new EmpAssgin(employee.Id, ride.Id, timeSlot));

       Console.WriteLine("Operation has been done.......!");


    }
    private void AddNewRide()
    {
      //  Console.WriteLine("Add New Ride screen will be here....!");

      RidesRepo.Add(InputServices.ReadRideInfo());
      Console.WriteLine("the ride has been add......!");

    }
    private void ViewRidesOccupancy()
    {
        
       // Console.WriteLine("View Rides Occupancy screen will be here....!");
       
       Console.Write("Please chooce a Ride By typing it's ID :");
       string RID = Console.ReadLine();
       Ride ride = RidesRepo.FindById(RID);

       if (ride == null)
       {
           Console.WriteLine("ride is not found.....!");
           return;
       }
        
       Console.WriteLine("enter the time slot :");
       Console.WriteLine("[1]Morning [2]Afternoon [3]Evening");
       enTimeSlot timeSlot = (enTimeSlot)InputServices.ReadNumberInRange(1, 3);

       int number = ReservationRepo.CountActive(timeSlot, ride.Id);

       Console.WriteLine($"the number of ride occupancy in {timeSlot} is {number}");

    }
    private void CancelRideReservtion()
    {
        //Console.WriteLine("Cancel Ride Reservtion screen will be here....!");
        Console.WriteLine("Please enter the Reservation Id :");
        string resId = Console.ReadLine();
        Reservation reservation = ReservationRepo.FindById(resId);

        if (reservation == null)
        {
            Console.WriteLine("the Reservation is not found");
            return;
        }

        reservation.ReservationStatus = enReservationStatus.Cancel;

        Console.WriteLine("Opretion has been done......!");
    }
    
    private void IssueTicket()
    {
       // Console.WriteLine("Issue Ticket Screen will be here...!");
       
       Console.Write("enter Visitor Id : ");
       string id = Console.ReadLine();

       Visitor visitor=  VisitorsRepo.FindById(id);

       if (visitor == null)
       {
           Console.WriteLine("Visitor is not found....! ");
           return;
       }

       Ticket ticket = new Ticket(visitor.Id, Ticket.GetTicketPrice(visitor.Category), visitor.Category, enTicketStatus.Active);
       TicketsRepo.Add(ticket);
       CorePrint.PrintTicket(ticket);
       
    }

    private void EditTicketStatus()
    {
      //  Console.WriteLine("Edit Ticket Status Screen will be here...!");
      Console.Write("enter Ticket ID :");
      string id = Console.ReadLine();
      Console.WriteLine();
      
      Console.WriteLine("Chooce the new status ");
      Console.WriteLine("[1]Active,[2]Expired,[3]Cancelled ");
      enTicketStatus status = (enTicketStatus)InputServices.ReadNumberInRange(1, 3);
      
      Console.WriteLine();
      
      if (TicketsRepo.EditStatusById(status, id))
      {
          Ticket ticket = TicketsRepo.FindById(id);
          Console.WriteLine("the operation has been done....!");
          CorePrint.PrintTicket(ticket);
      }
      else
      {
          Console.WriteLine("ticket is not found.....!");
          
      }
      
    }
    private void ValidateRideAccess()
    {
        //Console.WriteLine("Validate Ride Access Screen will be here...!");

       
       
        RidesRepo.PrintAll();

        Console.Write("Please chooce a Ride By typing it's ID :");
        string RID = Console.ReadLine();
        Ride ride = RidesRepo.FindById(RID);

        if (ride == null)
        {
            Console.WriteLine("Ride with this id dose not exist");
            return;
        }
        Console.Clear();
        Console.Write("Please enter Ticket ID :");
        string TID = Console.ReadLine();

        Ticket ticket = TicketsRepo.FindById(TID);
        if (ticket == null)
        {
            Console.WriteLine("ticket with this id dose not exist");
            return; 
        }

        Visitor visitor = VisitorsRepo.FindById(ticket.VisitorId);

        if (ValidtionServices.ValidateRideAccsessWithMassage(ticket,ride,visitor))
        {
            Console.WriteLine("You have an accsess");
        }
        else
        {
            Console.WriteLine("you don't have accsess");
        }

    }
    
    private void CreatReservation()
    {
      //  Console.WriteLine("VCreat Reservation Screen will be here...!");
      
      RidesRepo.PrintAll();
      Console.WriteLine("choce one of the rides by typing it's id :");
      string rideId = Console.ReadLine();

      Ride ride = RidesRepo.FindById(rideId);

      if (ride == null)
      {
          Console.WriteLine("the ride is not found....!");
          return;
      }
      
      Console.WriteLine("please enter the ticket Id:");
      string ticketId=Console.ReadLine();

      Ticket ticket = TicketsRepo.FindById(ticketId);
      
      if (ticket== null)
      {
          Console.WriteLine("the ticket is not found....!");
          return;
      }

      Visitor visitor = VisitorsRepo.FindById(ticket.VisitorId);


      if (!ValidtionServices.ValidateRideAccsess(ticket, ride, visitor))
      {
          Console.WriteLine("you don't have Accsess to this ride");
          return;
      }

      Console.WriteLine("enter the time slot :");
      Console.WriteLine("[1]Morning [2]Afternoon [3]Evening");
      enTimeSlot timeSlot = (enTimeSlot)InputServices.ReadNumberInRange(1, 3);

      if (ReservationRepo.CountActive(timeSlot,ride.Id) >= ride.Capacity)
      {
          Console.WriteLine("the Capactiy of the ride is full....!");
          return;
      }

      if (ReservationRepo.HasDuplicate(visitor.Id, ride.Id,timeSlot))
      {
          Console.WriteLine("the resevation is already exist....!");
          return;
      }
    string id=  ReservationRepo.Add(new Reservation(visitor.Id, ride.Id, timeSlot, enReservationStatus.Active));
      Console.WriteLine($"Reservation is add with id :{id}");
    }


    private void ManageRideStatus()
    {
       // Console.WriteLine("Manage Ride Status Screen will be here...!");

       Console.WriteLine("Enter the ride id :");
       string rideId = Console.ReadLine();

       Ride ride = RidesRepo.FindById(rideId);

       if (ride == null)
       {
           Console.WriteLine("ride is not found .....!");
           return;
       }
       
       Console.WriteLine("Please enter the new status of the ride :");
       Console.WriteLine("[1]Open , [2]Closed , [3]UnderMaintenance");
       enRideStatus status = (enRideStatus)InputServices.ReadNumberInRange(1, 3);

       ride.Status = status;

       Console.WriteLine("Ride status has been changed....!");

    }
    

  
    
    

}