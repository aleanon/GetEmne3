namespace Emne3.assignments.Assignment329B;

public class Assignment329B : IAssignement
{
    private static int _width = 40;
    private static int _height = 20;
    
    public void Run()
    {
        while (true)
        {
            var boxes = CreateBoxes();
            Show(boxes);
            Console.WriteLine("(press enter for new. ctrl+c=exit)");
            Console.ReadLine();
        }
    }
    
    private static Box[] CreateBoxes()
    {
        var random = new Random();
        var boxes = new Box[3];
        for (var i = 0; i < boxes.Length; i++)
        {
            boxes[i] = new Box(random, _width, _height);
        }
        return boxes;
    }

    private static void Show(Box[] boxes)
    {
        var screen = new VirtualScreen(_width,_height);
        foreach (var box in boxes)
        {
            screen.Add(box);
        }
        screen.Show();
    } 
}