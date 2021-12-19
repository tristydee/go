using System.Collections.Generic;
using System.Threading.Tasks;
using Configs;
using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Player
    {
        public CellOccupationState OccupationState => IsFirstPlayer
            ? CellOccupationState.Player1
            : CellOccupationState.Player2;

        public Color Color => IsFirstPlayer ? Color.black : Color.white;
        
        public bool HasPassed { get; private set; }

        private bool IsFirstPlayer => game.Players.IndexOf(this) == 0;

        private readonly MoveSelector moveSelector;
        private readonly Config config;
        private readonly Game game;

        public Player(Game game, MoveSelector moveSelector, Config config)
        {
            this.moveSelector = moveSelector;
            this.config = config;
            this.game = game;
        }


        public void TakeTurn()
        {
            HasPassed = ! moveSelector.TryPlaceStone(game.Board, this,game.OtherPlayer(this),config);
            game.Board.UpdateState();
            
            if(HasPassed)
                Debug.Log($"player {game.Players.IndexOf(this)} passed");
        }
    }
}