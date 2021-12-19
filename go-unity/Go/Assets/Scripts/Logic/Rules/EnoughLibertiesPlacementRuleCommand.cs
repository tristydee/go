namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell, Board board, Player player, Player otherPlayer)
        {
            var cellHasEnoughLiberties = board.GetLiberties(cell, player) > 0;

            if (cellHasEnoughLiberties) return true;

            var enemyNeighbours = board.GetNeighbouringCells(cell, otherPlayer.OccupationState);
            var targetIsLastEnemyLiberty = true;
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                var neighbours = board.GetNeighbouringCells(enemyNeighbour, CellOccupationState.Empty);
                targetIsLastEnemyLiberty &= neighbours.Count == 1 && neighbours[0] == cell;
            }

            return targetIsLastEnemyLiberty;
        }
    }
}