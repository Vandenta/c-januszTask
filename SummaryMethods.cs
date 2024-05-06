using Januszpol.InterfaceForMethods;

namespace Januszpol;

public class SummaryMethods : ISelectIdOfSummary
{
    public int SelectIdOfSummary()
    {
        Console.Clear();
        Console.WriteLine("Podsumowanie!!!\nWybierz jeden z zestawów: ");
        Console.WriteLine("[0] Zysk z wódki\n[1] Zysk z piwa\n[2] Historia transakcji\n[3] Wyłącz program");
        var selectedIdString = Console.ReadLine();
        try
        {
            var selectedIdInt = Int32.Parse(selectedIdString);
            return selectedIdInt;
        }
        catch 
        {
            return -1;
        }
    }
}