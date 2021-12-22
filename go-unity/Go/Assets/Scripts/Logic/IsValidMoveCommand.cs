using System.Collections.Generic;
using System.Linq;
using Logic.Rules;
using UnityEngine;

namespace Logic
{
    public class IsValidCellCommand
    {
        private readonly Cell cell;
        private readonly Board board;
        private readonly Player player;
        private readonly Player otherPlayer;
        private readonly List<PlacementRuleCommand> placementRuleCommands;

        public IsValidCellCommand(Cell cell, Board board, Player player, Player otherPlayer,
            List<PlacementRuleCommand> placementRuleCommands)
        {
            this.cell = cell;
            this.board = board;
            this.player = player;
            this.otherPlayer = otherPlayer;
            this.placementRuleCommands = placementRuleCommands;
        }

        public bool Execute()
        {
            var isValid = placementRuleCommands.All(r => r.Execute(cell, board, player, otherPlayer));
            return isValid;
        }
    }
}