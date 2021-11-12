namespace Logic.Rules
{
    public class KoPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell,Board board, Player player)
        {
            var isFirstTurn = board.BoardStates.Count == 1;

            if (isFirstTurn) return true;

            var sameStateAsLastPly = board.CurrentBoardState == board.BoardStates[board.BoardStates.Count - 2];

            return sameStateAsLastPly;
        }
    }
}