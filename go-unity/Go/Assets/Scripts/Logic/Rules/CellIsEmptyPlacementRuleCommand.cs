using UnityEngine;

namespace Logic.Rules
{
    public class CellIsEmptyPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell,Board board, Player player)
        {
            return !cell.IsOccupied;
        }
    }
}