using System;

namespace TicTacToe
{
    class TicTacAI
    {
        private readonly Random rand = new Random();
        private int randomPosition;
        
        //Easy mode just randomly selects an empty space to place a game piece.
        public void Easy(TicTac ticTac, char ch)
        {
            do
            {
                randomPosition = rand.Next(ticTac.gameSpace.Length);
                if (char.IsDigit(ticTac.gameSpace[randomPosition]))
                {
                    ticTac.Place(randomPosition, ch);
                    break;
                }
            } while (true);
        }

        //Difficult mode checks, in-order, horizontal, vertical, and diagonal lines to see if there are two in a row of either 'X' or 'O'.  It then places a piece to complete the line.
        //Does not differentiate between 'X' and 'O', and uses no real strategy.
        public bool Difficult(TicTac ticTac, char ch)
        {
            //Checks matches in horizontal spaces
            for (int i = 0; i < 7; i += 3)
            {
                if (ticTac.gameSpace[i] == ticTac.gameSpace[i + 1] || ticTac.gameSpace[i + 1] == ticTac.gameSpace[i + 2] || ticTac.gameSpace[i] == ticTac.gameSpace[i + 2])
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        if (char.IsDigit(ticTac.gameSpace[j]))
                        {
                            ticTac.Place(j, ch);
                            return false;
                        }
                    }
                }
            }

            //checks for matches in vertical spaces
            for (int i = 0; i < 3; i += 1)
            {
                if (ticTac.gameSpace[i] == ticTac.gameSpace[i + 3] || ticTac.gameSpace[i + 3] == ticTac.gameSpace[i + 6] || ticTac.gameSpace[i] == ticTac.gameSpace[i + 6])
                {
                    for (int j = i; j < i + 7; j += 3)
                    {
                        if (char.IsDigit(ticTac.gameSpace[j]))
                        {
                            ticTac.Place(j, ch);
                            return false;
                        }
                    }
                }
            }

            //checks for matches diagonally right
            if (ticTac.gameSpace[0] == ticTac.gameSpace[4] || ticTac.gameSpace[4] == ticTac.gameSpace[8] || ticTac.gameSpace[0] == ticTac.gameSpace[8])
            {
                for (int i = 0; i < 9; i += 4)
                {
                    if (char.IsDigit(ticTac.gameSpace[i]))
                    {
                        ticTac.Place(i, ch);
                        return false;
                    }
                }
            }

            //checks for matches diagonally left
            if (ticTac.gameSpace[2] == ticTac.gameSpace[4] || ticTac.gameSpace[4] == ticTac.gameSpace[6] || ticTac.gameSpace[2] == ticTac.gameSpace[6])
            {
                for (int i = 0; i < 7; i += 2)
                {
                    if (char.IsDigit(ticTac.gameSpace[i]))
                    {
                        ticTac.Place(i, ch);
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
