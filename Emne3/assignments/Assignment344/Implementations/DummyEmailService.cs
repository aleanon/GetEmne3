using Emne3.assignments.Assignment344.Model;

namespace Emne3.assignments.Assignment344.Implementations;

public class DummyEmailService
{
    public void Send(Email email)
    {
        Console.WriteLine(email);
    }
}