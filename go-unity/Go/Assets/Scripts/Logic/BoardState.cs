namespace Logic
{
    public class BoardState
    {
        public CellOccupationState[,] CellStates { get; }

        public BoardState(Board board)
        {
            var width = board.Cells.GetLength(0);
            var height = board.Cells.GetLength(1);
            
            CellStates = new CellOccupationState[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    CellStates[x, y] = board.Cells[x, y].CellOccupationState;
                }
            }
        }

        public override int GetHashCode()
        {
            return (CellStates != null ? CellStates.GetHashCode() : 0);
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
            var width = CellStates.GetLength(0);
            var height = CellStates.GetLength(1);

            var isEqual = true;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    isEqual &= CellStates[x, y] == other.CellStates[x, y];
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