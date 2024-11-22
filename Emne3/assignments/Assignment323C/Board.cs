namespace Emne3.assignments.Assignment323C;



public class Board
{
    private static readonly Random Random = new();
    private readonly Square[] _squares = new Square[9];

    public Board()
    {
        for (var i = 0; i < _squares.Length; i++)
        {
            _squares[i] = new Square();
        }
    }
    
    public Square this[int index]
    {
        get => _squares[index];
        set => _squares[index] = value;
    }

    public bool Mark(string? position, Player player)
    {
        if (position == null || position.Length < 2) return false;
        
        int letterAsNumber;
        
        if (position[0] == 'a') letterAsNumber = 0;
        else if (position[0] == 'b') letterAsNumber = 1;
        else if (position[0] == 'c') letterAsNumber = 2;
        else return false;

        if (position[1] is not ('1' or '2' or '3')) return false;

        var index = letterAsNumber + ((position[1] - '1') * 3);
        return _squares[index].Take(player);
    }

    public void MarkRandom(Player player)
    {
        var emptySquareIndexes = new List<int>();
        for (var i = 0; i < _squares.Length; i++)
        {
            if (_squares[i].IsEmpty()) emptySquareIndexes.Add(i);
        }
        var randomIndex = Random.Next(0, emptySquareIndexes.Count);
        var randomEmptySquareIndex = emptySquareIndexes[randomIndex];
        _squares[randomEmptySquareIndex].Take(player);
    }

    public bool IsSolved()
    {
        return HasSolvedRow() || HasSolvedColumn() || HasSolvedDiagonal();
    }

    private bool HasSolvedRow()
    {
        for (var rowStartIndex = 0; rowStartIndex < _squares.Length; rowStartIndex += 3)
        {
            var cellOne = _squares[rowStartIndex];
            var cellTwo = _squares[rowStartIndex + 1];
            var cellThree = _squares[rowStartIndex + 2];
            if (!cellOne.IsEmpty() && cellOne == cellTwo && cellOne == cellThree) return true;
        }
        return false;
    }

    private bool HasSolvedColumn()
    {
        for (var columnStartIndex = 0; columnStartIndex < 3; columnStartIndex++)
        {
            var cellOne = _squares[columnStartIndex];
            var cellTwo = _squares[columnStartIndex + 3];
            var cellThree = _squares[columnStartIndex+ 6];
            if (!cellOne.IsEmpty() && cellOne == cellTwo && cellOne == cellThree) return true; 
        }
        return false; 
    }

    private bool HasSolvedDiagonal()
    {
        var upperLeft = _squares[0];
        var upperRight = _squares[2];
        var middle = _squares[4];
        var lowerLeft = _squares[6];
        var lowerRight = _squares[8];

        return (!upperLeft.IsEmpty() && upperLeft == middle && upperLeft == lowerRight)
            || (!upperRight.IsEmpty() && upperRight == middle && upperRight == lowerLeft);
    }
}