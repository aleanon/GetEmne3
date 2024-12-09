namespace Emne3.assignments.Assignment329C;

public class Assignment329C : IAssignement
{
    public void Run()
    {
        var simulation = new Simulation(1, 5, 7);
        var operationSet = simulation.Run();
        Console.WriteLine(operationSet.GetDescription());
    }
}