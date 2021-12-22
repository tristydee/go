using Configs;
using Random = System.Random;

namespace Logic.AI
{
    public class RandomMoveSelector : MoveSelector
    {
   

        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer, Config config)
        {
            var foundMove =
                new TryGetRandomMoveCommand(Random, board, player, otherPlayer, config).Execute(out var position);

            if (foundMove)
            {
                AddStoneToCell(board, new Stone(player, otherPlayer), board.Cells[position.x, position.y]);
                return true;
            }

            return false;
        }
    }
}