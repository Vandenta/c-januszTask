namespace Januszpol;

public class Transaction
{
    private List<string> _transaction;
    public Transaction()
    {
        _transaction = new List<string>();
    }

    public void AddTransaction(string typeAlkohol ,string name, int quantity)
    {
        _transaction.Add($"Typ alkoholu: {typeAlkohol}, nazwa: {name}, ilość: {quantity}");
    }

    public void PrintTransactionList()
    {
        for (int i = 0; i < _transaction.Count; i++)
        {
            Console.WriteLine($"[{i}] " + _transaction[i]);
        }
    }

    public List<string> ReturnBeerList()
    {
        List<string> beerList = new List<string>();

        for (int i = 0; i < _transaction.Count; i++)
        {
            if (_transaction[i].Contains("Typ alkoholu: piwo"))
            {
                beerList.Add(_transaction[i]);
            }
        }
        return beerList;
    }
    
    public List<string> ReturnVodkaList()
    {
        List<string> vodkaList = new List<string>();

        for (int i = 0; i < _transaction.Count; i++)
        {
            if (_transaction[i].Contains("Typ alkoholu: wódka"))
            {
                vodkaList.Add(_transaction[i]);
            }
        }
        return vodkaList;
    }
}