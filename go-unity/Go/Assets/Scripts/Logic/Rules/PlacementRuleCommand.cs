namespace Logic.Rules
{
    public abstract class PlacementRuleCommand
    {
        //needs constructor that takes game state as an argument (ko rule)

        protected readonly Cell Cell;
        protected readonly Board Board;
        protected readonly Player Player;

        protected PlacementRuleCommand(Cell cell, Board board, Player player)
        {
            this.Cell = cell;
            this.Board = board;
            this.Player = player;
        }

        public abstract bool Execute();
    }
}