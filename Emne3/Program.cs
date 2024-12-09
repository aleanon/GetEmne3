using Emne3.assignments;
using Emne3.assignments.Assignment321A;
using Emne3.assignments.Assignment321C;
using Emne3.assignments.Assignment323A;
using Emne3.assignments.Assignment323B;
using Emne3.assignments.Assignment323C;
using Emne3.assignments.Assignment329B;
using Emne3.assignments.Assignment329C;

namespace Emne3;

public static class Program
{

    private static void Main(string[] args)
    {

        IAssignement assignment;

        // assignment = new Assignment315F(false);
        // assignment = new Assignment316A();
        // assignment = new Assignment321A();
        // assignment = new Assignment321C();
        // assignment = new Assignment323A();
        // assignment = new Assignment323B();
        // assignment = new Assignment323C();
        assignment = new Assignment329C();
        assignment.Run();
    }

 
}


