using System.Threading.Tasks;
using Common;

namespace Logic.AI
{
    public class RandomMoveSelector : IMoveSelector
    {
        public async Task<Stone> TryPlaceStone(Board board, int playerIndex)
        {
            var shuffledCells = board.Cells;
            shuffledCells.Shuffle(new System.Random());

            foreach (var shuffledCell in shuffledCells)
            {
                if (new IsValidCellCommand(shuffledCell, board, playerIndex).Execute(out var stone))
                    return stone;
            }

            return null;
        }
    }
}