namespace Emne3.assignments;

public class IncreasePoints : ICommand
{
    private char _trigger = ' ';
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.IncreasePoints();
    }

    public char Trigger() => _trigger;
}