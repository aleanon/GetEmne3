using Emne3.assignments;

namespace Emne3;

internal static class Program
{
    private static void Main(string[] args)
    {

        IAssignement assignment;
        
        // assignment = new Assignment315F(true);
        assignment = new Assignment316A(); 
        assignment.Run();
    }
}


