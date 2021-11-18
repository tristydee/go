namespace Logic.Scoring
{
    public abstract class ScoringCommand
    {
        protected Game Game;
        protected Score[] Score;

        public void Init(Game game)
        {
            Game = game;
            Score = new Score[2];
            Score[0] = new Score(Game.Players[0]);
            Score[1] = new Score(Game.Players[1]);
        }

        public abstract Score[] Execute();
    }
}