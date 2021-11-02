using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace Logic.AI
{
    public class RandomMoveSelector : MoveSelector
    {
        public override async Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer)
        {
            var cells = board.Cells;
            var shuffledCells = new List<Cell>();
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(0); y++)
                {
                    shuffledCells.Add(cells[x,y]);
                }
            }

            shuffledCells.Shuffle(new System.Random());

            foreach (var shuffledCell in shuffledCells)
            {
                if (new IsValidCellCommand(shuffledCell, board, player, otherPlayer).Execute(out var stoneToPlace))
                {
                    AddStoneToCell(board, stoneToPlace, shuffledCell);
                    return true;
                }
            }

            return false;
        }
    }
}