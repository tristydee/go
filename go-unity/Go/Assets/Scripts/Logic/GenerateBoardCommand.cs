using System;
using Configs;
using Logic.AI;
using UnityEngine;

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
            var game = new Game(config.Settings.BoardSize,(MoveSelector)Activator.CreateInstance(config.Settings.MoveSelector), config);
            PositionCamera();
            return game;
        }

        private void PositionCamera()
        {
            var cam = Camera.main;
            var boardSize = config.Settings.BoardSize;
            cam.transform.position = new Vector3(boardSize.x / 2f -.5f, boardSize.y / 2f -.5f, -10);
        }
    }
}