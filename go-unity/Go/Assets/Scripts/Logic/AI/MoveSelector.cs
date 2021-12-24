using System.Collections.Generic;
using Configs;
using Random = System.Random;

namespace Logic.AI
{
    public abstract class MoveSelector
    {
        protected readonly Random Random;

        private List<Cell> cellsToCapture = new List<Cell>();

        protected MoveSelector()
        {
            Random = new Random();
        }

        public virtual void Init(Game game)
        {
        }

        public abstract bool TryPlaceStone(Board board, Player player, Player otherPlayer, Config config);


        protected void AddStoneToCell(Board board, CellOccupationState occupationState, Cell cell)
        {
            cellsToCapture.Clear();
            cell.AddOrRemoveStone(occupationState);
            var enemyNeighbours = board.GetNeighbouringCells(cell, occupationState.OtherPlayer());
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                if (board.GetLiberties(enemyNeighbour, occupationState.OtherPlayer()) > 0) continue;
                var shape = board.GetShape(enemyNeighbour, occupationState.OtherPlayer());
                cellsToCapture.AddRange(shape);
            }

            foreach (var cellToCapture in cellsToCapture)
            {
                cellToCapture.AddOrRemoveStone(CellOccupationState.Empty);
            }
        }
    }
}