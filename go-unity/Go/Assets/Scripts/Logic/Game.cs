using System.Linq;
using Configs;
using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Game
    {
        public Board Board;
        public readonly Player[] Players;

        public Game(Vector2Int boardSize, MoveSelector moveSelector, Assets assets)
        {
            Board = new Board(boardSize, assets);

            Players = new Player[2];
            for (var i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player(this, moveSelector);
            }

            foreach (var player in Players)
            {
                player.SetOpponent(Players.First(p => p != player));
            }
        }
    }
}