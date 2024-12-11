namespace Emne3.assignments;

public class IncreasePoints : ICommand
{
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.IncreasePoints();
    }

}