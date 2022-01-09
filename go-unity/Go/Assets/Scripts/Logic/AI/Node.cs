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

        public Node(Node parent ,(Vector2Int position, Player player) move)
        {
            Parent = parent;
            Move = move;
            State = parent.State; //todo: create new state using parents state + move.
            State.CellStates[move.position.x, move.position.y] =
                move.player.OccupationState; // not good enough! need to actually place the stone to capture enemies!
        }

        public void AddChild(Node child)
        {
            Children.Add(child);
        }

        public float GetWinPercentage(Player player)
        {
            return (float)SuccessfulRollouts[player] / Rollouts;
        }
    }
}