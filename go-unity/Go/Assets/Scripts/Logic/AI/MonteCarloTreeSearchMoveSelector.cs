using System.Threading.Tasks;
using Configs;

namespace Logic.AI
{
    public class MonteCarloTreeSearchMoveSelector : MoveSelector
    {
        public override async Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer, Config config)
        {
            return false;
        }
    }
}