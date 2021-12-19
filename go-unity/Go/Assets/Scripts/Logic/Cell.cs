using UnityEngine;
using Views;

namespace Logic
{
    public class Cell
    {
        public bool IsOccupied => Stone != null;
        public CellOccupationState CellOccupationState => !IsOccupied ? CellOccupationState.Empty : Stone.Player.OccupationState;

        //bug happens when stone is not null.
        public Stone Stone { get; private set; }
        public Vector2Int Position { get; private set; }

        private CellView cellView;
        private StoneView stoneView;
        
        public Cell(Vector2Int position, CellView cellViewPrefab, StoneView stoneViewPrefab)
        {
            Position = position;
            InitView(position, cellViewPrefab, stoneViewPrefab);
        }

        public void AddStone(Stone stone)
        {
            Stone = stone;
        }

        public void RemoveStone()
        {
            Stone = null;
        }

        public void UpdateView()
        {
            if (!IsOccupied)
                stoneView.Hide();
            else
                stoneView.Show(Stone.Player);
        }

        private void InitView(Vector2Int position, CellView cellViewPrefab, StoneView stoneViewPrefab)
        {
            cellView = Object.Instantiate(cellViewPrefab,(Vector2)position,Quaternion.identity);
            stoneView = Object.Instantiate(stoneViewPrefab, cellView.transform);
            stoneView.Hide();
        }
    }
}