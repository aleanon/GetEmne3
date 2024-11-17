namespace PasswordGenerator;

public class Generator
{
    public void GeneratePassword(string[] args)
    {
        PrintHelp();
    }

    private static void PrintHelp()
    {
        Console.WriteLine(
            "PasswordGenerator\n" +
            "Options:\n" +
            "- l = liten bokstav\n" +
            "- L = stor bokstav\n" +
            "- d = siffer\n" +
            "- s = spesialtegn (!\"#¤%&/(){}[]\n" +
            "Eksempel: PasswordGenerator 14 lLssdd\n" +
            "    betyr\n" +
            "        Min. 1 liten bokstav\n" +
            "        Min. 1 stor bokstav\n" +
            "        Min. 2 spesialtegn\n" +
            "        Min. 2 sifre\n" +
            "        Lengde på passordet skal være 14"
        );
    }

    private static bool ArgumentsAreValid(string[] args)
    {
        try
        {
            if (!int.TryParse(args[0], out int passwordLength)) return false;
        }
        catch
        {
            
        }
    }
}