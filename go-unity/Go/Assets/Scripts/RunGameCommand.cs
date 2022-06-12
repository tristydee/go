using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Configs;
using Logic;
using Zenject;

namespace Common
{
    public class RunGameCommandAsync
    {
        private readonly Game game;
        [Inject] private Settings settings;

        public RunGameCommandAsync(Game game)
        {
            this.game = game;
        }

        public async Task Execute()
        {
            var stopwatch = new Stopwatch();
            while (game.Players.Any(p => !p.HasPassed))
            {
                foreach (var player in game.Players)
                {
                    stopwatch.Restart();
                    player.TakeTurn();
                    UpdateView();
                    await Task.Delay(settings.DelayBetweenMovesInMilliseconds - stopwatch.Elapsed.Milliseconds);
                }
            }
        }

        private void UpdateView()
        {
            foreach (var cell in game.Board.Cells)
            {
                cell.UpdateView();
            }
        }
    }
}