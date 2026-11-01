namespace Horizon_Adventure_Park.Presentation;
using Horizon_Adventure_Park.Application;
public class MainMenu
{

    public static void PrintWelcomeScreen()
    {
        
        Console.WriteLine("======================================================");
        Console.WriteLine("Welcome To The Horizon Adventure Park System ");
        Console.WriteLine("======================================================");

    }
    public static void PrintMenu()
    {
        Console.WriteLine("\t[1] Add Visitor");
        Console.WriteLine("\t[2] Issue Ticket");
        Console.WriteLine("\t[3] Edit Ticket Status");
        Console.WriteLine("\t[4] Validate Ride Access");
        Console.WriteLine("\t[5] Creat Reservation");
        Console.WriteLine("\t[6] Cancel Ride Reservation");
        Console.WriteLine("\t[7] View Rides Occupancy");
        Console.WriteLine("\t[8] Add New Ride");
        Console.WriteLine("\t[9] Manage Ride Status");
        Console.WriteLine("\t[10] Assign Staff");
        Console.WriteLine("\t[11] Print Assigned Staff");
        Console.WriteLine("\t[12] Exit");
    }

    public static void PrintMainMenu()
    {
        PrintWelcomeScreen();
        PrintMenu();

    }
}