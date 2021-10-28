using System.Threading.Tasks;

namespace Logic.AI
{
    public abstract class MoveSelector
    {
        //todo: keep track of states here. for ko rule and mcts
        public abstract Task<bool> TryPlaceStone(Board board, Player player, Player otherPlayer);

        protected void AddStoneToCell(Stone stone, Cell cell)
        {
            cell.AddStone(stone);
        }
    }
}