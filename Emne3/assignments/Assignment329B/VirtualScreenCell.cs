namespace Emne3.assignments.Assignment329B;

public class VirtualScreenCell
{
    private bool Up { get; set; } = false;
    private bool Down { get; set; } = false;
    private bool Left { get; set; } = false;
    private bool Right { get; set; } = false;

    public char GetCharacter()
    {
        return (Up, Down, Left, Right) switch
        {
            (true, true, true, true) => '\u253c', // 
            (true, true, true, false) => '\u2524',
            (true, true, false, true) => '\u251c',
            (true, true, false, false) => '\u2502',
            (true, false, true, true) => '\u2534',
            (true, false, false, true) => '\u2514',
            (true, false, true, false) => '\u2518',
            (false, true, true, true) => '\u252c',
            (false, true, false, true) => '\u250c',
            (false, true, true, false) => '\u2510',
            (false, false, true, true) => '\u2500',
            (false, false, false, false) => ' ',
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public void AddHorizontal() => (Right, Left) = (true, true);
    public void AddVertical() => (Up, Down) = (true, true);
    public void AddLowerLeftCorner() => (Up, Right) = (true, true);
    public void AddLowerRightCorner() => (Up, Left) = (true, true);
    public void AddUpperLeftCorner() => (Down, Right) = (true, true);
    public void AddUpperRightCorner() => (Down, Left) = (true, true);


}