namespace Emne3.assignments.Assignment321C;

public class CoinCount(int value, int count)
{
    private int value = value;
    private int count = count;

    public int TotalValue()
    {
        return value * count;
    }
}