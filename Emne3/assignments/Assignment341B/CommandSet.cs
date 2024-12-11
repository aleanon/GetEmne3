namespace Emne3.assignments;

public class CommandSet
{
    private ICommand[] commands = new ICommand[]
    {
        new IncreasePoints(),
        new RegularUpgrade(),
        new SuperUpgrade(),
        new Exit(),
    };

    public void RunCommand(char command, ClickerGame clickerGame)
    {
        switch (command)
        {
            case ' ': commands[0].Run(clickerGame); break; 
            case 'K': commands[1].Run(clickerGame); break;
            case 'S': commands[2].Run(clickerGame); break;
            case 'X': commands[3].Run(clickerGame); break;
        }
    }
    
    
}