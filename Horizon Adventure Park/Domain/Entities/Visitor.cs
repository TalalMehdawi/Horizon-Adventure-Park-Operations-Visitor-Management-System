namespace Horizon_Adventure_Park.Domin;
using Horizon_Adventure_Park.Domin.Enums;
public class Visitor
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Height { get; set; }
    public VisitorCategory Category { get; set; }

    public bool HasAccompanyingAdult { get; set; }

   
    
   public  Visitor(string name, int age, double Height, int category, bool hasAccompanyingAdult)
    {
        this.Name = name;
        this.Age = age;
        this.Height = Height;
        this.Category = (VisitorCategory)category;
        this.HasAccompanyingAdult = hasAccompanyingAdult;
    }

    
}