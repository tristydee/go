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

        private List<PlacementRuleCommand> placementRuleCommands = new List<PlacementRuleCommand>();

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

             var isValid = placementRuleCommands.All(r => r.Execute(cell,board, player));
            return isValid;
        }
    }
}