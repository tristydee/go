using System;
using Configs;
using Logic.AI;

namespace Logic
{
    
    public class GenerateBoardCommand
    {
        private readonly Config config;

        public GenerateBoardCommand(Config config)
        {
            this.config = config;
        }

        public Game Execute()
        {
            //todo: which move selector to use should be serialized in settings.
            var game = new Game(config.Settings.BoardSize,(MoveSelector)Activator.CreateInstance(typeof(RandomMoveSelector)), config.Assets); 
            return game;
        }
    }
}