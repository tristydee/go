namespace Logic.AI
{
    public interface ISelectionPolicy
    {
        Node SelectChild(Node baseNode);
        Node SelectMove(Node baseNode);
    }
}