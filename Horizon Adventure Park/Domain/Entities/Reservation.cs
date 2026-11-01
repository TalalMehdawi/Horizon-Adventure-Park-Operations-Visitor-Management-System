using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Domin;

public class Reservation
{
    public string Id { get; set; }   
    public string VisitorId { get; set; }
    public string RideId { get; set; }
    public enTimeSlot TimeSlot { get; set; }
    public enReservationStatus ReservationStatus { get; set; }

    public Reservation(string visitorId, string rideId, enTimeSlot timeSlot, enReservationStatus reservationStatus)
    {
        this.VisitorId = visitorId;
        this.RideId = rideId;
        this.ReservationStatus = reservationStatus;
        this.TimeSlot = timeSlot;
    }

    
}