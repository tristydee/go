using System;

namespace Logic
{
    public class IsValidCellCommand
    {
        private readonly Cell cell;
        private readonly Board board;
        private readonly int playerIndex;

        public IsValidCellCommand(Cell cell, Board board, int playerIndex)
        {
            this.cell = cell;
            this.board = board;
            this.playerIndex = playerIndex;
        }

        public bool Execute(out Stone stone)
        {
            stone = new Stone(playerIndex, cell);
            //violates open close principle. Rules should be list of commands that can be easily added to list.
            var isValid = IsCellEmpty() && !DoesViolateKoRule() && (HasEnoughLiberties() || CapturesStones());
            return isValid;
        }

        private bool IsCellEmpty()
        {
            return cell.Stone == null;
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

        private bool CapturesStones()
        {
            throw new NotImplementedException();
            return false;
        }
    }
}