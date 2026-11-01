using Horizon_Adventure_Park.Domin;

namespace Horizon_Adventure_Park.Infrastructure.Repositories;

public class EmpArray
{
    private Employee[] _EmpArray = new Employee[50];

    private int numberOfEmployee = 0;

    public string Add(Employee employee)
    {
        employee.Id = $"E-{100 + numberOfEmployee + 1}";
        _EmpArray[numberOfEmployee] = employee;
        numberOfEmployee++;
        return employee.Id;
    }

    public Employee? FindById(string Id)
    {
        for (int i = 0; i < numberOfEmployee; i++)
        {
            if (_EmpArray[i].Id == Id)
            {
                return _EmpArray[i];
            }
        }
        return null;
    }

    public void PrintAll()
    {
        Console.WriteLine("-----------------------------------------------------------------------------");
        Console.WriteLine($"{"ID",-8} {"Name",-20} ");
        Console.WriteLine("-----------------------------------------------------------------------------");
        for (int i = 0; i < numberOfEmployee; i++)
        {
            Employee r = _EmpArray[i];
            Console.WriteLine($"{r.Id,-8} {r.Name,-20} ");
        }
        Console.WriteLine("-----------------------------------------------------------------------------");
    }

    public void Seed()
    {
        Add(new Employee("Omar Haddad"));
        Add(new Employee("Lina Farah"));
        Add(new Employee("Karim Nasser"));
        Add(new Employee("Sara Malhas"));
    }
}