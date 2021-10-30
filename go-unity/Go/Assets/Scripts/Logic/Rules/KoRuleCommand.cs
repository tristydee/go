namespace Logic.Rules
{
    public class KoRuleCommand : RuleCommand
    {
        public KoRuleCommand(Cell cell, BoardState stateAtLastPly) : base(cell, stateAtLastPly)
        {
        }

        public override bool Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}