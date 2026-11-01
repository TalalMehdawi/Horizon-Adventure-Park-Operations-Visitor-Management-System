namespace Horizon_Adventure_Park;

using Horizon_Adventure_Park.Application;
class Program
{
    static void Main(string[] args)
    {
        MenuServices menuServices = new MenuServices();
        
        menuServices.PerformMainMenu();
    }
}