using UnityEngine;
using Views;

namespace Logic
{
    public class Cell
    {
        public Stone Stone;
        public Vector2Int Position;

        private CellView view;

        public Cell(Vector2Int position, CellView view)
        {
            //todo: init view
            throw new System.NotImplementedException();
        }
    }
}