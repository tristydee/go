using System.Collections.Generic;
using System.Linq;
using Common;

namespace Logic.Scoring
{
    public class AreaScoringCommand : ScoringCommand
    {
        private readonly List<Cell> checkedCells = new List<Cell>();
        private readonly List<CellOccupationState> bumpedPlayers = new List<CellOccupationState>();

        public override Score[] Execute()
        {
            foreach (var cell in Game.Board.Cells)
            {
                GetCellScore(cell, Game.Board);
            }

            return Score;
        }

        private void GetCellScore(Cell cell, Board board)
        {
            if (cell.IsOccupied)
            {
                Score.First(s => s.Player.OccupationState == cell.CellOccupationState).Points++;
                return;
            }

            checkedCells.Clear();
            bumpedPlayers.Clear();

            ExpandSearch(cell);

            if (bumpedPlayers.Count == 1)
            {
                Score.First(s => s.Player.OccupationState == bumpedPlayers[0]).Points++;
            }


            void ExpandSearch(Cell currentCell)
            {
                checkedCells.Add(currentCell);
                var neighbours = board.GetNeighbouringCells(currentCell, CellOccupationState.Any);
                foreach (var neighbour in neighbours)
                {
                    if (checkedCells.Contains(currentCell)) continue;
                    if (cell.IsOccupied)
                    {
                        bumpedPlayers.AddDistinct(cell.CellOccupationState);
                        if (bumpedPlayers.Count > 1)
                            break;
                    }
                    else
                        ExpandSearch(neighbour);
                }

                if (bumpedPlayers.Count == 1)
                {
                    Score.First(s => s.Player.OccupationState == bumpedPlayers[0]).Points++;
                } 
            }


        }
    }
}