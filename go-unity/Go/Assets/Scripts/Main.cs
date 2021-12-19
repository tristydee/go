using System;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using UnityEngine;
using Configs;

public class Main : MonoBehaviour
{
    [SerializeField] private Config Config;

    private Game game;

    void Start()
    {
        Config.CreateInstances();
        game = new GenerateBoardCommand(Config).Execute();
        Config.Init(game);
        RunGame();
    }

    private async void RunGame()
    {
        while (game.Players.Any(p => !p.HasPassed))
        {
            foreach (var player in game.Players)
            {
                player.TakeTurn();
                UpdateView();
                await Task.Delay(TimeSpan.FromSeconds(Config.Settings.DelayBetweenMoves));
            }
        }

        EndGame();
    }

    private void UpdateView()
    {
        foreach (var cell in game.Board.Cells)
        {
            cell.UpdateView();
        }
    }

    private void EndGame()
    {
        var score = Config.ScoringCommand.Execute();
        Debug.Log($"Player 0 has {score[0].Points} points");
        Debug.Log($"Player 1 has {score[1].Points} points");
    }
}