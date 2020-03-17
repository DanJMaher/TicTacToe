using System;

namespace TicTacToe
{
    class Program
    {
        static private readonly TicTac ticTac = new TicTac(); //Holds all of the methods for placing and solving the game.
        static private readonly TicTacAI ticTacAI = new TicTacAI();  //Holds all of the methods used in a single-player game.
        static private string input;  //Holder for user console input.
        static private char xOrO;  //Determines whether the 'X' or 'O' char is sent to methods.  Switches every turn.
        static private bool playerTurn;  //Determines turn order in a game vs. the computer.

        static void Main()
        {
            MainMenu();
        }

        static void MainMenu()

        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Welcome to Tic-Tac-Toe!  \n\nEnter \"Computer\" to play the computer, or enter \"Multiplayer\" to play versus another human:  ");
            do
            {
                input = Console.ReadLine();

                if (input.ToLower() == "computer")
                {
                    ChooseDifficulty();
                }
                else if (input.ToLower() == "multiplayer")
                {
                    Multiplayer();
                }
                else
                {
                    Console.Write("{0} is an invalid entry! Please enter \"Computer\" or \"Multiplayer\" to continue: ", input);
                    continue;
                }
            } while (true);
        }

        //Easy difficulty is just the computer randomly placing tiles.  Difficult uses a bit of logic, but no real strategies.
        static void ChooseDifficulty()
        {
            Console.Write("Enter \"Difficult\" or \"Easy\": ");
            do
            {
                input = Console.ReadLine();
                if (input.ToLower() == "difficult")
                {
                    ChooseGamePiece();
                    CompDifficult();
                }
                else if (input.ToLower() == "easy")
                {
                    ChooseGamePiece();
                    CompEasy();
                }
                else
                {
                    Console.Write("{0} is an invalid entry! Please enter \"Difficult\" or \"Easy\" to continue: ", input);
                    continue;
                }
            } while (true);
        }

        //Allows the player in a single-player game to choose whether to go first (X) or second (O).
        static void ChooseGamePiece()
        {
            Console.Write("Enter \"X\" or \"O\" to choose game piece.  Remember, \"X\" always goes first: ");
            do
            {
                input = Console.ReadLine();
                if (input.ToLower() == "x")
                {
                    playerTurn = true;
                    break;
                }
                else if (input.ToLower() == "o")
                {
                    playerTurn = false;
                    break;
                }
                else
                {
                    Console.Write("{0} is an invalid entry! Please enter \"X\" or \"O\" to continue: ", input);
                    continue;
                }
            } while (true);
            xOrO = 'X';
        }

        //The following three methods hold the console display logic for the three types of games; multiplayer, single-player easy, and single-player difficult.
        static void Multiplayer()
        {
            xOrO = 'X';
            do
            {
                Console.Clear();
                GameboardDisplay();

                Console.Write(" {0}'s Turn!  Enter a space number to place an {0}: ", xOrO);

                while (true)
                {
                    input = Console.ReadLine();

                    //tries to place the current players symbol.
                    if (!ticTac.Place(input, xOrO))
                    {
                        Console.Write(" {0} is not a valid entry!  Try again: ", input);
                        continue;
                    }
                    break;
                }

                Console.Clear();

                //checks to see if the current player is the winner and processes the result.
                if (ticTac.Check(xOrO))
                {
                    EndGame(xOrO);
                    continue;
                }

                if (ticTac.Cat())
                {
                    CatGame();
                    continue;
                }

                //checks the current player.  If it's X, switches it to O. If it's O, switches it to X.
                if (xOrO == 'X')
                    xOrO = 'O';
                else
                    xOrO = 'X';
            } while (true);
        }

        static void CompEasy()
        {
            do
            {
                if (playerTurn)
                {
                    Console.Clear();
                    GameboardDisplay();

                    Console.Write(" Your Turn!  Enter a space number to place your piece: ");
                    do
                    {
                        input = Console.ReadLine();
                        if (!ticTac.Place(input, xOrO))
                        {
                            Console.Write(" {0} is not a valid entry!  Try again: ", input);
                            continue;
                        }
                        break;
                    } while (true);
                    playerTurn = false;
                }
                else if (!playerTurn)
                {
                    ticTacAI.Easy(ticTac, xOrO);
                    playerTurn = true;
                }

                Console.Clear();

                //checks to see if the current player is the winner and processes the result.
                if (ticTac.Check(xOrO))
                {
                    EndGame(xOrO);
                    ChooseGamePiece();
                    continue;
                }

                if (ticTac.Cat())
                {
                    CatGame();
                    ChooseGamePiece();
                    continue;
                }

                //checks the current player.  If it's X, switches it to O. If it's O, switches it to X.
                if (xOrO == 'X')
                    xOrO = 'O';
                else
                    xOrO = 'X';
            } while (true);
        }

        static void CompDifficult()
        {
            do
            {
                if (playerTurn)
                {
                    Console.Clear();
                    GameboardDisplay();

                    Console.Write(" Your Turn!  Enter a space number to place your piece: ");
                    do
                    {
                        input = Console.ReadLine();
                        if (!ticTac.Place(input, xOrO))
                        {
                            Console.Write(" {0} is not a valid entry!  Try again: ", input);
                            continue;
                        }
                        break;
                    } while (true);                    
                    playerTurn = false;
                }
                else if (!playerTurn)
                {
                    ticTacAI.Difficult(ticTac, xOrO);
                    playerTurn = true;
                }

                Console.Clear();

                //checks to see if the current player is the winner and processes the result.
                if (ticTac.Check(xOrO))
                {
                    EndGame(xOrO);
                    ChooseGamePiece();
                    continue;
                }

                if (ticTac.Cat())
                {
                    CatGame();
                    ChooseGamePiece();
                    continue;
                }

                //checks the current player.  If it's X, switches it to O. If it's O, switches it to X.
                if (xOrO == 'X')
                    xOrO = 'O';
                else
                    xOrO = 'X';
            } while (true);
        }

        //Refreshes the gameboard on the console.
        static void GameboardDisplay()
        {
            Console.WriteLine();
            for (int i = 0; i < 9; i++)

            {
                if (ticTac.gameSpace[i] == 'X')
                    Console.ForegroundColor = ConsoleColor.Red;
                if (ticTac.gameSpace[i] == 'O')
                    Console.ForegroundColor = ConsoleColor.Green;

                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine(" {0} ", ticTac.gameSpace[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(" {0} ", ticTac.gameSpace[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }

        //The following two methods are used to display end-game text for a win or a tie.
        static void EndGame(char xOrO)
        {
            GameboardDisplay();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" {0}'s Win!\n", xOrO);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Press any key to play again...");
            Console.ReadKey();
            ticTac.GameboardReset();
            Console.Clear();
        }

        static void CatGame()
        {
            GameboardDisplay();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Cat's Game!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Press any key to play again...");
            Console.ReadKey();
            ticTac.GameboardReset();
            Console.Clear();
        }
    }
}