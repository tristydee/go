using Configs;
using Logic.AI;

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
            var game = new Game(config.Settings.BoardSize, typeof(RandomMoveSelector));
            return game;
        }
    }
}