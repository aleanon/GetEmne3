namespace Emne3.assignments.Assignment323A;

public class Match
{
    private int _homeGoals = 0;
    private int _awayGoals = 0;
    private bool _matchIsRunning = true;

    public bool IsRunning() => _matchIsRunning;
    
    public int HomeGoals() => _homeGoals;
    
    public int AwayGoals() => _awayGoals;

    public string Result()
    {
        return _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "B";
    }

    public void PerformCommand(string? command)
    {
        if (command == "X") {_matchIsRunning = false;}
        else if (command == "H") {_homeGoals++;}
        else if (command == "B") {_awayGoals++;}
    }
}