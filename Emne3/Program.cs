using Emne3.assignments;
using Emne3.assignments.Assignment321A;
using Emne3.assignments.Assignment321C;

namespace Emne3;

internal static class Program
{
    private static void Main(string[] args)
    {

        IAssignement assignment;
        
        // assignment = new Assignment315F(false);
        // assignment = new Assignment316A();
        // assignment = new Assignment321A();
        assignment = new Assignment321C();
        assignment.Run();
    }
}


