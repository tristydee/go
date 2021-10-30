using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Logic
{
    public class Board
    {
        public Cell[,] Cells;
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

        private List<Cell> connectedFriendlyCells = new List<Cell>();
        private List<Cell> neighbouringCells = new List<Cell>();

        public int GetLiberties(Cell cell, Player player)
        {
            //cell needs liberties of all friendly neighbouring occupied cells as well.


            connectedFriendlyCells.Clear();
            GetConnectedNeighbouringCells(cell);

            void GetConnectedNeighbouringCells(Cell currentCell)
            {
                neighbouringCells.Clear();
                var xPos = currentCell.Position.x;
                var yPos = currentCell.Position.y;

                neighbouringCells.Add(Cells[xPos - 1, yPos]);
                neighbouringCells.Add(Cells[xPos + 1, yPos]);
                neighbouringCells.Add(Cells[xPos, yPos + 1]);
                neighbouringCells.Add(Cells[xPos, yPos - 1]);
                
                foreach (var neighbouringCell in neighbouringCells)
                {
                    if(connectedFriendlyCells.Contains(neighbouringCell)) continue;
                    connectedFriendlyCells.Add(neighbouringCell);
                    GetConnectedNeighbouringCells(neighbouringCell);
                }
            }

            var liberties = 0;
            foreach (var connectedFriendlyCell in connectedFriendlyCells)
            {
                //todo: get amount of empty cells neighbouring this cell.
                //todo: getting neighbouring cells should be an extension method.
            }

            throw new NotImplementedException();
        }
    }
}