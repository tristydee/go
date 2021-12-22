using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using UnityEngine;
using Configs;
using Debug = UnityEngine.Debug;

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
        var stopwatch = new Stopwatch();
        while (game.Players.Any(p => !p.HasPassed))
        {
            foreach (var player in game.Players)
            {
                stopwatch.Restart();
                player.TakeTurn();
                UpdateView();
                await Task.Delay(Config.Settings.DelayBetweenMovesInMilliseconds - stopwatch.Elapsed.Milliseconds);
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