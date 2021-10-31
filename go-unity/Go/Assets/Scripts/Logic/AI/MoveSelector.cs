using System.Threading.Tasks;

namespace Logic.AI
{
    public abstract class MoveSelector
    {
        public abstract Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer);

        protected void AddStoneToCell(Stone stone, Cell cell)
        {
            cell.AddStone(stone);
            //for each enemy stone adjacent to this stone, if liberties == 0. capture (need to capture whole shape)
        }
    }
}