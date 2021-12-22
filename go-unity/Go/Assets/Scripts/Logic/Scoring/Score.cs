namespace Logic.Scoring
{
    public class Score
    {
        public Player Player;
        public float Points;

        public Score(Player player)
        {
            Player = player;
        }

        public void AddKomi()
        {
            Points += 5.5f;
        }
    }
}