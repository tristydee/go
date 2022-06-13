using System.Collections.Generic;
using System.Linq;
using Logic.Rules;
using Zenject;

namespace Logic
{
    public class IsValidCellCommand
    {
        private readonly Cell cell;
        private readonly Board board;
        private readonly Player player;
        [Inject] private readonly List<PlacementRuleCommand> placementRuleCommands;

        public IsValidCellCommand(Cell cell, Board board, Player player)
        {
            this.cell = cell;
            this.board = board;
            this.player = player;
        }

        public bool Execute()
        {
            var isValid = placementRuleCommands.All(r => r.Execute(cell, board, player));
            return isValid;
        }
    }
}