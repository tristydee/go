using System.Collections.Generic;
using System.Linq;
using Common;
using Zenject;

namespace Logic
{
    public class Game
    {
        public Board Board;
        public List<Player> Players;
        [Inject] private DiContainer container;

        public Game Init()
        {
            
            Board = new Board().Inject(container).Init();
            Players = new List<Player>();
            for (var i = 0; i < 2; i++)
            {
                Players.Add(new Player(this));
            }

            return this;
        }

        public Player OtherPlayer(Player player)
        {
            return Players.First(p => p != player);
        }
    }
}