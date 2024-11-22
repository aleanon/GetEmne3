using Emne3.assignments.Assignment323A;

namespace Emne3.assignments.Assignment323B;

public class TwelveMatches
{
    private readonly Match[] _matches = new Match[12];

    public TwelveMatches(string[] bets)
    {
        for (var i = 0; i < _matches.Length; i++)
        {
            _matches[i] = new Match(bets[i]);
        }
    }

    public Match GetMatch(int matchNumber)
    {
        return _matches[matchNumber - 1];
    }

    public void ShowBetsResult()
    {
        for (var index = 0; index < _matches.Length; index++)
        {
            var match = _matches[index];
            var theMatchNo = index + 1;
            var isBetCorrect = match.IsBetCorrect();
            var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
            Console.WriteLine($"Kamp {theMatchNo}: {match.Result()} - {isBetCorrectText}");
        }
    }

    public int NrOfCorrectBets()
    {
        var correctBets = 0;
        foreach (var match in _matches)
        {
            if (match.IsBetCorrect()) correctBets++;
        }

        return correctBets;
    }
    
    public int NrOfMatches => _matches.Length;
}