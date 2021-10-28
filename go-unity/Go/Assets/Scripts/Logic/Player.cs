using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.AI;

namespace Logic
{
    public class Player
    {
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