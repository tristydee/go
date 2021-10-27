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
        public Player(Board board, int index, IMoveSelector moveSelector)
        {
            this.board = board;
            this.moveSelector = moveSelector;
            Index = index;
        }

        public async Task TakeTurn()
        {
            HasPassed = false;
            var stone = await moveSelector.TryPlaceStone(board, Index);

            if (stone == null)
            {
                HasPassed = true;
                return;
            }

        }
    }
}