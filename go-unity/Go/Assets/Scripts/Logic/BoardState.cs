namespace Logic
{
    public class BoardState
    {
        private readonly CellOccupationState[,] cellStates;

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

        public override int GetHashCode()
        {
            return (cellStates != null ? cellStates.GetHashCode() : 0);
        }

        public static bool operator ==(BoardState state1, BoardState state2)
        {
            return Equals(state1,state2);
        }

        public static bool operator !=(BoardState state1, BoardState state2)
        {
            return !Equals(state1,state2);
        }
        
        private bool Equals(BoardState other)
        {
            var width = cellStates.GetLength(0);
            var height = cellStates.GetLength(1);

            var isEqual = true;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    isEqual &= cellStates[x, y] == other.cellStates[x, y];
                }
            }

            return isEqual;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BoardState)obj);
        }
    }
}