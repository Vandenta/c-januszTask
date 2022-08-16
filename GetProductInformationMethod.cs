using Januszpol.InterfaceForMethods;

namespace Januszpol;

public class GetProductInformationMethod : IGetName, IGetPrice, IGetQuantity
{
    public string GetName()
    {
        Console.Write("Podaj nazwę produktu: ");
        var name = Console.ReadLine();
        if (name == "")
        {
            Console.Clear();
            Console.WriteLine("Nie podano nazwy produktu.\nWciśnij ENTER aby spróbować ponownie.");
            GetName();
        }
        return name;
    }
    
    public double GetPrice()
    {
        Console.Write("Podaj cenę produktu (użyj ',' do rozdzielenia wartosci): ");
        double price = 0;
        try
        {
            price = Double.Parse(Console.ReadLine());
            if (price == 0)
            {
                Console.Clear();
                Console.WriteLine("Nie podano ceny produktu.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                GetPrice();
            }
        }
        catch
        {
            Console.WriteLine("Źle podano cenę.\nWciśnij ENTER aby spróbować ponownie.");
            Console.ReadLine();
            GetPrice();
        }

        return price;
    }
    
    public int GetQuantity()
    {
        Console.Write("Podaj liczbę sztuk produktu: ");
        int quantity = 0;
        try
        {
            quantity = Int32.Parse(Console.ReadLine());
            if (quantity == 0)
            {
                Console.Clear();
                Console.WriteLine("Nie podano liczby sztuk produktu.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                GetQuantity();
            }
        }
        catch
        {
            Console.WriteLine("Źle podano cenę.\nWciśnij ENTER aby spróbować ponownie.");
            Console.ReadLine();
            GetQuantity();
        }

        return quantity;
    }

}