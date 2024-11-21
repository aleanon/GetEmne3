namespace Emne3.Result;

public class Test
{
    public Result CheckText(string text)
    {
        if (text.Length < 10)
        {
            return new Ok<string>(text);
        }

        return new Err<string>("Text is too long");
    }
}
//     public void DoSomething(string text)
//     {
//         var result = CheckText(text);
//         var word = switch (result)
//         {
//             case Ok<string>:
//                 result
//             {
//                 Console.WriteLine("text");
//                 return;
//             },
//         }
//     }
// }