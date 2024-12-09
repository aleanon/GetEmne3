namespace Emne3.assignments.Assignment329C;

public class Bottle(int capacity)
{
    private int _capacity = capacity;
    public int Content { get; private set; } = 0;


    public int Empty()
    {
        var content = Content;
        Content = 0;
        return content;
    }

    public void FillToTopFromTap() => Content = _capacity;
    
    public void Fill(int amount) => Content += amount;
    
    public void FillToTop(Bottle fromBottle)
    {
        var toFill = _capacity - Content;
        if (fromBottle.Content < toFill)
        {
            Content = fromBottle.Content;
            fromBottle.Content = 0;
        }
        else
        {
            fromBottle.Content -= toFill;
            Content = toFill;
        }
    }
}