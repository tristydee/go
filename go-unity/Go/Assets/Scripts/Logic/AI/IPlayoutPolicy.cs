namespace Logic.AI
{
    public interface IPlayoutPolicy
    {
        Player PerformPlayout(Node child);
    }
}