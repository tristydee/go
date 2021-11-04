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


            UpdateState();
        }

        public void UpdateState()
        {
            CurrentBoardState = new BoardState(this);
            BoardStates.Add(CurrentBoardState);
        }

        public int GetLiberties(Cell cell, Player player, out List<Cell> emptyNeighbouringCells)
        {
            var cellsInShape = GetShape(cell, player.OccupationState);

            emptyNeighbouringCells = new List<Cell>();
            
            foreach (var connectedFriendlyCell in cellsInShape)
            {
                var neighbouringCells = GetNeighbouringCells(connectedFriendlyCell, CellOccupationState.Empty);

                foreach (var neighbouringCell in neighbouringCells)
                {
                    if (emptyNeighbouringCells.Contains(neighbouringCell)) continue;
                    emptyNeighbouringCells.Add(neighbouringCell);
                }
            }

            return emptyNeighbouringCells.Count;
        }

        public List<Cell> GetShape(Cell currentCell, CellOccupationState occupationState)
        {
            var cellsInShape = new List<Cell>();
            AddNeighboursToList(currentCell);
            return cellsInShape;

            void AddNeighboursToList(Cell cell)
            {
                cellsInShape.Add(cell);
                var neighbouringCells = GetNeighbouringCells(cell, occupationState);

                foreach (var neighbouringCell in neighbouringCells)
                {
                    if (cellsInShape.Contains(neighbouringCell)) continue;
                    AddNeighboursToList(neighbouringCell);
                }
            }
        }


        public List<Cell> GetNeighbouringCells(Cell cell, CellOccupationState requiredOccupationState)
        {
            var neighbouringCells = new List<Cell>();
            var xPos = cell.Position.x;
            var yPos = cell.Position.y;

            AddCellToList(xPos - 1, yPos);
            AddCellToList(xPos + 1, yPos);
            AddCellToList(xPos, yPos + 1);
            AddCellToList(xPos, yPos - 1);

            for (var i = neighbouringCells.Count - 1; i >= 0; i--)
            {
                if (!requiredOccupationState.HasFlag(neighbouringCells[i].CellOccupationState))
                    neighbouringCells.Remove(neighbouringCells[i]);
            }

            return neighbouringCells;

            void AddCellToList(int x, int y)
            {
                if (x >= 0 && x < Cells.GetLength(0) && y >= 0 && y < Cells.GetLength(1))
                    neighbouringCells.Add(Cells[x, y]);
            }
        }
    }
}