namespace Logic
{
    public class Stone
    {
        public readonly Player Player;
        public readonly Player OtherPlayer;
        
        public Stone(Player player, Player otherPlayer)
        {
            Player = player;
            OtherPlayer = otherPlayer;
        }

    }
}