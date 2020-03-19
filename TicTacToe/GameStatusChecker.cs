namespace TicTacToe
{
    class GameStatusChecker
    {
        //Checks to see if the game has been won.
        static public bool IsWon(char[] gameSpace, char i)
        {
            char ch = Solve(gameSpace);

            if (ch == i)
                return true;

            return false;

        }

        //Checks to see if the game is tied.
        static public bool IsTied(char[] gameSpace)
        {
            foreach (char ch in gameSpace)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        //Check() calls the Solve() method to actually see if there are three in a row anywhere.
        static private char Solve(char[] gameSpace)
        {
            if (gameSpace[0] == gameSpace[1] && gameSpace[1] == gameSpace[2])
                return gameSpace[0];
            if (gameSpace[3] == gameSpace[4] && gameSpace[4] == gameSpace[5])
                return gameSpace[3];
            if (gameSpace[6] == gameSpace[7] && gameSpace[7] == gameSpace[8])
                return gameSpace[6];
            if (gameSpace[0] == gameSpace[3] && gameSpace[3] == gameSpace[6])
                return gameSpace[0];
            if (gameSpace[1] == gameSpace[4] && gameSpace[4] == gameSpace[7])
                return gameSpace[1];
            if (gameSpace[2] == gameSpace[5] && gameSpace[5] == gameSpace[8])
                return gameSpace[2];
            if (gameSpace[0] == gameSpace[4] && gameSpace[4] == gameSpace[8])
                return gameSpace[0];
            if (gameSpace[2] == gameSpace[4] && gameSpace[4] == gameSpace[6])
                return gameSpace[2];
            return ' ';
        }
    }
}
