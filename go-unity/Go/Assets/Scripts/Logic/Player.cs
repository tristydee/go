using System.Threading.Tasks;
using Logic.AI;

namespace Logic
{
    public class Player
    {
        public int Index;
        public bool HasPassed;

        private IMoveSelector moveSelector;
        private readonly Board board;

        //drag and drop script in settings to chose moveSelector
        public Player(Board board, IMoveSelector moveSelector)
        {
            this.board = board;
            this.moveSelector = moveSelector;
        }

        public async Task TakeTurn()
        {
            HasPassed = false;
            var stone = moveSelector.TryPlaceStone(board, Index);

            if (stone == null)
            {
                HasPassed = true;
                return;
            }

        }
    }
}