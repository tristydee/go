namespace Logic
{
    public class Stone
    {
        public int Liberties { get; }
        public  Player Player { get; private set; }

        public readonly Cell Cell;
        
        private readonly Player otherPlayer;
        private readonly Player player;

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