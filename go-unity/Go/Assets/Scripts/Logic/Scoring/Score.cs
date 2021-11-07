namespace Logic.Scoring
{
    public class Score
    {
        public Player Player;
        public int Points;

        public Score(Player player, int points)
        {
            Player = player;
            Points = points;
        }
    }
}