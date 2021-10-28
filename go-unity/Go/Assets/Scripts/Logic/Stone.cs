namespace Logic
{
    public class Stone
    {
        public int Liberties { get; }
        
        public readonly Cell Cell;
        
        private readonly Player player;
        private readonly Player otherPlayer;

        public Stone(Player player, Player otherPlayer, Cell cell)
        {
            this.player = player;
            this.otherPlayer = otherPlayer;
            Cell = cell;
        }

        public void Capture()
        {
            otherPlayer.CapturedStones.Add(this);
        }
    }
}