namespace Logic
{
    public class Stone
    {
        public  Player Player { get; private set; }
        public readonly Player OtherPlayer;
        public readonly Cell Cell;
        
        private readonly Player player;

        public Stone(Player player, Player otherPlayer, Cell cell)
        {
            this.player = player;
            this.OtherPlayer = otherPlayer;
            Cell = cell;
        }

        public void Capture()
        {
            OtherPlayer.CapturedStones.Add(this);
        }
        
    }
}