namespace Emne3.assignments.Assignment329B;

public class VirtualScreenRow
{
    private VirtualScreenCell[] _cells;

    public VirtualScreenRow(int screenWidth)
    {
        _cells = new VirtualScreenCell[screenWidth];
        for (var i = 0; i < _cells.Length; i++)
        {
            _cells[i] = new VirtualScreenCell();
        } 
    }

    public void AddBoxTopRow(int boxX, int boxWidth)
    {
        var firstIndex = boxX - 1;
        var endIndex = firstIndex + boxWidth - 1;
        if (endIndex >= _cells.Length) throw new IndexOutOfRangeException("Box X and width exceeds window capacity");
        
        _cells[firstIndex].AddUpperLeftCorner();
        
        for (var i = firstIndex + 1; i < endIndex; i++)
        {
            _cells[i].AddHorizontal();
        }
        _cells[endIndex].AddUpperRightCorner(); 
    }

    public void AddBoxBottomRow(int boxX, int boxWidth)
    {
        var firstIndex = boxX - 1;
        var endIndex = firstIndex + boxWidth - 1;
        if (endIndex >= _cells.Length) throw new IndexOutOfRangeException("Box X and width exceeds window capacity");
        
        _cells[firstIndex].AddLowerLeftCorner();
        
        for (var i = firstIndex + 1; i < endIndex; i++)
        {
            _cells[i].AddHorizontal();
        }
        _cells[endIndex].AddLowerRightCorner(); 
    }

    public void AddBoxMiddleRow(int boxX, int boxWidth)
    {
        var firstIndex = boxX - 1;
        _cells[firstIndex].AddVertical();
        var endIndex = firstIndex + boxWidth - 1;
        _cells[endIndex].AddVertical();
    }

    public void Show()
    {
        var view = "";
        foreach (var cell in _cells)
        {
            view += cell.GetCharacter();
        }
        Console.WriteLine(view);
    }
}