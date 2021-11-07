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
            var cellHasEnoughLiberties = Board.GetLiberties(Cell, Player) > 0;

            if (cellHasEnoughLiberties) return true;

            var enemyNeighbours = Board.GetNeighbouringCells(Cell, Player.OtherPlayer.OccupationState);
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                var neighbours = Board.GetNeighbouringCells(enemyNeighbour, CellOccupationState.Empty);
                if (neighbours.Count == 1 && neighbours[0] == Cell)
                    return true;
            }

            return false;
        }
    }
}