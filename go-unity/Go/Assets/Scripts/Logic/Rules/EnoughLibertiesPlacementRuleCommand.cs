using System.Linq;

namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        public EnoughLibertiesPlacementRuleCommand(Cell cell, Board board, Player player) : base(cell, board, player)
        {
        }

        public override bool Execute()
        {
            var cellHasEnoughLiberties = Board.GetLiberties(Cell, Player, out _) > 0;

            if (cellHasEnoughLiberties) return true;

            var enemyNeighbours = Board.GetNeighbouringCells(Cell, Player.OtherPlayer.OccupationState);
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                Board.GetLiberties(enemyNeighbour, Player.OtherPlayer, out var emptyNeighbouringCell);
                if (emptyNeighbouringCell.Count == 1 && emptyNeighbouringCell.First() == Cell)
                    return true;
            }

            return false;
        }
    }
}