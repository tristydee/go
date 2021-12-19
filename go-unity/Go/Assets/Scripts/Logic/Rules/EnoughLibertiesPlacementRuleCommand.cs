using UnityEngine;

namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell, Board board, Player player, Player otherPlayer)
        {
            var cellHasEnoughLiberties = board.GetLiberties(cell, player) > 0;

            if (cellHasEnoughLiberties)
            {
                // bug is here somewhere... placing stones with no liberties. Is board.GetLiberties funky?
                Debug.Log("cell has enough liberties");
                return true;
            }

            var enemyNeighbours = board.GetNeighbouringCells(cell, otherPlayer.OccupationState);

            foreach (var enemyNeighbour in enemyNeighbours)
            {
                var liberties = board.GetLiberties(enemyNeighbour, otherPlayer);
                if (liberties == 1) return true; // enemies last liberty has to be this cell.
            }

            return false;
        }
    }
}