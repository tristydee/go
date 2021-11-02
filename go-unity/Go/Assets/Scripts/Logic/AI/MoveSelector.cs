using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.AI
{
    public abstract class MoveSelector
    {
        public abstract Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer);

        private List<Cell> cellsToCapture = new List<Cell>();
        protected void AddStoneToCell(Board board, Stone stone, Cell cell)
        {
            cellsToCapture.Clear();
            cell.AddStone(stone);
            var enemyNeighbours = board.GetNeighbouringCells(cell, stone.OtherPlayer.OccupationState);
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                if(board.GetLiberties(enemyNeighbour, stone.OtherPlayer,out var _) > 0) continue;
                var shape = board.GetShape(enemyNeighbour, stone.OtherPlayer.OccupationState);
                cellsToCapture.AddRange(shape);
            }
            
            foreach (var cellToCapture in cellsToCapture)
            {
                cellToCapture.RemoveStone();
            }
            
        }
    }
}