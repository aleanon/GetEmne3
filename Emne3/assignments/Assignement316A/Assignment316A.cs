namespace Emne3.assignments;

public class Assignment316A: IAssignement
{
    private const string FilePath = @"E:\GetEmne3\Emne3\assignments\Assignement316A/ordliste.txt";

    public void Run()
    {
        var fileContent = File.ReadAllText(FilePath);
        var wordList = WordList(fileContent);
        
    }

    private static Array WordList(string text)
    {
        var list = new List<string>(text.Split('\t'));
        return list.Where(word => !word.Contains('-') && word.Length is >= 7 and <= 10).ToArray();
    }
}