namespace PasswordGenerator;

class Program
{
    private static void Main(string[] args)
    {
        var pwGenerator = new Generator();
        pwGenerator.GeneratePassword([]);
    }
}