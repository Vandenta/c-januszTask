using System.Globalization;

namespace Januszpol.Alcohols;

public class Beer : Alcohol
{
    private List<string> _beerName;
    private List<double> _beerPrice;
    private List<int> _beerQuantity;
    private List<string> _beerShowList;
    private List<double> _beerProfitList;

    public Beer()
    {
        _beerName = _alcoholName;
        _beerPrice = _alcoholPrice;
        _beerQuantity = _alcoholQuantity;
        _beerProfitList = _alcoholProfitList;
        _beerShowList = _alcoholShowList;
    }
    
    public override void AddAlcohol(string name, double price, int quantity)
    {
        _beerName.Add(name);
        _beerPrice.Add(price);
        _beerQuantity.Add(quantity);
        _beerProfitList.Add(0.0);
        _beerShowList.Add(name + ", cena: " + price + ", ilość: " + quantity);
    }
    
    public override void PrintList()
    {
        for (int i = 0; i < _beerShowList.Count; i++)
        {
            Console.WriteLine($"[{i}] " + _beerShowList[i]);
        }    
    }
    
    public override bool BuyProduct(int alcoholId, int quantityOfAlcohol)
    {
        var beerStock = _beerQuantity[alcoholId];
        if (beerStock < quantityOfAlcohol)
        {
            Console.WriteLine("Nie wystarczająca ilość w sklepie, aby kupić tyle.");
            return false;
        }
        else
        {
            _beerQuantity[alcoholId] = beerStock - quantityOfAlcohol;
            _beerShowList[alcoholId] = _beerName[alcoholId] + ", cena: " + _beerPrice[alcoholId] + ", ilość: " +
                                        _beerQuantity[alcoholId];
            return true;
        }
    }

    public override void CalculateProfit(List<string> alcoholList)
    {
        var beerAllProductsProfit = 0.0;
        for (int alcoholId = 0; alcoholId < alcoholList.Count; alcoholId++)
        {
            var productName = alcoholList[alcoholId].Substring(alcoholList[alcoholId].IndexOf("nazwa: ", StringComparison.Ordinal) + "nazwa: ".Length);
            productName = productName.Substring(0, productName.IndexOf(",", StringComparison.Ordinal));
            var producktQuantitystring = alcoholList[alcoholId].Substring(alcoholList[alcoholId].IndexOf("ilość: ", StringComparison.Ordinal) + "ilość: ".Length);
            var producktQuantityInt = Int32.Parse(producktQuantitystring);
            for (int beerId = 0; beerId < _beerName.Count; beerId++)
            {
                if (productName == _beerName[beerId])
                {
                    double beerProductProfit = producktQuantityInt * _beerPrice[beerId];
                    _beerProfitList[beerId] += beerProductProfit;
                    beerAllProductsProfit += beerProductProfit;
                }
            }
        }
        _beerProfitList.Add(beerAllProductsProfit);
    }

    public override int NumberOfElementsInList()
    {
        return _beerName.Count;
    }
    
    public override void PrintProfitList()
    {
        var profit = 0.0;
        var cultureInfo = CultureInfo.GetCultureInfo("pl-PL");
        string formattedAmount;

        for (int beerId = 0; beerId < _beerName.Count; beerId++)
        {
            profit = _beerProfitList[beerId];
            formattedAmount = String.Format(cultureInfo, "{0:C}", profit);
            Console.WriteLine("Piwo: " + _beerName[beerId] + ", zysk: " +  formattedAmount);
        }
        profit = _beerProfitList.Last();
        formattedAmount = String.Format(cultureInfo, "{0:C}", profit);

        Console.WriteLine("Całkowity zysk z sprzedaży piw: " + formattedAmount);
    }
    
    public override string NameOfSelectedAlcohol(int selectedId)
    {
        return _beerName[selectedId];
    }
}