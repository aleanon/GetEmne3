namespace Emne3.assignments;

public class Assignment316A: IAssignement
{
    private const string FilePath = @"E:\GetEmne3\Emne3\assignments\Assignement316A/ordliste.txt";
    private static readonly Random Random = new Random();
    private static readonly List<string> WordList = GetWordList();
    private static readonly int[] CommonWordLengths = [3, 4, 5];
    private const int NumberOfWordPairs = 200;

    public void Run()
    {
        var wordPairsLeft = NumberOfWordPairs;

        while (wordPairsLeft > 0)
        {
            var randomWord = GetRandomWordFromWordList();
            if (!TryGetMatchingWord(randomWord, out var matchingWord)) continue;
            
            Console.WriteLine($"{randomWord}     {matchingWord}");
            wordPairsLeft--;
        }
        

    }

    private static bool TryGetMatchingWord(string randomWord, out string matchingWord)
    {
        foreach (var commonWordLength in CommonWordLengths)
        {
            var lastPartOfFirstWord = randomWord[^commonWordLength..];
            foreach (var word in WordList)
            {
                var firstPartOfLastWord = word[..commonWordLength];
                if (lastPartOfFirstWord != firstPartOfLastWord) continue;
                if (!WordList.Contains(word)) continue;
                matchingWord = word;
                return true;
            }
        }
        matchingWord = "";
        return false;
    }

    private static List<string> GetWordList()
    {
        var fileContent = File.ReadAllText(FilePath);
        var list = new List<string>(fileContent.Split('\t'));
        return list.Where(word => !word.Contains('-') && word.Length is >= 7 and <= 10).ToList();
    }

    private string GetRandomWordFromWordList()
    {
        var randomWordIndex = Random.Next(0, WordList.Count);
        return WordList[randomWordIndex];
    }

}