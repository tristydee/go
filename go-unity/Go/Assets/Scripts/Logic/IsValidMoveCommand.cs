using System.Collections.Generic;
using System.Linq;
using Configs;
using Logic.Rules;

namespace Logic
{
    public class IsValidCellCommand
    {
        private readonly Cell cell;
        private readonly Board board;
        private readonly Player player;
        private readonly Player otherPlayer;
        private readonly List<PlacementRuleCommand> placementRuleCommands;
        //todo: drag and drop RuleCommands in config (or type the Type in a public string) to get a list instead of having to touch code.

        public IsValidCellCommand(Cell cell, Board board, Player player, Player otherPlayer, List<PlacementRuleCommand> placementRuleCommands)
        {
            this.cell = cell;
            this.board = board;
            this.player = player;
            this.otherPlayer = otherPlayer;
            this.placementRuleCommands = placementRuleCommands;
        }

        public bool Execute(out Stone stoneToPlace)
        {
            stoneToPlace = new Stone(player, otherPlayer, cell);

            // rules.Add(new CellIsEmptyPlacementRuleCommand(cell,board, player));
            // rules.Add(new KoPlacementRuleCommand(cell,board, player));
            // rules.Add(new EnoughLibertiesPlacementRuleCommand(cell,board, player));
            
             var isValid = placementRuleCommands.All(r => r.Execute());
            return isValid;
        }
    }
}