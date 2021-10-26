
using Configs;

namespace Logic
{
    
    public class GenerateBoardCommand
    {
        private Config config;

        public GenerateBoardCommand(Config config)
        {
            this.config = config;
        }

        public Game Execute()
        {
            return new Game();
        }
    }
}