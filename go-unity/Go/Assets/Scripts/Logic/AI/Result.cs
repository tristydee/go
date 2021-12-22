namespace Logic.AI
{
    //todo: better name
    public class Result
    {
        public int Player1Wins;
        public int Rollouts;
        public int Player2Wins => Rollouts - Player1Wins;
    }
}