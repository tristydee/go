using System.Threading.Tasks;
using Common;

namespace Logic.AI
{
    public class RandomMoveSelector : MoveSelector
    {
        public override async Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer)
        {
            var shuffledCells = board.Cells;
            shuffledCells.Shuffle(new System.Random());

            foreach (var shuffledCell in shuffledCells)
            {
                if (new IsValidCellCommand(shuffledCell, board, player, otherPlayer).Execute(out var stoneToPlace, out var stonesToRemove))
                {
                    AddStoneToCell(stoneToPlace, shuffledCell);
                    if (stonesToRemove != null)
                    {
                        stonesToRemove.ForEach(stone => stone.Cell.RemoveStone());
                    }
                    return true;
                }
            }

            return false;
        }
    }
}