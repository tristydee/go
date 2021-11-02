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

        private readonly List<Cell> neighbouringEmptyCells = new List<Cell>();

        public int GetLiberties(Cell cell, Player player, out List<Cell> emptyNeighbouringCells)
        {
            var cellsInShape = GetShape(cell, player.OccupationState);

            foreach (var connectedFriendlyCell in cellsInShape)
            {
                var neighbouringCells = GetNeighbouringCells(connectedFriendlyCell, CellOccupationState.Empty);

                foreach (var neighbouringCell in neighbouringCells)
                {
                    if (neighbouringEmptyCells.Contains(neighbouringCell)) continue;
                    neighbouringEmptyCells.Add(neighbouringCell);
                }
            }

            emptyNeighbouringCells = neighbouringEmptyCells;
            return neighbouringEmptyCells.Count;
        }
        
        public List<Cell> GetShape(Cell currentCell, CellOccupationState occupationState)
        {
            var cellsInShape = new List<Cell> { currentCell };
            var neighbouringCells = GetNeighbouringCells(currentCell, occupationState);

            foreach (var neighbouringCell in neighbouringCells)
            {
                if (cellsInShape.Contains(neighbouringCell)) continue;
                GetShape(neighbouringCell, occupationState);
            }

            return cellsInShape;
        }


        public List<Cell> GetNeighbouringCells(Cell cell, CellOccupationState requiredOccupationState)
        {
            var neighbouringCells = new List<Cell>();
            var xPos = cell.Position.x;
            var yPos = cell.Position.y;

            neighbouringCells.Add(Cells[xPos - 1, yPos]);
            neighbouringCells.Add(Cells[xPos + 1, yPos]);
            neighbouringCells.Add(Cells[xPos, yPos + 1]);
            neighbouringCells.Add(Cells[xPos, yPos - 1]);

            for (var i = neighbouringCells.Count - 1; i >= 0; i--)
            {
                if (!requiredOccupationState.HasFlag(neighbouringCells[i].CellOccupationState))
                    neighbouringCells.Remove(neighbouringCells[i]);
            }

            return neighbouringCells;
        }
    }
}