namespace Logic.AI
{
    public interface IMoveSelector
    
        //interface should be abstract class so it can handle things like checking for valid moves?
        // or use a command isValidMoveCommand
    {
        Stone TryPlaceStone(Board board, int playerIndex);
    }
}