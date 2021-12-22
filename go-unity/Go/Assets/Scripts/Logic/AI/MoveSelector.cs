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


        protected void AddStoneToCell(Board board, Stone stone, Cell cell)
        {
            cellsToCapture.Clear();
            cell.AddStone(stone);
            var enemyNeighbours = board.GetNeighbouringCells(cell, stone.OtherPlayer.OccupationState);
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                if (board.GetLiberties(enemyNeighbour, stone.OtherPlayer) > 0) continue;
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