using System.Globalization;

namespace Januszpol.Alcohols;

public class Vodka : Alcohol
{
    private List<string> _vodkaName;
    private List<double> _vodkaPrice;
    private List<int> _vodkaQuantity;
    private List<string> _vodkaShowList;
    private List<double> _vodkaProfitList;

    public Vodka()
    {
        _vodkaName = _alcoholName;
        _vodkaPrice = _alcoholPrice;
        _vodkaQuantity = _alcoholQuantity;
        _vodkaProfitList = _alcoholProfitList;
        _vodkaShowList = _alcoholShowList;
    }
    
    public override void AddAlcohol(string name, double price, int quantity)
    {
        _vodkaName.Add(name);
        _vodkaPrice.Add(price);
        _vodkaQuantity.Add(quantity);
        _vodkaProfitList.Add(0.0);
        _vodkaShowList.Add(name + ", cena: " + price + ", ilość: " + quantity);
    }
    
    public override void PrintList()
    {
        for (int i = 0; i < _vodkaShowList.Count; i++)
        {
            Console.WriteLine($"[{i}] " + _vodkaShowList[i]);
        }    
    }
    
    public override bool BuyProduct(int alcoholId, int quantityOfAlcohol)
    {
        var vodkaStock = _vodkaQuantity[alcoholId];
        if (vodkaStock < quantityOfAlcohol)
        {
            Console.WriteLine("Nie wystarczająca ilość w sklepie aby kupić tyle.");
            return false;
        }
        else
        {
            _vodkaQuantity[alcoholId] = vodkaStock - quantityOfAlcohol;
            _vodkaShowList[alcoholId] = _vodkaName[alcoholId] + ", cena: " + _vodkaPrice[alcoholId] + ", ilość: " +
                                        _vodkaQuantity[alcoholId];
            return true;
        }
    }

    public override void CalculateProfit(List<string> alcoholList)
    {
        var vodkaAllProductsProfit = 0.0;
        for (int alcoholId = 0; alcoholId < alcoholList.Count; alcoholId++)
        {
            var productName = alcoholList[alcoholId].Substring(alcoholList[alcoholId].IndexOf("nazwa: ", StringComparison.Ordinal) + "nazwa: ".Length);
            productName = productName.Substring(0, productName.IndexOf(",", StringComparison.Ordinal));
            var producktQuantitystring = alcoholList[alcoholId].Substring(alcoholList[alcoholId].IndexOf("ilość: ", StringComparison.Ordinal) + "ilość: ".Length);
            var producktQuantityInt = Int32.Parse(producktQuantitystring);
            for (int vodkaId = 0; vodkaId < _vodkaName.Count; vodkaId++)
            {
                if (productName == _vodkaName[vodkaId])
                {
                    double vodkaProductProfit = producktQuantityInt * _vodkaPrice[vodkaId];
                    _vodkaProfitList[vodkaId] += vodkaProductProfit;
                    vodkaAllProductsProfit += vodkaProductProfit;
                }
            }
        }
        _vodkaProfitList.Add(vodkaAllProductsProfit);
    }

    public override int NumberOfElementsInList()
    {
        return _vodkaName.Count();
    }
    
    public override void PrintProfitList()
    {
        var profit = 0.0;
        var cultureInfo = CultureInfo.GetCultureInfo("pl-PL");
        string formattedAmount;

        for (int vodkaId = 0; vodkaId < _vodkaName.Count; vodkaId++)
        {
            profit = _vodkaProfitList[vodkaId];
            formattedAmount = String.Format(cultureInfo, "{0:C}", profit);
            Console.WriteLine("Wódka: " + _vodkaName[vodkaId] + ", zysk: " +  formattedAmount);
        }

        profit = _vodkaProfitList.Last();
        formattedAmount = String.Format(cultureInfo, "{0:C}", profit);

        Console.WriteLine("Całkowity zysk z sprzedaży wódki: " + formattedAmount);
    }
    
    public override string NameOfSelectedAlcohol(int selectedId)
    {
        return _vodkaName[selectedId];
    }
}