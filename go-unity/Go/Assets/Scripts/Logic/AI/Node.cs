using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.AI
{
    //todo: better name
    public class Node
    {
        public Node Parent; // can all have private setters
        public List<Node> Children = new List<Node>();
        public BoardState State;
        public (Vector2Int position, Player player) Move;
        public int Rollouts;
        public Dictionary<Player, int> SuccessfulRollouts;

        public Node(BoardState state)
        {
            State = state;
        }

        public Node(BoardState state, Node parent ,(Vector2Int position, Player player) move)
        {
            State = state;
            Parent = parent;
            Move = move;
        }

        public void AddChild(Node child)
        {
            Children.Add(child);
        }

    }
}