using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Player
    {
        public CellOccupationState OccupationState => otherPlayer.OccupationState == CellOccupationState.Player1
            ? CellOccupationState.Player2
            : CellOccupationState.Player1;

        public Color Color => OccupationState == CellOccupationState.Player1 ? Color.black : Color.white;
        public bool HasPassed;
        public List<Stone> CapturedStones = new List<Stone>();

        private readonly MoveSelector moveSelector;
        private readonly Board board;
        private readonly Player otherPlayer;

        public Player(Game game, MoveSelector moveSelector)
        {
            this.moveSelector = moveSelector;
            board = game.Board;
            otherPlayer = game.Players.First(p => p != this);
        }


        public async Task TakeTurn()
        {
            HasPassed = !await moveSelector.TryPlaceStone(board, this, otherPlayer);
        }
    }
}