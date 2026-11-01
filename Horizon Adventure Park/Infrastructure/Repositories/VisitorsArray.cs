namespace Horizon_Adventure_Park.Infrastructure.Repositories;

using Horizon_Adventure_Park.Domin;

public class VisitorsArray
{
    private Visitor[] visitorsArray = new Visitor[100];

    public  int numberOfVisitors = 0;
    
    public string Add(Visitor visitor)                                                                                                                    
    {                                                                                                                                      
        visitor.Id = $"V-{100 + numberOfVisitors + 1}";                                                                                                             
        visitorsArray[numberOfVisitors] = visitor;                                                                                                                  
       this.numberOfVisitors++;
       return visitor.Id;
    } 

    public Visitor? FindById(string Id)
    {
        for (int i = 0; i < numberOfVisitors; i++)
        {
            if (visitorsArray[i].Id == Id)
            {
                return visitorsArray[i];
            }

        }
        return null;

    }

}