using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Domin.Entities;


public class Ride
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public enRideStatus Status { get; set; }
    public int MinAge { get; set; }
    public double MinHeight { get; set; }
    public VisitorCategory MinTicketStatus { get; set; }
    public bool ShlouldHasAccompanyingAdulte { get; set; }
    
    public Ride(string Name, int Capacity, enRideStatus Status, int MinAge
        , double MinHeight, VisitorCategory MinTicketStatus, bool shlouldHasAccompanyingAdulte)
    {
        this.Name = Name;
        this.Capacity = Capacity;
        this.Status = Status;
        this.MinAge = MinAge;
        this.MinHeight = MinHeight;
        this.MinTicketStatus = MinTicketStatus;
        this.ShlouldHasAccompanyingAdulte = shlouldHasAccompanyingAdulte;
    }

    public bool IsAgeValid(int age)
    {
        return this.MinAge <= age;
    }
    
    public bool IsHeightValid(double height)
    {
        return this.MinHeight <= height;
    }
    
    public bool IsTicketCategoryValid(VisitorCategory category)
    {
        return MinTicketStatus <= category;

    }

    public bool IsHasAccompanyingAdulteMandetory()
    {
        return ShlouldHasAccompanyingAdulte;
    }


    





    

}