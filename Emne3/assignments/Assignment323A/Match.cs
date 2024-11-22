namespace Emne3.assignments.Assignment323A;

public class Match(string? bet)
{
    private int _homeGoals = 0;
    private int _awayGoals = 0;
    private bool _matchIsRunning = true;
    private string _bet = bet ?? "";

    public bool IsRunning() => _matchIsRunning;
    
    public int HomeGoals() => _homeGoals;
    
    public int AwayGoals() => _awayGoals;

    public string Result()
    {
        return _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "B";
    }

    public void Stop()
    {
        _matchIsRunning = false;
    }

    public void GoalScored(string? team)
    {
        if (team == "H") {_homeGoals++;}
        else if (team == "B") {_awayGoals++;}
    }

    public bool IsBetCorrect()
    {
        var result = _homeGoals == _awayGoals ? "U" : _homeGoals > _awayGoals ? "H" : "B";
        return _bet.Contains(result);
    }
}