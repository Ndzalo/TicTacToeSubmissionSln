
using System;

namespace TicTacToeSubmissionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Store the original console color
            ConsoleColor oldColor = Console.ForegroundColor;

            // Display the welcome message
            Console.SetCursorPosition(10, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Tic Tac Toe");

            // Initialize and run the TicTacToe game
            var ticTacToe = new TicTacToe();
            ticTacToe.Run();

            // Restore the original console color and display the exit message
            Console.ForegroundColor = oldColor;
            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Thank you for playing");
            Console.ReadLine();
        }
    }
}