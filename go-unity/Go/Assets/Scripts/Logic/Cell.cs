using UnityEngine;
using Views;

namespace Logic
{
    public class Cell
    {
        public bool IsOccupied => stone != null;
        public CellOccupationState CellOccupationState => !IsOccupied ? CellOccupationState.Empty : stone.Player.OccupationState;

        private Stone stone;
        public Vector2Int Position;

        private CellView cellView;
        private StoneView stoneView;
        
        public Cell(Vector2Int position, CellView cellViewPrefab, StoneView stoneViewPrefab)
        {
            Position = position;
            InitView(position, cellViewPrefab, stoneViewPrefab);
        }

        public void AddStone(Stone stone)
        {
            this.stone = stone;
        }

        public void RemoveStone()
        {
            stone.Capture();
            stone = null;
        }

        public void UpdateView()
        {
            if (!IsOccupied)
                stoneView.Hide();
            else
                stoneView.Show(stone.Player);
        }

        private void InitView(Vector2Int position, CellView cellViewPrefab, StoneView stoneViewPrefab)
        {
            cellView = Object.Instantiate(cellViewPrefab,(Vector2)position,Quaternion.identity);
            stoneView = Object.Instantiate(stoneViewPrefab, cellView.transform);
            stoneView.Hide();
        }
    }
}