using System;
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

        private List<RuleCommand> rules;
        //needs a list of rule types to create instances of.

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

            rules.Add(new CellIsEmptyRuleCommand(cell,board.BoardState));
            rules.Add(new KoRuleCommand(cell,board.BoardState));
            rules.Add(new EnoughLibertiesRuleCommand(cell,board.BoardState));
            
             var isValid = rules.All(r => r.Execute());
            stonesToRemove = null; //todo: do this in a separate command. or in here.    
            return isValid;
        }
    }
}