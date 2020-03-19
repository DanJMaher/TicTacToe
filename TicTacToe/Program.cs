using System;

namespace TicTacToe
{
    class Program
    {
        static private readonly GameBoard gameBoard = new GameBoard(); //Holds all of the methods for placing and solving the game.
        static private readonly SpaceSelector spaceSelector = new SpaceSelector();  //Holds all of the methods used in a single-player game.
        static private string input;  //Holder for user console input.
        static private char xOrO = 'X';  //Determines whether the 'X' or 'O' char is sent to methods.  Switches every turn.
        static private bool isUserTurn;  //Determines turn order in a game vs. the computer.
        static private bool isFirstPlayer;
        static private string gameType;
        static private string difficulty;

        static void Main()
        {
            gameType = ChooseOpponent();

            if (gameType == "multiplayer") //Multiplayer game     
                Game();

            if (gameType == "singleplayer") //Sends the player to the "choose difficulty" menu if single-player is selected
            {
                difficulty = ChooseDifficulty();
                isFirstPlayer = isUserTurn = ChooseGamePiece();
            }

            if (difficulty == "easy")
            {
                Game(spaceSelector.Easy);
            }
            else if (difficulty == "difficult")
            {
                Game(spaceSelector.Difficult);
            }
        }

        static string ChooseOpponent()

        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Welcome to Tic-Tac-Toe!  \n\nEnter \"Computer\" to play the computer, or enter \"Multiplayer\" to play versus another human:  ");
            do
            {
                input = Console.ReadLine();

                if (input.ToLower() == "computer")
                {
                    return "singleplayer";
                }
                else if (input.ToLower() == "multiplayer")
                {
                    return "multiplayer";
                }
                else
                {
                    Console.Write("{0} is an invalid entry! Please enter \"Computer\" or \"Multiplayer\" to continue: ", input);
                    continue;
                }
            } while (true);
        }

        //Easy difficulty is just the computer randomly placing tiles.  Difficult uses a bit of logic, but no real strategies.
        static string ChooseDifficulty()
        {
            Console.Write("Enter \"Difficult\" or \"Easy\": ");
            do
            {
                input = Console.ReadLine();
                if (input.ToLower() == "difficult")
                {
                    return "difficult";
                }
                else if (input.ToLower() == "easy")
                {
                    return "easy";
                }
                else
                {
                    Console.Write("{0} is an invalid entry! Please enter \"Difficult\" or \"Easy\" to continue: ", input);
                    continue;
                }
            } while (true);
        }

        //Allows the player in a single-player game to choose whether to go first (X) or second (O).
        static bool ChooseGamePiece()
        {
            Console.Write("Enter \"X\" or \"O\" to choose game piece.  Remember, \"X\" always goes first: ");
            do
            {
                input = Console.ReadLine();
                if (input.ToLower() == "x")
                {
                    return true;
                }
                else if (input.ToLower() == "o")
                {
                    return false;
                }
                else
                {
                    Console.Write("{0} is an invalid entry! Please enter \"X\" or \"O\" to continue: ", input);
                    continue;
                }

            } while (true);
        }

        static void Game()
        {
            do
            {
                Console.Clear();
                GameboardDisplay();
                UserTurn();

                Console.Clear();

                //checks to see if the current player is the winner and processes the result.
                if (GameStatusChecker.IsWon(gameBoard.GameSpaces, xOrO))
                {
                    string endText = " " + xOrO + "'s Win!\n";
                    EndGame(endText);
                    continue;
                }

                if (GameStatusChecker.IsTied(gameBoard.GameSpaces))
                {
                    string endText = " Cat's Game!\n";
                    EndGame(endText);
                    continue;
                }

                SwitchPlayer();

            } while (true);
        }

        static void Game(Func<GameBoard, char, bool> positionSelector)
        {
            do
            {
                Console.Clear();
                GameboardDisplay();

                if (isUserTurn)
                {
                    UserTurn();
                    isUserTurn = false;
                }

                else if (!isUserTurn)
                {
                    positionSelector(gameBoard, xOrO);
                    isUserTurn = true;
                }

                Console.Clear();

                //checks to see if the current player is the winner and processes the result.
                if (GameStatusChecker.IsWon(gameBoard.GameSpaces, xOrO))
                {
                    string endText = " " + xOrO + "'s Win!\n";
                    EndGame(endText);
                    continue;
                }

                if (GameStatusChecker.IsTied(gameBoard.GameSpaces))
                {
                    string endText = " Cat's Game!\n";
                    EndGame(endText);
                    continue;
                }
                SwitchPlayer();

            } while (true);
        }

        static void UserTurn()
        {
            Console.Write(" {0}'s turn!  Enter a space number to place your piece: ", xOrO);
            do
            {
                input = Console.ReadLine();
                if (!PiecePlace.Player(gameBoard.GameSpaces, input, xOrO))
                {
                    Console.Write(" {0} is not a valid entry!  Try again: ", input);
                    continue;
                }
                break;
            } while (true);
        }

        static void SwitchPlayer()
        {
            //checks the current player.  If it's X, switches it to O. If it's O, switches it to X.
            if (xOrO == 'X')
                xOrO = 'O';
            else
                xOrO = 'X';
        }

        //Refreshes the gameboard on the console.
        static void GameboardDisplay()
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++)

            {
                if (gameBoard.GameSpaces[i] == 'X')
                    Console.ForegroundColor = ConsoleColor.Red;
                if (gameBoard.GameSpaces[i] == 'O')
                    Console.ForegroundColor = ConsoleColor.Green;

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine(" {0} ", gameBoard.GameSpaces[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(" {0} ", gameBoard.GameSpaces[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }

        //The following two methods are used to display end-game text for a win or a tie.
        static void EndGame(string str)
        {
            GameboardDisplay();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(" {0}'s Win!\n", xOrO);
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Press any key to play again...");
            Console.ReadKey();
            gameBoard.GameboardReset();
            Console.Clear();
            xOrO = 'X';

            if (isFirstPlayer)
            {
                isUserTurn = true;
            }
            else
            {
                isUserTurn = false;
            }
        }
    }
}