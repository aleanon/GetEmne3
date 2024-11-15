namespace Emne3.assignments;


// To move the a number on the board, input the number you want to move,
// followed by the direction. eks: 1 left, 7 up, 3 right ...
public class Assignment315F
{
   public static void Run(bool randomizeBoard)
   {
      var board = new Board(randomizeBoard);

      while (true)
      {
         board.Draw();
         var command = Console.ReadLine().ToLower();
         if (command == "quit") break;
         board.ParseCommand(command);
      }
   }   
   
   private class Board
   {
      private int[] _numbers = [0, 1, 3, 4, 2, 5, 7, 8, 6];
      private bool _solved = false;

      public Board(bool randomBoard)
      {
         if (randomBoard)
         {
            RandomizeBoard();
         }
      }

      public void Draw()
      {
         Console.Clear();
         Console.SetCursorPosition(0,0);
         Console
            .Write(
               SolvedMessage()
               + "--------------------------------\n"
               + "|         |         |         |\n"
               + $"|    {PosValue(0)}    |    {PosValue(1)}    |    {PosValue(2)}    |\n" 
               + "|         |         |         |\n" 
               + "-------------------------------\n"
               + "|         |         |         |\n" 
               + $"|    {PosValue(3)}    |    {PosValue(4)}    |    {PosValue(5)}    |\n" 
               + "|         |         |         |\n" 
               + "-------------------------------\n"
               + "|         |         |         |\n" 
               + $"|    {PosValue(6)}    |    {PosValue(7)}    |    {PosValue(8)}    |\n" 
               + "|         |         |         |\n" 
               + "-------------------------------\n"
            );
      }

      private string SolvedMessage()
      {
         return _solved ? "        Du klarte det!!        \n" : "";
      }

      private bool IsSolved()
      {
         for (var i = 0; i < _numbers.Length - 1; i++)
         {
            if (_numbers[i] != i + 1) return false;
         }
         return true;
      }

      private string PosValue(int index)
      {
         return _numbers[index] == 0 ? " " : Convert.ToString(_numbers[index]);
      }

      private int IndexOfNumber(int number)
      {
         for (var i = 0; i < _numbers.Length; i++)
         {
            if (_numbers[i] == number) return i;
         }
         return -1;
      }

      private void Move(int number, string direction)
      {
         var indexOfNumber = IndexOfNumber(number);
         if (indexOfNumber == -1) return;
         var indexOfEmptyCell = IndexOfNumber(0);
         
         switch (direction)
         {
            case "left":
               Left(indexOfNumber, indexOfEmptyCell);
               break;
            case "right":
               Right(indexOfNumber, indexOfEmptyCell);
               break;
            case "up":
               Up(indexOfNumber, indexOfEmptyCell);
               break;
            case "down":
               Down(indexOfNumber, indexOfEmptyCell);
               break;
         };
         _solved = IsSolved();
      }

      private void Left(int indexOfNumber, int indexOfEmptyCell)
      {
         if ((indexOfNumber % 3 == 0) || (indexOfNumber - 1 != indexOfEmptyCell)) return;
         _numbers[indexOfEmptyCell] = _numbers[indexOfNumber];
         _numbers[indexOfNumber] = 0;
      }
      
      private void Right(int indexOfNumber, int indexOfEmptyCell)
      {
         if ((indexOfNumber % 3 == 2) || (indexOfNumber + 1 != indexOfEmptyCell)) return;
         _numbers[indexOfEmptyCell] = _numbers[indexOfNumber];
         _numbers[indexOfNumber] = 0;
      }
      
      private void Up(int indexOfNumber, int indexOfEmptyCell)
      {
         if ((indexOfNumber <= 2) || (indexOfNumber - 3 != indexOfEmptyCell)) return;
         _numbers[indexOfEmptyCell] = _numbers[indexOfNumber];
         _numbers[indexOfNumber] = 0;
      }
      
      private void Down(int indexOfNumber, int indexOfEmptyCell)
      {
         if ((indexOfNumber >= 6) || (indexOfNumber + 3 != indexOfEmptyCell)) return;
         _numbers[indexOfEmptyCell] = _numbers[indexOfNumber];
         _numbers[indexOfNumber] = 0;
      }

      public void ParseCommand(string command)
      {
         var commandParts = command.Split(' ');
         if (commandParts.Length < 2) return;
         if (!int.TryParse(commandParts[0], out var number)) return;

         Move(number, commandParts[1]);
      }

      private void RandomizeBoard()
      {
         var randomNumbers = RandomNonCollidingNumbers(0, 8);
         for (var i = 0; i < _numbers.Length; i++)
         {
            _numbers[i] = Convert.ToInt32(randomNumbers[i]);
         }
      }

      private static List<int> RandomNonCollidingNumbers(int min, int max)
      {
         if (min > max) return [];
         
         var randomNumber = new Random().Next(min, max);
   
         var result = new List<int> { randomNumber };
         result.AddRange(RandomNonCollidingNumbers(min, randomNumber - 1));
         result.AddRange(RandomNonCollidingNumbers(randomNumber + 1, max));
    
         return result;
      }
   }
}

