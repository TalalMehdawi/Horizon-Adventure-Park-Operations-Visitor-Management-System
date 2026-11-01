namespace Horizon_Adventure_Park.Infrastructure.Repositories;
using Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Enums;
public class EmpAssignArray
{
    
    private EmpAssgin[] _empAssginArray = new EmpAssgin[100];

    public int _numberOfEmpAssgin=0;

    public EmpAssgin this[int index] => _empAssginArray[index];

    public string Add(EmpAssgin empAssgin)
    {
        empAssgin.id=$"A-{100+1+_numberOfEmpAssgin}";
        _empAssginArray[_numberOfEmpAssgin] = empAssgin;
        _numberOfEmpAssgin++;
        return empAssgin.id;
    }

    public EmpAssgin? FindById(string id)
    {
        for (int i = 0; i < _numberOfEmpAssgin; i++)
        {
            if (_empAssginArray[i].id == id)
            {
                return _empAssginArray[i];
            }
        }

        return null;
    }

    public int CountActive(enTimeSlot timeslot,string empId)
    {
        int numberOfActiveReservations = 0;
        for (int i = 0; i < _numberOfEmpAssgin; i++)
        {
            if (_empAssginArray[i].Slot==timeslot && _empAssginArray[i].EmpId==empId)
            {
                numberOfActiveReservations++;
            }
        }

        return numberOfActiveReservations;
    }
    public bool HasDuplicate(string empId,enTimeSlot timeSlot,string rideId)
    {
        for (int i = 0; i < _numberOfEmpAssgin; i++)
        {
            if (_empAssginArray[i].EmpId == empId && _empAssginArray[i].Slot==timeSlot)
            {
                return true;
            }
        }

        for (int i = 0; i < _numberOfEmpAssgin; i++)
        {
            if (rideId == _empAssginArray[i].RideId && _empAssginArray[i].Slot == timeSlot)
            {
                return true;
            }
        }

        return false;
    }
    
    
}