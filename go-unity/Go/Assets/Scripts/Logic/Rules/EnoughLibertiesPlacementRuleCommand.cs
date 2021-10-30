using System;

namespace Logic.Rules
{
    public class EnoughLibertiesPlacementRuleCommand : PlacementRuleCommand
    {
        //either liberties greater 0 or capture stones.
        public EnoughLibertiesPlacementRuleCommand(Cell cell, Board board, Player player) : base(cell, board, player)
        {
        }

        public override bool Execute()
        {
            var cellHasEnoughLiberties = Board.GetLiberties(Cell, Player) > 0;

            if (cellHasEnoughLiberties) return true;

            //todo: see if stones would be captured if stone were to be placed here
            throw new NotImplementedException();
        }
    }
}