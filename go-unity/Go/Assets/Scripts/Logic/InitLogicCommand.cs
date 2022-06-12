using Logic;
using Logic.AI;
using Logic.Scoring;
using Zenject;

namespace Common
{
    public class InitLogicCommand
    {
        private readonly Game game;
        [Inject] private ScoringCommand scoringCommand;
        [Inject] private MoveSelector moveSelector;

        public InitLogicCommand(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            scoringCommand.Init(game);
            moveSelector.Init(game);
        }
    }
}