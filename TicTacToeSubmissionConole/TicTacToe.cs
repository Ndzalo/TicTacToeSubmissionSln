using System;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConsole
{
    public class TicTacToe
    {
        // Renderer to display the board
        private TicTacToeConsoleRenderer _boardRenderer;

        //character array to store the board state
        private char[,] _board = new char[3, 3];

        // Keeps track of the current player
        private PlayerEnum _currentPlayer = PlayerEnum.X;

        // Constructor initializes the board renderer and renders the board
        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            RenderBoard();
        }

        // Main game loop
        public void Run()
        {
            int turns = 0; 

            while (true)
            {
                Console.Clear(); 
                RenderBoard(); // Render the board with coordinates

                // Display the current player
                Console.SetCursorPosition(2, 19);
                Console.Write("Player "+_currentPlayer);

                int row, column;

                // Prompt the current player for their move with error handling for the row
                while (true)
                {
                    Console.SetCursorPosition(2, 20);
                    Console.Write("Please Enter Row (1-3): ");
                    var rowInput = Console.ReadLine();
                    if (int.TryParse(rowInput, out row) && row >= 1 && row <= 3)
                    {
                        row -= 1; // Adjust to 0-based index
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(2, 21);
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                        Console.SetCursorPosition(2, 20); // Reposition cursor for next input
                        Console.Write(new string(' ', rowInput.Length));
                    }
                }

                // Prompt the current player for their move with error handling for the column
                while (true)
                {
                    Console.SetCursorPosition(2, 22);
                    Console.Write("Please Enter Column (1-3): ");
                    var columnInput = Console.ReadLine();
                    if (int.TryParse(columnInput, out column) && column >= 1 && column <= 3)
                    {
                        column -= 1; // Adjust to 0-based index
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(2, 23);
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        Console.SetCursorPosition(2, 22); // Reposition cursor for next input
                        Console.Write(new string(' ', columnInput.Length));
                    }
                }

                // Check if the move is valid
                if (IsValidMove(row, column))
                {
                    // Place the current player's mark on the board
                    _board[row, column] = _currentPlayer == PlayerEnum.X ? 'X' : 'O';
                    _boardRenderer.AddMove(row + 0, column + 0, _currentPlayer, true);
                    turns++;

                    // Check if the current playewon
                    if (CheckWin())
                    {
                        Console.Clear();
                        RenderBoard();
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine($"Player {_currentPlayer} wins!");
                        break;
                    }
                    else if (turns == 9) // Check for a draw
                    {
                        Console.Clear();
                        RenderBoard();
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    // Switch to the other player
                    _currentPlayer = _currentPlayer == PlayerEnum.X ? PlayerEnum.O : PlayerEnum.X;
                }
                else
                {
                    // Notify the player of an invalid move
                    Console.SetCursorPosition(2, 24);
                    Console.WriteLine("Invalid move, try again.");
                    Console.ReadKey();
                }
            }
        }

        // Check if the selected move is valid
        private bool IsValidMove(int row, int column)
        {
            return _board[row, column] == '\0';
        }

        // Check if the current player has won the game
        private bool CheckWin()
        {
            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                if ((_board[i, 0] == _board[i, 1] && _board[i, 1] == _board[i, 2] && _board[i, 0] != '\0') ||
                    (_board[0, i] == _board[1, i] && _board[1, i] == _board[2, i] && _board[0, i] != '\0'))
                {
                    return true;
                }
            }

            return (_board[0, 0] == _board[1, 1] && _board[1, 1] == _board[2, 2] && _board[0, 0] != '\0') ||
                   (_board[0, 2] == _board[1, 1] && _board[1, 1] == _board[2, 0] && _board[0, 2] != '\0');
        }

        // Render the board with coordinates
        private void RenderBoard()
        {
            _boardRenderer.Render();


        }
    }
}