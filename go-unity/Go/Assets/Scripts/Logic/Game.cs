using System.Collections.Generic;
using System.Linq;
using Configs;
using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Game
    {
        public readonly Board Board;
        public readonly List<Player> Players;

        public Game(Vector2Int boardSize, MoveSelector moveSelector, Config config)
        {
            Board = new Board(boardSize, config.Assets);

            Players = new List<Player>();
            for (var i = 0; i < 2; i++)
            {
                Players.Add(new Player(this, moveSelector, config));
            }

        }

        public Player OtherPlayer(Player player)
        {
            return Players.First(p => p != player);
        }
    }
}