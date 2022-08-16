using Januszpol.Alcohols;
using Januszpol.InterfaceForMethods;

namespace Januszpol;

public class InitProgram : IMatchingTypeIdToAddAction, IMatchingTypeIdToBuyAction,
                            IMatchingProductIdToBuyAction, IMatchingSummaryIdToSummaryAction
{
    private Alcohol _vodka;
    private Alcohol _beer;
    private Transaction _transaction;
    private SelectMethods _selectMethods;
    private SummaryMethods _summaryMethods;
    private GetProductInformationMethod _getMethods;
    public InitProgram()
    {
        _vodka = new Vodka();
        _beer = new Beer();
        _transaction = new Transaction();
        _summaryMethods = new SummaryMethods();
        _selectMethods = new SelectMethods();
        _getMethods = new GetProductInformationMethod();
    }
    
    public void StartProgram()
    {
        Console.WriteLine("Witaj w Januszpol!!!");
        Console.WriteLine("Inicjalizacja wprowadzania produktów.");
        Thread.Sleep(3000);
        MatchingTypeIdToAddType(_selectMethods.TypeIdOfAddedAlcohol());
        Console.WriteLine("Dodawanie produktów zakończone!!!");
        Console.WriteLine("Rozpoczynanie sprzedazy.");
        Thread.Sleep(3000);
        MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
        Console.WriteLine("Rozpoczynam zliczanie zysków");
        Thread.Sleep(3000);
        MatchingSummaryId(_summaryMethods.SelectIdOfSummary());

    }
    
    public void MatchingTypeIdToAddType(int selectedId)
    {
        switch (selectedId)
        {
            case 0:
                Console.Clear();
                _vodka.AddAlcohol(_getMethods.GetName(),_getMethods.GetPrice(),_getMethods.GetQuantity());
                MatchingTypeIdToAddType(_selectMethods.TypeIdOfAddedAlcohol());
                break;
            case 1:
                Console.Clear();
                _beer.AddAlcohol(_getMethods.GetName(),_getMethods.GetPrice(),_getMethods.GetQuantity());
                MatchingTypeIdToAddType(_selectMethods.TypeIdOfAddedAlcohol());
                break;
            case 2:
                Console.Clear();
                break;
            case -1:
                Console.WriteLine("ID zostało źle wpisane.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                MatchingTypeIdToAddType(_selectMethods.TypeIdOfAddedAlcohol());
                break;
            default:
                Console.WriteLine("Wybrane ID nie posiada czynności.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                MatchingTypeIdToAddType(_selectMethods.TypeIdOfAddedAlcohol());
                break;
        }    
    }
    
    public void MatchingTypeIdToBuyType(int selectedId)
    {
        switch (selectedId)
        {
            case 0:
                _vodka.PrintList();
                Console.WriteLine("Wybierz ID produktu.");
                MatchingProductIdToBuyProduct(0, _selectMethods.SelectIdOfBuyedProduct());
                break;
            case 1:
                _beer.PrintList();
                Console.WriteLine("Wybierz ID produktu.");
                MatchingProductIdToBuyProduct(1, _selectMethods.SelectIdOfBuyedProduct());
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Dzień zakończony!!!");
                break;
            case -1:
                Console.WriteLine("ID zostało źle wpisane.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
                break;
            default:
                Console.WriteLine("Wybrane ID nie posiada czynności.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
                break;
        }
    }

    public void MatchingProductIdToBuyProduct(int selectedTypeId, int selectedProductId)
    {
        int buyingQuantity = 0;
        try
        {
            Console.Write("Podaj kupioną liczbę sztuk: ");
            buyingQuantity = Int32.Parse(Console.ReadLine());
        }
        catch 
        {
            Console.WriteLine("Źle podana liczba sztuk!!!.\nWciśnij ENTER aby spróbować ponownie.");
            Console.ReadLine();
            MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
        }
        
        if (selectedProductId == -1)
        {
            Console.WriteLine("ID zostało źle wpisane.\nWciśnij ENTER aby spróbować ponownie.");
            Console.ReadLine();
            MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
        }

        switch (selectedTypeId)
        {
            case 0:
                if (_vodka.NumberOfElementsInList() < selectedProductId)
                {
                    Console.WriteLine("Wybrane ID nie posiada czynności.\nWciśnij ENTER aby spróbować ponownie.");
                    Console.ReadLine();
                    MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
                }
                else
                {
                    _vodka.BuyProduct(selectedProductId, buyingQuantity);
                    _transaction.AddTransaction("wódka", _vodka.NameOfSelectedAlcohol(selectedProductId), buyingQuantity);
                    Console.WriteLine("Produkt sprzedany.\nWciśnij ENTER aby kontynuować ponownie.");
                    Console.ReadLine();
                    MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
                }
                break;
            case 1:
                if (_beer.NumberOfElementsInList() < selectedProductId)
                {
                    Console.WriteLine("Wybrane ID nie posiada czynności.\nWciśnij ENTER aby spróbować ponownie.");
                    Console.ReadLine();
                    MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
                }
                else
                {
                    _beer.BuyProduct(selectedProductId, buyingQuantity);
                    _transaction.AddTransaction("piwo", _beer.NameOfSelectedAlcohol(selectedProductId), buyingQuantity);
                    Console.WriteLine("Produkt sprzedany.\nWciśnij ENTER aby kontynuować ponownie.");
                    Console.ReadLine();
                    MatchingTypeIdToBuyType(_selectMethods.TypeIdOfBuyedAlcohol());
                }
                break;
        }
    }

    public void MatchingSummaryId(int selectedId)
    {
        switch (selectedId)
        {
            case 0:
                _vodka.CalculateProfit(_transaction.ReturnVodkaList());
                _vodka.PrintProfitList();
                Console.WriteLine("\nWciśnij ENTER by kontynuować.");
                Console.ReadLine();
                MatchingSummaryId(_summaryMethods.SelectIdOfSummary());
                break;
            case 1:
                _beer.CalculateProfit(_transaction.ReturnBeerList());
                _beer.PrintProfitList();
                Console.WriteLine("\nWciśnij ENTER by kontynuować.");
                Console.ReadLine();
                MatchingSummaryId(_summaryMethods.SelectIdOfSummary());
                break;
            case 2:
                _transaction.PrintTransactionList();
                Console.WriteLine("\nWciśnij ENTER by kontynuować.");
                Console.ReadLine();
                MatchingSummaryId(_summaryMethods.SelectIdOfSummary());
                break;
            case 3:
                Console.WriteLine("Zamykam się.");
                break;
            case -1:
                Console.WriteLine("ID zostało źle wpisane.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                MatchingSummaryId(_summaryMethods.SelectIdOfSummary());
                break;
            default:
                Console.WriteLine("Wybrane ID nie posiada czynności.\nWciśnij ENTER aby spróbować ponownie.");
                Console.ReadLine();
                MatchingSummaryId(_summaryMethods.SelectIdOfSummary());
                break;
        }
    }
}