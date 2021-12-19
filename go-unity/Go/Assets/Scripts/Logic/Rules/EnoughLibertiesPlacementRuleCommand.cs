namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell, Board board, Player player, Player otherPlayer)
        {
            // seeing how many liberties would shape have if we were to place stone here
            cell.AddStone(new Stone(player,otherPlayer));
            var cellHasEnoughLiberties = board.GetLiberties(cell, player) > 0;
            cell.RemoveStone();
            if (cellHasEnoughLiberties)
            {
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