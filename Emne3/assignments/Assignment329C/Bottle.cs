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

    public void Fill(int amount)
    {
        if (Content + amount > _capacity)
        {
            Content = _capacity;
        }
        else
        {
            Content += amount;
        }
    }
    
    public void FillToTop(Bottle fromBottle)
    {
        var maxFill = _capacity - Content;
        if (fromBottle.Content < maxFill)
        {
            Content = fromBottle.Content;
            fromBottle.Content = 0;
        }
        else
        {
            fromBottle.Content -= maxFill;
            Content += maxFill;
        }
    }
    
}

// public class Bottle
// {
//     public int Capacity { get;  }
//     public int Content { get; private set; }
//
//     public Bottle(int capacity)
//     {
//         Capacity = capacity;
//     }
//
//     public void FillToTopFromTap()
//     {
//         Content = Capacity;
//     }
//
//     public void Fill(int volume)
//     {
//         Content = Math.Min(Content + volume, Capacity);
//     }
//
//     public int Empty()
//     {
//         var content = Content;
//         Content = 0;
//         return content;
//     }
//
//     public void FillToTop(Bottle bottle)
//     {
//         var maxFillVolume = Capacity - Content;
//         var realFillVolume = Math.Min(maxFillVolume, bottle.Content);
//         Content += realFillVolume;
//         bottle.Content -= realFillVolume;
//     }
// }