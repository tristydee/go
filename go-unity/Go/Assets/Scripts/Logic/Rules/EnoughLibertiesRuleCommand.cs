namespace Logic.Rules
{
    public class EnoughLibertiesRuleCommand : RuleCommand
    {
        //either liberties greater 0 or capture stones.
        //needs to return a list of stones that are captures... how to generically add out parameters to base class?
        public EnoughLibertiesRuleCommand(Cell cell, Board board) : base(cell, board)
        {
        }

        public override bool Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}