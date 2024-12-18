namespace Emne3.assignments;

public class CommandSet
{
    private readonly ICommand[] _commands = new ICommand[]
    {
        new IncreasePoints(),
        new RegularUpgrade(),
        new SuperUpgrade(),
        new Exit(),
    };

    public void RunCommand(char command, ClickerGame clickerGame)
    {
        foreach (var iCommand in _commands)
        {
            if (iCommand.Trigger() == command) iCommand.Run(clickerGame);
        }
    }
    
    
}