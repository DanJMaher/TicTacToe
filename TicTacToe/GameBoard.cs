namespace TicTacToe
{
    class GameBoard
    {
        public char[] GameSpaces { get; private set; }

        //Initializes the GameSpace char array, and calls GameboardReset() to set initial values.
        public GameBoard()
        {
            GameSpaces = new char[9];
            GameboardReset();
        }

        //Resets the values of the gameSpace array.
        public void GameboardReset()
        {
            GameSpaces = "123456789".ToCharArray();
        }

    }
}