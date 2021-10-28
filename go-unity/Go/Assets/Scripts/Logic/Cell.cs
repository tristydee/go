using UnityEngine;
using Views;

namespace Logic
{
    public class Cell
    {
        public bool IsOccupied => stone != null;

        private Stone stone;
        public Vector2Int Position;

        private CellView view;
        

        public Cell(Vector2Int position, CellView view)
        {
            //todo: init view
            throw new System.NotImplementedException();
        }

        public void AddStone(Stone stone)
        {
            this.stone = stone;
            //this should start a 
        }

        public void RemoveStone()
        {
            stone.Capture();
            stone = null;
        }

        public void UpdateView()
        {
            //update score...
        }
    }
}