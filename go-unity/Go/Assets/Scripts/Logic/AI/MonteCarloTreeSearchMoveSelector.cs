using System.Threading.Tasks;

namespace Logic.AI
{
    public class MonteCarloTreeSearchMoveSelector : MoveSelector
    {
        public override async Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer)
        {
            return false;
        }
    }
}