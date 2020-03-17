namespace TicTacToe
{
    public class TicTac
    {
        public char[] gameSpace { get; private set; }
        //internal char[] gameSpace = new char[9];

        public TicTac()
        {
            gameSpace = new char[9];
            GameboardReset();
        }

        //Places player pieces.
        public bool Place(string input, char ch)
        {
            if (!int.TryParse(input, out int position))
                return false;
            try
            {
                if (char.IsDigit(gameSpace[position - 1]))
                {
                    gameSpace[position - 1] = ch;

                    return true;
                }
            }
            catch { }

            return false;
        }

        //Places computer's pieces.
        public void Place(int position, char ch)
        {
            gameSpace[position] = ch;
        }

        //Checks to see if the game has been won.
        public bool Check(char i)
        {
            char ch = Solve();

            if (ch == i)
                return true;

            return false;

        }

        //Checks to see if the game is tied.
        public bool Cat()
        {
            foreach (char ch in this.gameSpace)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        //Check() calls the Solve() method to actually see if there are three in a row anywhere.
        private char Solve()
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

        //Resets the values of the gameSpace array.
        public void GameboardReset()
        {
            gameSpace = "123456789".ToCharArray();
        }

    }
}
