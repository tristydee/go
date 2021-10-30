namespace Logic.Rules
{
    public class KoPlacementRuleCommand : PlacementRuleCommand
    {
        public KoPlacementRuleCommand(Cell cell, Board board, Player player) : base(cell, board, player)
        {
        }

        public override bool Execute()
        {
            var isFirstTurn = Board.BoardStates.Count == 1;

            if (isFirstTurn) return true;

            var sameStateAsLastPly = Board.CurrentBoardState == Board.BoardStates[Board.BoardStates.Count - 2];

            return sameStateAsLastPly;
        }
    }
}