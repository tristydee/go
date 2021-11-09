using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configs;
using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Player
    {
        public CellOccupationState OccupationState => OtherPlayer.OccupationState == CellOccupationState.Player1
            ? CellOccupationState.Player2
            : CellOccupationState.Player1;

        public Color Color => OccupationState == CellOccupationState.Player1 ? Color.black : Color.white;
        public bool HasPassed;
        public List<Stone> CapturedStones = new List<Stone>();
        public Player OtherPlayer;

        private readonly MoveSelector moveSelector;
        private readonly Settings settings;
        private readonly Board board;

        public Player(Game game, MoveSelector moveSelector, Settings settings)
        {
            this.moveSelector = moveSelector;
            this.settings = settings;
            board = game.Board;
        }

        public void SetOpponent(Player otherPlayer)
        {
            OtherPlayer = otherPlayer;
        }


        public async Task TakeTurn()
        {
            HasPassed = !await moveSelector.TryPlaceStone(board, this, OtherPlayer,settings);
            board.UpdateState();
        }
    }
}