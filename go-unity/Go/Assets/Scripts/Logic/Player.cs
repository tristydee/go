using Logic.AI;
using UnityEngine;
using Zenject;

namespace Logic
{
    public class Player
    {
        public CellOccupationState OccupationState => IsFirstPlayer
            ? CellOccupationState.Player1
            : CellOccupationState.Player2;


        public bool HasPassed { get; private set; }

        private bool IsFirstPlayer => game.Players.IndexOf(this) == 0;

        [Inject] private readonly MoveSelector moveSelector;
        private readonly Game game;

        public Player(Game game)
        {
            this.game = game;
        }


        public void TakeTurn()
        {
            //todo: if opponent has passed and score puts you in the lead, then also pass.

            HasPassed = !moveSelector.TryPlaceStone(game.Board, this, game.OtherPlayer(this));
            game.Board.UpdateState();


            if (HasPassed)
                Debug.Log($"player {game.Players.IndexOf(this)} passed");
        }
    }
}