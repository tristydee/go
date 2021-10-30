namespace Logic.Rules
{
    public abstract class RuleCommand
    {
        
        //needs constructor that takes game state as an argument (ko rule)

        private readonly Cell cell;
        private readonly BoardState stateAtLastPly;

        protected RuleCommand(Cell cell, BoardState stateAtLastPly)
        {
            this.cell = cell;
            this.stateAtLastPly = stateAtLastPly;
        }

        public abstract bool Execute();
    }
}