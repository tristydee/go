using System;

namespace Logic.AI
{
    public interface ISelectionPolicy
    {
        Node SelectChild(Node baseNode, Random random);
        Node SelectMove(Node baseNode, Player player);
    }
}