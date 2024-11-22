namespace Emne3.assignments.Assignment323C;

public class Square
{
    private Player _takenBy = Player.None;

    public bool IsEmpty() => _takenBy == Player.None;
    
    public bool IsTakenByPlayer1() => _takenBy == Player.One;

    public bool Take(Player player)
    {
        if (_takenBy != Player.None) return false;
        _takenBy = player;
        return true;
    }

    private char AsChar() => (char)_takenBy;
    
    public static explicit operator char(Square square) => square.AsChar();
    
    public static bool operator ==(Square squareLeft, Square squareRight) => squareLeft._takenBy == squareRight._takenBy;
    
    public static bool operator !=(Square squareLeft, Square squareRight) => squareLeft._takenBy != squareRight._takenBy;
}