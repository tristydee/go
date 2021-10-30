namespace Logic.Rules
{
    public class CellIsEmptyRuleCommand : RuleCommand
    {
        public CellIsEmptyRuleCommand(Cell cell, BoardState stateAtLastPly) : base(cell, stateAtLastPly)
        {
        }

        public override bool Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}