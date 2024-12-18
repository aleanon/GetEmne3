namespace Emne3.assignments;

public interface ICommand
{
    public void Run(ClickerGame clickerGame);

    public char Trigger();
}