namespace Logic.Rules
{
    public abstract class RuleCommand
    {
        
        //needs constructor that takes game state as an argument (ko rule)

        protected readonly Cell cell;
        protected readonly Board board;

        protected RuleCommand(Cell cell, Board board)
        {
            this.cell = cell;
            this.board = board;
        }

        public abstract bool Execute();
    }
}