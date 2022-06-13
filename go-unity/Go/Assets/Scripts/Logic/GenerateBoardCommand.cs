using Common;
using Configs;
using UnityEngine;
using Zenject;

namespace Logic
{
    
    public class GenerateBoardCommand
    {
        [Inject] private Settings settings;
        [Inject] private DiContainer container;
        public Game Execute()
        {
            var game = new Game().Inject(container).Init();
            PositionCamera();
            return game;
        }

        private void PositionCamera()
        {
            var cam = Camera.main;
            var boardSize = settings.BoardSize;
            cam.transform.position = new Vector3(boardSize.x / 2f -.5f, boardSize.y / 2f -.5f, -10);
        }
    }
}