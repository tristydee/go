using System;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using UnityEngine;
using Configs;

public class Main : MonoBehaviour
{
    [SerializeField] private Config Config;
    
    void Start()
    {
        var game = new GenerateBoardCommand(Config).Execute();
        
        RunGame(game.Players);
    }

    private async void RunGame(Player[] players)
    {
        while (players.All(p => !p.HasPassed))
        {
            foreach (var player in players)
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
        //update stones + score view
        throw new NotImplementedException();
    }

    private void EndGame()
    {
        //show which player won
        throw new NotImplementedException();
    }
}
