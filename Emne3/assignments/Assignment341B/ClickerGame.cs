namespace Emne3.assignments;

public class ClickerGame
{
    private int points = 0;
    private int pointsPerClick = 1;
    private int pointsPerClickIncrease = 1;

    public void Run()
    {
        var commands = new CommandSet();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Kommandoer:\r\n - SPACE = klikk (og få poeng)\r\n"
                              + " - K = kjøp oppgradering \r\n       øker poeng per klikk \r\n       " 
                              + "koster 10 poeng\r\n - S = kjøp superoppgradering \r\n       "
                              + "øker \"poeng per klikk\" for den vanlige oppgraderingen.\r\n       "
                              + "koster 100 poeng\r\n - X = avslutt applikasjonen");
            Console.WriteLine($"Du har {points} poeng.");
            Console.WriteLine("Trykk tast for ønsket kommando.");
            var command = Console.ReadKey().KeyChar;
            commands.RunCommand(command, this);
        }
    }
    
    public void IncreasePoints()
    {
        points += pointsPerClick;
    }

    public void Upgrade()
    {
        if (points < 10) return;
        points -= 10;
        pointsPerClick += pointsPerClickIncrease;
    }

    public void SuperUpgrade()
    {
        if (points < 100) return;
        points -= 100;
        pointsPerClickIncrease++;
    }

    public void Exit()
    {
        Environment.Exit(0);
    }
}