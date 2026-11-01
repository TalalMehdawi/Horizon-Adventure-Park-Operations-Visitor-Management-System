using Horizon_Adventure_Park.Domin.Enums;

namespace Horizon_Adventure_Park.Domin;

public class Ticket
{
    public string Id { get; set; }
    public string VisitorId { get; set; }
    public double Price { get; set; }
    public DateTime IssuedIn { get; set; } = DateTime.Now;
    public DateTime ExpiresOn { get; set; } = DateTime.Now.AddDays(1);
    public VisitorCategory Category { get; set; }
    public enTicketStatus Status { get; set; }

    public Ticket(string VisitorId,double Price,VisitorCategory Category,enTicketStatus Status)
    {
        this.VisitorId = VisitorId;
        this.Price = Price;
        this.Category = Category;
        this.Status = Status;
    }

    public static double GetTicketPrice(VisitorCategory category)
    {
        switch (category)
        {
            case VisitorCategory.child:
                return 15.5;
            case VisitorCategory.general:
                return 20;
            case VisitorCategory.senior:
                return 30;
            case VisitorCategory.VIP:
                return 40;
            default:
                return 0;

        }

    }
}