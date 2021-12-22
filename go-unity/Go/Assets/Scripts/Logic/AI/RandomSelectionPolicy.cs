using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.AI
{
    public class RandomSelectionPolicy : ISelectionPolicy
    {
        private List<Node> nodes = new List<Node>();

        //selection. chose a random move starting at current state. then continue with random moves until we reach leaf of tree.
        public Node SelectChild(Node baseNode, Random random)
        {
            //get list of all nodes. then take one of those at random.
            nodes.Clear();
            nodes.Add(baseNode);
            AddChildren(baseNode);

            return nodes[random.Next(nodes.Count)];

            void AddChildren(Node node)
            {
                foreach (var child in node.Children)
                {
                    nodes.Add(child);
                    AddChildren(child);
                }
            }
        }

        public Node SelectMove(Node baseNode, Player player)
        {
            return baseNode.Children.Aggregate(
                (a, b) => a.GetWinPercentage(player) > b.GetWinPercentage(player) ? a : b);
        }
    }
}