using System.Diagnostics;

namespace Emne3.assignments;

public class Exit : ICommand
{
    public void Run(ClickerGame clickerGame)
    {
        clickerGame.Exit();
    }
}