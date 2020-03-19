using System;

namespace TicTacToe
{
    class SpaceSelector
    {
        private readonly Random rand = new Random();
        private int randomPosition;
        
        //Easy mode just randomly selects an empty space to place a game piece.
        public bool Easy(GameBoard ticTac, char ch)
        {
            do
            {
                randomPosition = rand.Next(ticTac.GameSpaces.Length);
                if (char.IsDigit(ticTac.GameSpaces[randomPosition]))
                {
                    PiecePlace.Computer(ticTac.GameSpaces, randomPosition, ch);
                    return false;
                }
            } while (true);
        }

        //Difficult mode checks, in-order, horizontal, vertical, and diagonal lines to see if there are two in a row of either 'X' or 'O'.  It then places a piece to complete the line.
        //Does not differentiate between 'X' and 'O', and uses no real strategy.
        public bool Difficult(GameBoard ticTac, char ch)
        {
            //Checks matches in horizontal spaces
            for (int i = 0; i < 7; i += 3)
            {
                if (ticTac.GameSpaces[i] == ticTac.GameSpaces[i + 1] || ticTac.GameSpaces[i + 1] == ticTac.GameSpaces[i + 2] || ticTac.GameSpaces[i] == ticTac.GameSpaces[i + 2])
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        if (char.IsDigit(ticTac.GameSpaces[j]))
                        {
                            PiecePlace.Computer(ticTac.GameSpaces, j, ch);
                            return false;
                        }
                    }
                }
            }

            //checks for matches in vertical spaces
            for (int i = 0; i < 3; i += 1)
            {
                if (ticTac.GameSpaces[i] == ticTac.GameSpaces[i + 3] || ticTac.GameSpaces[i + 3] == ticTac.GameSpaces[i + 6] || ticTac.GameSpaces[i] == ticTac.GameSpaces[i + 6])
                {
                    for (int j = i; j < i + 7; j += 3)
                    {
                        if (char.IsDigit(ticTac.GameSpaces[j]))
                        {
                            PiecePlace.Computer(ticTac.GameSpaces, j, ch);
                            return false;
                        }
                    }
                }
            }

            //checks for matches diagonally right
            if (ticTac.GameSpaces[0] == ticTac.GameSpaces[4] || ticTac.GameSpaces[4] == ticTac.GameSpaces[8] || ticTac.GameSpaces[0] == ticTac.GameSpaces[8])
            {
                for (int i = 0; i < 9; i += 4)
                {
                    if (char.IsDigit(ticTac.GameSpaces[i]))
                    {
                        PiecePlace.Computer(ticTac.GameSpaces, i, ch);
                        return false;
                    }
                }
            }

            //checks for matches diagonally left
            if (ticTac.GameSpaces[2] == ticTac.GameSpaces[4] || ticTac.GameSpaces[4] == ticTac.GameSpaces[6] || ticTac.GameSpaces[2] == ticTac.GameSpaces[6])
            {
                for (int i = 2; i < 7; i += 2)
                {
                    if (char.IsDigit(ticTac.GameSpaces[i]))
                    {
                        PiecePlace.Computer(ticTac.GameSpaces, i, ch);
                        return false;
                    }
                }
            }

            //if none of the above conditions are met, a random piece is placed
            Easy(ticTac, ch);
            return false;
        }
    }
}