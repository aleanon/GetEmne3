namespace Emne3.assignments.Assignment323C;

public class GameConsole
{
    public void Show(Board board)
    {
        Console.Clear();
        Console.SetCursorPosition(0,0);
        Console.Write(
            "  a b c \n"
            + " \u250c\u2500\u2500\u2500\u2500\u2500\u2510\n"
            + $"1\u2502{(char)board[0]} {(char)board[1]} {(char)board[2]}\u2502\n"
            + $"2\u2502{(char)board[3]} {(char)board[4]} {(char)board[5]}\u2502\n"
            + $"3\u2502{(char)board[6]} {(char)board[7]} {(char)board[8]}\u2502\n"
            + " \u2514\u2500\u2500\u2500\u2500\u2500\u2518"
        );
    }
}