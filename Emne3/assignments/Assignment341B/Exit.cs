using System.Diagnostics;

namespace Emne3.assignments;

public class Exit : ICommand
{

    private char _trigger = 'X';

    public void Run(ClickerGame clickerGame)
    {
        clickerGame.Exit();
    }

    public char Trigger() => _trigger;
}