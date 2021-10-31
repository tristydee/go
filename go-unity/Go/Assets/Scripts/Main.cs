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
        game = new GenerateBoardCommand(Config).Execute();
        RunGame();
    }

    private async void RunGame()
    {
        while (game.Players.All(p => !p.HasPassed))
        {
            foreach (var player in game.Players)
            {
                await player.TakeTurn();
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
        //show which player won
        throw new NotImplementedException();
    }
}