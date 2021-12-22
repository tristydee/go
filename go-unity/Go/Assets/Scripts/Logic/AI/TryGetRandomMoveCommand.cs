using System;
using System.Collections.Generic;
using Common;
using Configs;
using UnityEngine;
using Random = System.Random;

namespace Logic.AI
{
    public class TryGetRandomMoveCommand
    {
        private Random random;
        private Board board;
        private Player player;
        private Player otherPlayer;
        private Config config;

        public TryGetRandomMoveCommand(Random random, Board board, Player player, Player otherPlayer, Config config)
        {
            this.random = random;
            this.board = board;
            this.player = player;
            this.otherPlayer = otherPlayer;
            this.config = config;
        }


        public bool Execute(out Vector2Int position)
        {
            position = Vector2Int.zero;
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
                if (new IsValidCellCommand(shuffledCell, board, player, otherPlayer, config.PlacementRules).Execute())
                {
                    position = shuffledCell.Position;
                    return true;
                }
            }

            return false;
        }
    }
}