namespace Emne3.assignments.Assignment329B;

public class VirtualScreen
{
    private VirtualScreenRow[] _rows;

    public VirtualScreen(int width, int height)
    {
        _rows = new VirtualScreenRow[height];
        for (var i = 0; i < _rows.Length; i++)
        {
            _rows[i] = new VirtualScreenRow(width);
        }
    }

    public void Add(Box box)
    {
        _rows[box.Y-1].AddBoxTopRow(box.X, box.Width);
        for (var rowIndex = box.StartY; rowIndex < box.EndY-1; rowIndex++)
        {
            _rows[rowIndex].AddBoxMiddleRow(box.X, box.Width);
        }  
        _rows[box.EndY-1].AddBoxBottomRow(box.X, box.Width);
    }

    public void Show()
    {
        foreach (var row in _rows)
        {
            row.Show();
        }
    }
}