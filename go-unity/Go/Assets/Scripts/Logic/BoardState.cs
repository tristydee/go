namespace Logic
{
    public class BoardState
    {
        public enum CellState
        {
            Empty,
            Player1,
            Player2,
        }

        public CellState[,] cellStates;

        public BoardState(Board board)
        {
            //create list of cell states here.
        }

        //todo: need to be able to check if two board states are equal. overload ==
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