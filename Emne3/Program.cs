using Emne3.assignments;

namespace Emne3;

internal static class Program
{
    private static void Main(string[] args)
    {

        IAssignement assignement;
        
        assignement = new Assignment315F(true);
        
        assignement.Run();
    }
}