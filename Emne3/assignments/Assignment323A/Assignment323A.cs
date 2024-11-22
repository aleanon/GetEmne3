namespace Emne3.assignments.Assignment323A;

public class Assignment323A : IAssignement
{
    public void Run()
    {
        Console.Write("Gyldig tips: \n" +
                      " - H, U, B\n" + 
                      " - halvgardering: HU, HB, UB\n" + 
                      " - helgardering: HUB\n" + 
                      "Hva har du tippet for denne kampen? ");
        var bet = Console.ReadLine();
        var match = new Match(); 
        while (match.IsRunning())
        {
            Console.Write("Kommandoer: \n" + 
                          " - H = scoring hjemmelag\n" + 
                          " - B = scoring bortelag\n" + 
                          " - X = kampen er ferdig\n" + 
                          "Angi kommando: ");
            var command = Console.ReadLine();
            match.PerformCommand(command); 
            Console.WriteLine($"Stillingen er {match.HomeGoals()}-{match.AwayGoals()}.");
        }

        var result = match.Result(); 
        var isBetCorrect = bet.Contains(result);
        var isBetCorrectText = isBetCorrect ? "riktig" : "feil";
        Console.WriteLine($"Du tippet {isBetCorrectText}");
    }
}