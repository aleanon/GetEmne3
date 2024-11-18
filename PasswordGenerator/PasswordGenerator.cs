

namespace PasswordGenerator;

public abstract class PasswordGenerator
{
    private static readonly Random Random = new();

    private static readonly char[] SpecialChars =
    [
        '!', '#', '$', '(', ')', '*', '+', ',', '-', '.', '/', 
        ':', '=', '?', '@', '[', ']', '^', '_', '{', '}', '~'
    ];
    
    public static void GeneratePassword(string[] args)
    {
        if (!TryParseArguments(args, out var passwordLength, out var passwordOptions))
        {
            ShowHelpText();
            return;
        }

        var password = GenerateRandomPassword(passwordLength, passwordOptions);
        if (!passwordOptions.AllRequirementsMet())
        {
            PasswordCanNotMeetRequirements();
            return;
        }
        Console.WriteLine(password);
    }
    
    private static bool TryParseArguments(string[] args, out int passwordLength, out PasswordOptions options)
    {
        passwordLength = 0;
        options = new PasswordOptions();
        try
        {
            passwordLength = int.Parse(args[0]);
        }
        catch
        {   
            return false;
        }

        if (args.Length < 2) return true;

        if (!TryParsePasswordOptions(args[1], out var passwordOptions)) return false;

        options = passwordOptions;
        return true;
    }
    
    private static bool TryParsePasswordOptions(string input, out PasswordOptions options)
    {
        options = new PasswordOptions();
        foreach (var character in input)
        {
            switch (character)
            {
                case 'l':
                    options.LowerCaseLetters += 1;
                    break;
                case 'L':
                    options.UpperCaseLetters += 1;
                    break;
                case 's':
                    options.SpecialCharacters += 1;
                    break;
                case 'd':
                    options.Digits += 1;
                    break;
                default:
                    return false;
            }
        }

        return true;
    }
    
    private static void ShowHelpText()
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

    private static string GenerateRandomPassword(int length, PasswordOptions options)
    {
        var emptyCharList = Enumerable.Repeat(' ', length).ToList();
        var randomizedList = CreateRandomCharList(emptyCharList, ref options);
        return new string(randomizedList.ToArray());
    }

    private static List<char> CreateRandomCharList(List<char> charList, ref PasswordOptions options)
    {
        switch (charList.Count)
        {
            case 0:
                return [];
            case 1:
                return [GetRandomChar(ref options)];
        }

        var randomIndex = Random.Next(0, charList.Count);
        var leftHandList = CreateRandomCharList(charList[0..randomIndex], ref options);
        var rightHandList = CreateRandomCharList(charList[randomIndex..], ref options);
        leftHandList.AddRange(rightHandList);
        return leftHandList;
    }

    private static char GetRandomChar(ref PasswordOptions options)
    {
        if (options.LowerCaseLetters > 0)
        {
            options.LowerCaseLetters--;
            return GetRandomLowerCaseLetter();
        } else if (options.UpperCaseLetters > 0)
        {
            options.UpperCaseLetters--;
            return GetRandomUpperCaseLetter();
        } else if (options.Digits > 0)
        {
            options.Digits--;
            return GetRandomDigit();
        } else if (options.SpecialCharacters > 0)
        {
            options.SpecialCharacters--;
            return GetRandomSpecialChar();
        }
        else
        {
            return GetAnyRandomChar();
        }
    }

    private static char GetRandomLowerCaseLetter()
    {
        return (char)Random.Next(97, 123);
    }

    private static char GetRandomUpperCaseLetter()
    {
        return (char)Random.Next(65, 91);
    }

    private static char GetRandomDigit()
    {
        return (char)Random.Next(48, 58);
    }

    private static char GetRandomSpecialChar()
    {
        return SpecialChars[Random.Next(0, SpecialChars.Length-1)];
    }

    private static char GetAnyRandomChar()
    {
        return (char)Random.Next(33, 126);
    }

    private static void PasswordCanNotMeetRequirements()
    {
        Console.WriteLine("Password is not long enough to meet requirements");
    }

    private class PasswordOptions
    {
        public int LowerCaseLetters;
        public int UpperCaseLetters;
        public int Digits;
        public int SpecialCharacters;

        public bool AllRequirementsMet()
        {
            return this.LowerCaseLetters == 0 && this.UpperCaseLetters == 0 && this.Digits == 0 && this.SpecialCharacters == 0;
        }
    }
    
    
}