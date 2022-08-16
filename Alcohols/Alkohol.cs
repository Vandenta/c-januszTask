using Januszpol.Interfaces;

namespace Januszpol.Alcohols;

public abstract class Alcohol : IAddAlcoholToList, IPrintAlcoholStock, IBuyAlcohol, 
                                IProfitCalculation, IPrintAlcoholProfitList, 
                                IReturnNumberOfElementsInList, IReturnAlcoholName
{
    protected  List<string> _alcoholName;
    protected  List<double> _alcoholPrice;
    protected  List<int> _alcoholQuantity;
    protected  List<string> _alcoholShowList;
    protected  List<double> _alcoholProfitList;

    protected Alcohol()
    {
        _alcoholName = new List<string>();
        _alcoholPrice = new List<double>();
        _alcoholQuantity = new List<int>();
        _alcoholShowList = new List<string>();
        _alcoholProfitList = new List<double>();
    }

    public virtual void AddAlcohol(string name, double price, int quantity)
    {
        Console.WriteLine("This method add product to List.");
    }

    public virtual void PrintList()
    {
        Console.WriteLine("This method print List of products.");
    }

    public virtual bool BuyProduct(int alcoholId, int quantityOfAlcohol)
    {
        Console.WriteLine("This method changing quantity of products and return true if this is possible.");
        return true;
    }

    public virtual void CalculateProfit(List<string> alcoholList)
    {
        Console.WriteLine("This method calculate profit for alcohol type and products.");
    }

    public virtual void PrintProfitList()
    {
        Console.WriteLine("This method print List with profits.");
    }

    public virtual int NumberOfElementsInList()
    {
        Console.WriteLine("This method return number of elements in List.");
        return 0;
    }

    public virtual string NameOfSelectedAlcohol(int selectedId)
    {
        Console.WriteLine("This method return name of selected alcohol.");
        return "****";
    }
}