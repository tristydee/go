namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell, Board board, Player player)
        {
            var cellHasEnoughLiberties = board.GetLiberties(cell, player) > 0;

            if (cellHasEnoughLiberties) return true;

            var enemyNeighbours = board.GetNeighbouringCells(cell, player.OtherPlayer.OccupationState);
            foreach (var enemyNeighbour in enemyNeighbours)
            {
                var neighbours = board.GetNeighbouringCells(enemyNeighbour, CellOccupationState.Empty);
                if (neighbours.Count == 1 && neighbours[0] == cell)
                    return true;
            }

            return false;
        }
    }
}