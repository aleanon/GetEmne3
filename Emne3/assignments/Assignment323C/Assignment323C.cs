namespace Emne3.assignments.Assignment323C;

public class Assignment323C : IAssignement
{
    public void Run()
    {
        var gameConsole = new GameConsole();
        var board = new Board();
        while (true)
        {
            gameConsole.Show(board);
            Console.WriteLine("Skriv inn hvor du vil sette kryss (f.eks. \"a2\"): ");
            var position = Console.ReadLine();
            if (!board.Mark(position, Player.One)) continue;
            if (board.IsSolved())
            {
                if (WillPlayAgain("You"))
                {
                    board = new Board();
                    continue;
                }

                break;
            }
            Thread.Sleep(1000);
            board.MarkRandom(Player.Two);
            if (board.IsSolved())
            {
                if (WillPlayAgain("Player two"))
                {
                    board = new Board();
                    continue;
                }

                break;
            }
        } 
    }

    private bool WillPlayAgain(string winner)
    {
        Console.WriteLine($"{winner} won! Do you want to play again? (y/n): ");
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "y") return true;
            if (input == "n") return false;
        }
    }
}