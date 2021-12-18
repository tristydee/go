using System.Collections.Generic;
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
        public readonly List<Stone> CapturedStones = new List<Stone>();
        public bool HasPassed { get; private set; }
        public Player OtherPlayer { get; private set; }

        private readonly MoveSelector moveSelector;
        private readonly Config config;
        private readonly Board board;

        public Player(Game game, MoveSelector moveSelector, Config config)
        {
            this.moveSelector = moveSelector;
            this.config = config;
            board = game.Board;
        }

        public void SetOpponent(Player otherPlayer)
        {
            OtherPlayer = otherPlayer;
        }


        public async Task TakeTurn()
        {
            HasPassed = !await moveSelector.TryPlaceStone(board, this, OtherPlayer,config);
            board.UpdateState();
            HasPassed = ! moveSelector.TryPlaceStone(board, this, OtherPlayer,config);
        }
    }
}