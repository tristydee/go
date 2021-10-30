namespace Logic.Rules
{
    public class KoRuleCommand : RuleCommand
    {
        public KoRuleCommand(Cell cell, Board board) : base(cell, board)
        {
        }

        public override bool Execute()
        {
            var isFirstTurn = board.BoardStates.Count == 1;

            if (isFirstTurn) return true;

            var sameStateAsLastPly = board.CurrentBoardState == board.BoardStates[board.BoardStates.Count - 2];

            return sameStateAsLastPly;
        }
    }
}