namespace Emne3.assignments;

public class SuperUpgrade : ICommand
{
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.SuperUpgrade();
    }
}