using Emne3.assignments.Assignment323A;

namespace Emne3.assignments.Assignment323B;

public class Assignment323B : IAssignement
{
    public void Run()
    {
        Console.Write("Gyldig tips: \n" +
                      " - H, U, B\n" + 
                      " - halvgardering: HU, HB, UB\n" + 
                      " - helgardering: HUB\n" + 
                      "Skriv inn dine 12 tippinger med komma mellom hver (en tipping for hver kamp): ? ");
        var betsText = Console.ReadLine();
        var bets = betsText.Split(',');

        var matches = new TwelveMatches(bets);

        while (true)
        {
            Console.Write("Skriv kampnr. 1-12 for scoring eller X for alle kampene er ferdige\r\nAngi kommando: ");
            var command = Console.ReadLine();
            if (command == "X") break;
            var matchNo = Convert.ToInt32(command);
            Console.Write("Kommandoer: \n" + 
                          " - H = scoring hjemmelag\n" + 
                          " - B = scoring bortelag\n" + 
                          " - X = kampen er ferdig\n" + 
                          "Angi kommando: ");
            var team = Console.ReadLine();
            var selectedMatch = matches.GetMatch(matchNo);
            selectedMatch.GoalScored(team);
            matches.ShowBetsResult();
            var correctCount = matches.NrOfCorrectBets(); 

            Console.WriteLine($"Du har {correctCount} rette.");
        }
    }
}