using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Logic
{
    public class Board
    {
        public Cell[,] Cells;
        public BoardState BoardState;

        public Board(Vector2Int size, Assets assets)
        {

            Cells = new Cell[size.x, size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Cells[x, y] = new Cell(new Vector2Int(x, y), assets.CellPrefab, assets.StonePrefab);
                }
            }

            BoardState = new BoardState(this);
        }
    }
}