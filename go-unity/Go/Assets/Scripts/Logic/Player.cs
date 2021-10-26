using System.Threading.Tasks;

namespace Logic
{
    public class Player
    {
        public int Index;
        public bool HasPassed;

        public async Task TakeTurn()
        {
            HasPassed = false;
        }
    }
}