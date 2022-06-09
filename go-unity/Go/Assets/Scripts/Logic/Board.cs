using System.Collections.Generic;
using Configs;
using Logic.AI;
using UnityEngine;
using Zenject;

namespace Logic
{
    public class Board
    {
        public Cell[,] Cells;
        public readonly List<BoardState> BoardStates = new List<BoardState>();
        public BoardState CurrentBoardState;

        [Inject] private Settings settings;
        [Inject] private Assets assets;

        public Board Init()
        {
            var size = settings.BoardSize;
            Cells = new Cell[size.x, size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Cells[x, y] = new Cell(new Vector2Int(x, y), assets.CellPrefab, assets.StonePrefab);
                }
            }

            UpdateState();

            return this;
        }

        public void UpdateState()
        {
            CurrentBoardState = new BoardState(this);
            BoardStates.Add(CurrentBoardState);
        }

        public void SetCellsFromState(BoardState state)
        {
            var width = Cells.GetLength(0);
            var height = Cells.GetLength(1);
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y].AddOrRemoveStone(state.CellStates[x, y]);
                }
            }
        }
        
        public int GetLiberties(Cell cell, CellOccupationState occupationState)
        {
            var emptyNeighbouringCells = new List<Cell>();
            var cellsInShape = GetShape(cell, occupationState);

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

            return cellsInShape;
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

            return neighbouringCells;

            void AddCellToList(int x, int y)
            {
                if (x >= 0 && x < Cells.GetLength(0) && y >= 0 && y < Cells.GetLength(1))
                {
                    if (requiredOccupationState.HasFlag(Cells[x, y].CellOccupationState))
                        neighbouringCells.Add(Cells[x, y]);
                }
            }
        }
    }
}