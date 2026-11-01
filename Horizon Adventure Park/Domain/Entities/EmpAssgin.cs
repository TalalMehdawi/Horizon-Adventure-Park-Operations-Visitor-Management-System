using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Domin;

public class EmpAssgin
{
    public string id { get; set; }
    public string EmpId { get; set; }
    public string RideId { get; set; }
    public enTimeSlot Slot{ get; set; }

    public EmpAssgin(string EmpId, string RideId, enTimeSlot Slot)
    {
        this.EmpId = EmpId;
        this.RideId = RideId;
        this.Slot = Slot;
    }
}