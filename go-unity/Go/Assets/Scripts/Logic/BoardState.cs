namespace Logic
{
    public class BoardState
    {

        public CellOccupationState[,] cellStates;

        public BoardState(Board board)
        {
            var width = board.Cells.GetLength(0);
            var height = board.Cells.GetLength(1);
            
            cellStates = new CellOccupationState[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cellStates[x, y] = board.Cells[x, y].CellOccupationState;
                }
            }
        }

        public static bool operator ==(BoardState state1, BoardState state2)
        {
            return AreStatesEqual(state1, state2);
        }

        public static bool operator !=(BoardState state1, BoardState state2)
        {
            return !AreStatesEqual(state1, state2);
        }

        private static bool AreStatesEqual(BoardState state1, BoardState state2)
        {
            var width = state1.cellStates.GetLength(0);
            var height = state1.cellStates.GetLength(1);

            var isEqual = true;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    isEqual &= state1.cellStates[x, y] == state2.cellStates[x, y];
                }
            }

            return isEqual;
        }
    }
}