namespace Emne3.assignments;

public class SuperUpgrade : ICommand
{
    private char _trigger= 'S';
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.SuperUpgrade();
    }
    
    public char Trigger() => _trigger;
}