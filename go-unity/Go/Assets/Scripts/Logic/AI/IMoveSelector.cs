using System.Threading.Tasks;

namespace Logic.AI
{
    public interface IMoveSelector
    
        //interface should be abstract class so it can handle things like checking for valid moves?
        // or use a command isValidMoveCommand
    {
        Task<Stone> TryPlaceStone(Board board, int playerIndex);
    }
}