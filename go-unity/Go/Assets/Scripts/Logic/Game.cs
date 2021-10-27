using System;
using Logic.AI;
using UnityEngine;

namespace Logic
{
    public class Game
    {
        public Board Board;
        public Player[] Players;

        public Game(Vector2Int boardSize, Type type) //todo: constrict type to be IMoveSelector?
        {
            var board = new Board(boardSize);
            
            Players = new Player[2];
            for (var i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player(board,i,(IMoveSelector)Activator.CreateInstance(type));
            }

            throw new NotImplementedException();
        }
    }
}