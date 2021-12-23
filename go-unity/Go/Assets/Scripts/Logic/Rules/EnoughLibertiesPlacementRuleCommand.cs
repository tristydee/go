using UnityEngine;

namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell, Board board, Player player, Player otherPlayer)
        {
            // seeing how many liberties would shape have if we were to place stone here
            cell.AddOrRemoveStone(player.OccupationState);
            var cellHasEnoughLiberties = board.GetLiberties(cell, player.OccupationState) > 0;
            cell.AddOrRemoveStone(CellOccupationState.Empty);
            if (cellHasEnoughLiberties)
            {
                return true;
            }

            var enemyNeighbours = board.GetNeighbouringCells(cell, otherPlayer.OccupationState);

            foreach (var enemyNeighbour in enemyNeighbours)
            {
                var liberties = board.GetLiberties(enemyNeighbour, otherPlayer.OccupationState);
                if (liberties == 1) return true; // enemies last liberty has to be this cell.
            }

            Debug.Log("not enough liberties!");
            return false;
        }
    }
}