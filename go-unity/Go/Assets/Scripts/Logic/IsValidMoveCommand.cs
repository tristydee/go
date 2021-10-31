using System.Collections.Generic;
using System.Linq;
using Logic.Rules;

namespace Logic
{
    public class IsValidCellCommand
    {
        private readonly Cell cell;
        private readonly Board board;
        private readonly Player player;
        private readonly Player otherPlayer;

        private List<PlacementRuleCommand> rules;
        //drag and drop RuleCommands in config to get a list instead of having to touch code.

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

            rules.Add(new CellIsEmptyPlacementRuleCommand(cell,board, player));
            rules.Add(new KoPlacementRuleCommand(cell,board, player));
            rules.Add(new EnoughLibertiesPlacementRuleCommand(cell,board, player));
            
             var isValid = rules.All(r => r.Execute());
            stonesToRemove = null; //todo: do this in a separate command. RemoveCapturedStonesCommand
            //or the rule command adds the stones to capture to the board class, which
            return isValid;
        }
    }
}