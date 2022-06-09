using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Game
    {
        public readonly Board Board;
        public readonly List<Player> Players;

        public Game()
        {
            Board = new Board().Init();
            Players = new List<Player>();
            for (var i = 0; i < 2; i++)
            {
                Players.Add(new Player(this));
            }

        }

        public Player OtherPlayer(Player player)
        {
            return Players.First(p => p != player);
        }
    }
}