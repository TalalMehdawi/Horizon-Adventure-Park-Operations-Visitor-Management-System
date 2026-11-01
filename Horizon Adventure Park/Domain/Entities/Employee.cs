namespace Horizon_Adventure_Park.Domin;

public class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }

    public Employee(string name)
    {
        this.Name = name;
    }
}