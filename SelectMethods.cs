using Januszpol.InterfaceForMethods;

namespace Januszpol;

public class SelectMethods : ISelectIdOfAlcoholToAdd, ISelectIdOfAlcoholToBuy, ISelectIdOfProductToBuy
                            
{
    public int TypeIdOfAddedAlcohol()
    {   
        Console.Clear();
        Console.WriteLine("Aby wybrać element wpisz jego ID i wciśnije Enter.");
        Console.WriteLine("Wybierz rodzaj dodawanego produktu:");
        Console.WriteLine("[0] Wódka\n[1] Piwo\n[2] Zakończ dodawanie produktów");
        Console.Write("Wybrane ID: ");
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

    public int TypeIdOfBuyedAlcohol()
    {
        Console.Clear();
        Console.WriteLine("Aby wybrać element wpisz jego ID i wciśnije Enter.");
        Console.WriteLine("Wybierz rodzaj kupowanego produktu:");
        Console.WriteLine("[0] Wódka\n[1] Piwo\n[2] Zakończ dzień");
        Console.Write("Wybrane ID: ");
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

    public int SelectIdOfBuyedProduct()
    {
        Console.Write("ID produktu: ");
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