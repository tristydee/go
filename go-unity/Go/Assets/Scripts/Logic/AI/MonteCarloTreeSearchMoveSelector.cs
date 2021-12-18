using System.Threading.Tasks;
using Configs;

namespace Logic.AI
{
    public class MonteCarloTreeSearchMoveSelector : MoveSelector
    {
        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer, Config config)
        {
            return false;
        }
    }
}