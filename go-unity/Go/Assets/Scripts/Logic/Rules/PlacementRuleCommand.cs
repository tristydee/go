namespace Logic.Rules
{
    public abstract class PlacementRuleCommand
    {
        public abstract bool Execute(Cell cell,Board board, Player player, Player otherPlayer);
    }
}