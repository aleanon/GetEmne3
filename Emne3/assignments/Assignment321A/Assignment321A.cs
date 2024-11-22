namespace Emne3.assignments.Assignment321A;

public class Assignment321A : IAssignement
{
    public void Run()
    {
        var counter = new CharCounter();
        var text = "something";
        while (!string.IsNullOrWhiteSpace(text))
        {
            text = Console.ReadLine();
            counter.AddText(text);
            counter.ShowCounts();
        }
    }
}

