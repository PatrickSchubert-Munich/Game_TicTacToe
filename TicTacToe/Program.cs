using System;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initial fields
            char[,] initialField = {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };

            // Players fields
            char[,] board = {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };

            // Initial params
            int count = 1;
            int player = 2;
            char playerX = 'X';
            char playerO = 'O';
            bool isWinner = false;

            // Set initial fields
            setField(initialField);

            while (count <= 9 && isWinner == false)
            {
                if (player == 2)
                {
                    player = 1;
                }
                else
                {
                    player = 2;
                }

                switch (player)
                {
                    case 1:
                        Console.WriteLine(PlayerInfo(player));
                        UserInput(board, player, playerX);
                        break;
                    case 2:
                        Console.WriteLine(PlayerInfo(player));
                        UserInput(board, player, playerO);
                        break;
                }

                isWinner = CheckWinner(board);
                Console.Write(Output(isWinner, player, count));
                count++;
            }
        }

        private static void setField(char[,] board)
        {
            Console.Clear();
            Console.WriteLine("     |     |    ");
            Console.WriteLine($"  {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}  ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine("     |     |    ");
            Console.WriteLine($"  {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}  ");
            Console.WriteLine("-----|-----|-----");
            Console.WriteLine("     |     |    ");
            Console.WriteLine($"  {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}  ");
            Console.WriteLine("     |     |    ");
            Console.WriteLine();
        }

        private static char[,] ReplaceFields(char[,] board, int value, char sign)
        {
            if (value == 1) board[0, 0] = sign;
            if (value == 2) board[0, 1] = sign;
            if (value == 3) board[0, 2] = sign;
            if (value == 4) board[1, 0] = sign;
            if (value == 5) board[1, 1] = sign;
            if (value == 6) board[1, 2] = sign;
            if (value == 7) board[2, 0] = sign;
            if (value == 8) board[2, 1] = sign;
            if (value == 9) board[2, 2] = sign;
            return board;
        }

        private static string PlayerInfo(int player)
        {
            return $"\nPlayer {player}: Choose your field! ";
        }

        private static void UserInput(char[,] board, int player, char signPlayer)
        {
            int inputValue;
            // User Input
            while (true)
            {
                bool isInteger = int.TryParse(Console.ReadLine(), out inputValue);
                if (isInteger && inputValue >= 1 && inputValue <= 9)
                {
                    if (checkFields(board, inputValue))
                    {
                        ReplaceFields(board, inputValue, signPlayer);
                        setField(board);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Field can´t be set double times.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter correct number!");
                    Console.WriteLine(PlayerInfo(player));
                    continue;
                }
            }
        }

        private static bool checkFields(char[,] board, int inputValue)
        {
            bool isFree = false;
            if (inputValue == 1 && board[0, 0] != 'X' && board[0, 0] != 'O') isFree = true;
            if (inputValue == 2 && board[0, 1] != 'X' && board[0, 1] != 'O') isFree = true;
            if (inputValue == 3 && board[0, 2] != 'X' && board[0, 2] != 'O') isFree = true;
            if (inputValue == 4 && board[1, 0] != 'X' && board[1, 0] != 'O') isFree = true;
            if (inputValue == 5 && board[1, 1] != 'X' && board[1, 1] != 'O') isFree = true;
            if (inputValue == 6 && board[1, 2] != 'X' && board[1, 2] != 'O') isFree = true;
            if (inputValue == 7 && board[2, 0] != 'X' && board[2, 0] != 'O') isFree = true;
            if (inputValue == 8 && board[2, 1] != 'X' && board[2, 1] != 'O') isFree = true;
            if (inputValue == 9 && board[2, 2] != 'X' && board[2, 2] != 'O') isFree = true;
            return isFree;
        }

        private static bool CheckWinner(char[,] board)
        {
            // init params
            bool isWinner = false;
            string winnerSign = "";
            int row = board.GetLength(0);

            // get all values from array
            for (int i = 0; i < row; i++)
            {
                // check horizontal
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    isWinner = true;
                    winnerSign = board[i, 0].ToString();
                    break;
                }

                // check vertical
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    isWinner = true;
                    winnerSign = board[0, i].ToString();
                    break;
                }

                // check diagonal 
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
                     board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                {
                    isWinner = true;
                    winnerSign = board[1, 1].ToString();
                    break;
                }
            }

            return isWinner;
        }

        private static string Output(bool isWinner, int player, int count)
        {
            // Output
            char sign = player == 1 ? 'X' : 'O';
            string interimOutput = isWinner ? $"Game Finished!\nDer Gewinner ist Player {sign}\n" : count <= 9 ? "" : "Es gibt keinen Gewinner.";
            return interimOutput;
        }
    }
}
