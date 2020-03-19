namespace TicTacToe
{
    class PiecePlace
    {
        //Places player pieces.
        static public bool Player(char[] gameSpace, string input, char ch)
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
        static public void Computer(char[] gameSpace, int position, char ch)
        {
            gameSpace[position] = ch;
        }
    }
}