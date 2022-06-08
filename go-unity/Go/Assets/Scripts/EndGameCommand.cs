using Logic.Scoring;
using UnityEngine;
using Zenject;

namespace Common
{
    public class EndGameCommand
    {
        [Inject] private ScoringCommand scoringCommand;

        public void Execute()
        {
            var score = scoringCommand.Execute();
            Debug.Log($"Player 0 has {score[0].Points} points");
            Debug.Log($"Player 1 has {score[1].Points} points");
        }
    }
}