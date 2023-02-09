using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the game board as a 2D array of characters
            char[,] board = new char[3, 3] {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };

            // Define the current player
            char currentPlayer = 'X';

            // Game loop
            while (true)
            {
                // Display the board
                DisplayBoard(board);

                // Get the next move from the current player
                Console.WriteLine($"{currentPlayer}'s turn. Enter row and column:");
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                // Place the current player's marker on the board
                board[row, col] = currentPlayer;

                // Check if the game is over
                if (IsWin(board, currentPlayer) || IsDraw(board))
                {
                    break;
                }

                // Switch to the other player
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            // Display the final board
            DisplayBoard(board);

            // Check if the game was won or drawn
            if (IsWin(board, currentPlayer))
            {
                Console.WriteLine($"{currentPlayer} wins!");
            }
            else
            {
                Console.WriteLine("Draw.");
            }
        }

        // Function to display the game board
        static void DisplayBoard(char[,] board)
        {
            Console.WriteLine("   0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i}  ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("  ---+---+---");
            }
        }

        // Function to check if the game has been won
        static bool IsWin(char[,] board, char player)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == player && board[1, j] == player && board[2, j] == player)
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            // If no win, return false
            return false;
        }

        // Function to check if the game is a draw
        static bool IsDraw(char[,] board)
        {
            // Loop through each cell in the board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // If a cell is empty, the game is not a draw
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }

            // If no empty cells, the game is a draw
            return true;
        }
    }
}

