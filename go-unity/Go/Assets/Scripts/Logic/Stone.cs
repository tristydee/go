namespace Logic
{
    public class Stone
    {
        public readonly int PlayerIndex;
        public readonly Cell Cell;
        public int Liberties { get; }

        public Stone(int playerIndex, Cell cell)
        {
            PlayerIndex = playerIndex;
            Cell = cell;
        }
    }
}