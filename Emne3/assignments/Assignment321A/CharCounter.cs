namespace Emne3.assignments.Assignment321A;

public class CharCounter
{
    private const int Range = 250;
    private static readonly int[] Counts = new int[Range];

    public void AddText(string? text)
    {
        foreach (var character in text ?? string.Empty)
        {
            Counts[(int)character]++;
        }
    }

    public void ShowCounts()
    {
        for (var i = 0; i < Range; i++)
        {
            if (Counts[i] <= 0) continue;
            var character = (char)i;
            Console.WriteLine(character + " - " + Counts[i]);
        }
    }
}