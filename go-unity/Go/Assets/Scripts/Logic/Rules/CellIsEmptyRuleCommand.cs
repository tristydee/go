namespace Logic.Rules
{
    public class CellIsEmptyRuleCommand : RuleCommand
    {
        public CellIsEmptyRuleCommand(Cell cell, Board board) : base(cell, board)
        {
        }

        public override bool Execute()
        {
            return !cell.IsOccupied;
        }
    }
}