namespace Logic.Rules
{
    public class CellIsEmptyPlacementRuleCommand : PlacementRuleCommand
    {
        public CellIsEmptyPlacementRuleCommand(Cell cell, Board board, Player player) : base(cell, board, player)
        {
        }

        public override bool Execute()
        {
            return !Cell.IsOccupied;
        }
    }
}