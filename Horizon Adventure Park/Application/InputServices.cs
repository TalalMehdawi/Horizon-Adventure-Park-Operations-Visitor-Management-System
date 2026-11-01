using Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Enums;
using Horizon_Adventure_Park.Application;
using Horizon_Adventure_Park.Domin.Entities;
namespace Horizon_Adventure_Park.Application;

public static class InputServices
{

    public static int ReadNumberInRange(int from, int to)
    {
        int number;
        Console.Write($"Enter a number between {from} and {to} :");
        while (!int.TryParse(Console.ReadLine(), out number) || number > to || number < from)
        {
            Console.WriteLine("enter a Valid Number....!");
        }

        return number;
    }
    public static double ReadDoubleInRange(int from, int to)
    {
        double number;
        Console.Write($"Enter a number between {from} and {to} :");
        while (!double.TryParse(Console.ReadLine(), out number) || number > to || number < from)
        {
            Console.WriteLine("enter a Valid Number....!");
        }

        return number;
    }
    public static Visitor ReadVisitorInfo()
    {
        string name;
        int age;
        double highet;
        int category;
        bool HasAccompanyingAdult;
        
        Console.Write("Please enter visitor name :");
        name = Console.ReadLine();
        
        Console.Write("Please enter visitor age :");
        age = ReadNumberInRange(0,120);
        
        Console.Write("Please enter visitor hight  :");
        highet = ReadDoubleInRange(0, 210);
        
        Console.WriteLine("Please enter visitor category :");
        Console.Write("[1]child,[2]general,[3]senior,[4]VIP :");
        category = ReadNumberInRange(1, 4);
        
        if(category==1)
        {Console.Write("do the visitor Has Accompanying Adult:(y/n)");
            HasAccompanyingAdult = Console.ReadLine()?.Trim().ToLower() == "y";
        }
        else
        {
            HasAccompanyingAdult = false;
        }
        Visitor visitor = new Visitor(name,age,highet,category,HasAccompanyingAdult);
        return visitor;
    }

    public static Ride ReadRideInfo()
    {
        Console.WriteLine("please enter Ride Name :");
        string name = Console.ReadLine();

        Console.WriteLine("please enter Ride Capacity :");
        int Capacity = ReadNumberInRange(1, 100);
        
        Console.WriteLine("Please enter the new status of the ride :");
        Console.WriteLine("[1]Open , [2]Closed , [3]UnderMaintenance");
        enRideStatus status = (enRideStatus)InputServices.ReadNumberInRange(1, 3);

        Console.WriteLine("please enter Ride Min Age :");
        int Age = ReadNumberInRange(1, 100);

        Console.WriteLine("please enter Ride Min Height :");
        double Height = ReadDoubleInRange(1, 220);
        
        Console.WriteLine("Please enter Min visitor category :");
        Console.Write("[1]child,[2]general,[3]senior,[4]VIP :");
        VisitorCategory category = (VisitorCategory)ReadNumberInRange(1, 4);

        Console.Write("do the Ride needs Accompanying Adult for childrens:(y/n)");
        bool HasAccompanyingAdult = Console.ReadLine()?.Trim().ToLower() == "y";

        return  new Ride(name, Capacity, status, Age, Height, category, HasAccompanyingAdult);
        
         
    }
}