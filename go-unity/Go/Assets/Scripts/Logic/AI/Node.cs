using System.Collections.Generic;
using UnityEngine;

namespace Logic.AI
{
    //todo: better name
    public class Node
    {
        public Node Parent;
        public List<Node> Child;
        public BoardState State;
        public (Vector2Int position, Player player) Move;
        public Result Result;
    }
}