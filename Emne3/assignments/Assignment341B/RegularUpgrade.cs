namespace Emne3.assignments;

public class RegularUpgrade : ICommand
{
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.Upgrade();
    }
}