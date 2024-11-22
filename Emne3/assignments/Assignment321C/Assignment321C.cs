namespace Emne3.assignments.Assignment321C;

public class Assignment321C : IAssignement
{
    public void Run()
    {
        CoinCount[] coinCounts = [
            new CoinCount(1, 7),
            new CoinCount(5, 3),
            new CoinCount(10, 2),
            new CoinCount(10, 11),
        ];

        var totalValueAllCoins = 0;
        foreach (var coinCount in coinCounts)
        {
            totalValueAllCoins += coinCount.TotalValue();
        }
        Console.WriteLine(totalValueAllCoins);
    }
}