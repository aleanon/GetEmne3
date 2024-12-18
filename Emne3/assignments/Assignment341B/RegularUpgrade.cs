namespace Emne3.assignments;

public class RegularUpgrade : ICommand
{
    private char _trigger = 'K';
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.Upgrade();
    }
    
    public char Trigger() => _trigger;
}