using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Configs;
using UnityEngine;
using Random = System.Random;

namespace Logic.AI
{
    public class RandomMoveSelector : MoveSelector
    {
        private readonly Random random;

        public RandomMoveSelector()
        {
            random = new Random();
        }
        
        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer, Config config)
        {
            var cells = board.Cells;
            var shuffledCells = new List<Cell>();
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    shuffledCells.Add(cells[x, y]);
                }
            }

            shuffledCells.Shuffle(random);

            foreach (var shuffledCell in shuffledCells)
            {
                if (new IsValidCellCommand(shuffledCell, board, player, otherPlayer, config.PlacementRules).Execute(out var stoneToPlace))
                {
                    AddStoneToCell(board, stoneToPlace, shuffledCell);
                    return true;
                }
            }

            return false;
        }
    }
}