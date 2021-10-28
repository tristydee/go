using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Game
    {
        public Board Board;
        public readonly Player[] Players;

        public Game(Vector2Int boardSize, MoveSelector moveSelector)
        {
            Board = new Board(boardSize);

            Players = new Player[2];
            for (var i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player( this, moveSelector);
            }
        }
    }
}