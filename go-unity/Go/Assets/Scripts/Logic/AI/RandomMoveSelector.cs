namespace Logic.AI
{
    public class RandomMoveSelector : MoveSelector
    {
        public override bool TryPlaceStone(Board board, Player player, Player otherPlayer)
        {
            var foundMove =
                new TryGetRandomMoveCommand(Random, board, player).Execute(out var position);

            if (!foundMove) return false;
            AddStoneToCell(board, player.OccupationState, board.Cells[position.x, position.y]);
            return true;
        }
    }
}