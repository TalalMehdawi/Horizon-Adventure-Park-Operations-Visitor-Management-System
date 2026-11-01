using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Infrastructure.Repositories;
using Horizon_Adventure_Park.Domin;
public class ReservationArray
{
    private Reservation[] _reservationsArray = new Reservation[100];

    private int _numberOfReservations=0;

    public string Add(Reservation reservation)
    {
        reservation.Id=$"RES-{100+1+_numberOfReservations}";
        _reservationsArray[_numberOfReservations] = reservation;
        _numberOfReservations++;
        return reservation.Id;
    }

    public Reservation? FindById(string id)
    {
        for (int i = 0; i < _numberOfReservations; i++)
        {
            if (_reservationsArray[i].Id == id)
            {
                return _reservationsArray[i];
            }
        }

        return null;
    }

    public int CountActive(enTimeSlot timeslot,string rideId)
    {
        int numberOfActiveReservations = 0;
        for (int i = 0; i < _numberOfReservations; i++)
        {
            if (_reservationsArray[i].ReservationStatus == enReservationStatus.Active && 
                _reservationsArray[i].TimeSlot==timeslot && _reservationsArray[i].RideId==rideId)
            {
                numberOfActiveReservations++;
            }
        }

        return numberOfActiveReservations;
    }
    public int CountActive(enTimeSlot timeslot)
    {
        int numberOfActiveReservations = 0;
        for (int i = 0; i < _numberOfReservations; i++)
        {
            if (_reservationsArray[i].ReservationStatus == enReservationStatus.Active && 
                _reservationsArray[i].TimeSlot==timeslot )
            {
                numberOfActiveReservations++;
            }
        }

        return numberOfActiveReservations;
    }
    public bool HasDuplicate(string visitorId,string rideId,enTimeSlot timeSlot)
    {
        
        for (int i = 0; i < _numberOfReservations; i++)
        {
            if (_reservationsArray[i].VisitorId == visitorId && _reservationsArray[i].RideId==rideId && 
                _reservationsArray[i].TimeSlot==timeSlot )
            {
                return true;
            }
        }

        return false;
    }
}