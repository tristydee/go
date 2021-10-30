using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Logic
{
    public class Board
    {
        public Cell[,] Cells;
        //todo: change to tree at some point?
        public BoardState CurrentBoardState;
        public List<BoardState> BoardStates = new List<BoardState>();

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

            CurrentBoardState = new BoardState(this);
            BoardStates.Add(CurrentBoardState);
        }
    }
}