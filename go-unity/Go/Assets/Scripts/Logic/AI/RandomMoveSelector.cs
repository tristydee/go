using System.Linq;
using Common;

namespace Logic.AI
{
    public class RandomMoveSelector : IMoveSelector
    {
        //shuffle cells. then iterate through them until one is found that is Valid. If none valid, then pass
        public Stone TryPlaceStone(Board board, int playerIndex)
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