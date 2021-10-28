using System;
using System.Collections.Generic;

namespace Logic
{
    public class IsValidCellCommand
    {
        private readonly Cell cell;
        private readonly Board board;
        private readonly Player player;
        private readonly Player otherPlayer;

        public IsValidCellCommand(Cell cell, Board board, Player player, Player otherPlayer)
        {
            this.cell = cell;
            this.board = board;
            this.player = player;
            this.otherPlayer = otherPlayer;
        }

        public bool Execute(out Stone stoneToPlace, out List<Stone> stonesToRemove)
        {
            stoneToPlace = new Stone(player, otherPlayer, cell);
            stonesToRemove = null;
            //violates open close principle. Rules should be list of commands that can be easily added to list.
            var isValid = IsCellEmpty() && !DoesViolateKoRule() && (HasEnoughLiberties() || CapturesStones(out stonesToRemove));
            return isValid;
        }

        private bool IsCellEmpty()
        {
            return !cell.IsOccupied;
        }

        private bool DoesViolateKoRule()
        {
            // need to see if previous state is equal to this state... reason enough for this not be a command but be in abstract moveSelector class.
            throw new NotImplementedException();
            return false;
        }

        private bool HasEnoughLiberties()
        {
            throw new NotImplementedException();
            return true;
        }

        private bool CapturesStones(out List<Stone> stonesToRemove)
        {
            throw new NotImplementedException();
            return false;
        }
    }
}