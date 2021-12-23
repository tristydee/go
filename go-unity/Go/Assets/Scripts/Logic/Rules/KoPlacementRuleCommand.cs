using UnityEngine;

namespace Logic.Rules
{
    public class KoPlacementRuleCommand : PlacementRuleCommand
    {
        public override bool Execute(Cell cell,Board board, Player player, Player otherPlayer)
        {
            var isFirstTurn = board.BoardStates.Count == 1;

            if (isFirstTurn) return true;

            var sameStateAsLastPly = board.CurrentBoardState == board.BoardStates[board.BoardStates.Count - 2];

            //Ko rule seems broken!
            if(sameStateAsLastPly) Debug.LogError($"ko rule!{cell.Position.x}/{cell.Position.y}");
            
            return !sameStateAsLastPly;
        }
    }
}