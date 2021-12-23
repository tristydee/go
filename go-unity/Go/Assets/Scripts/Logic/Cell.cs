using UnityEngine;
using Views;

namespace Logic
{
    public class Cell
    {
        public bool IsOccupied => CellOccupationState.Occupied.HasFlag(CellOccupationState);
        public CellOccupationState CellOccupationState { get; private set; } = CellOccupationState.Empty;

        public Vector2Int Position { get; }

        private CellView cellView;
        private StoneView stoneView;

        public Cell(Vector2Int position, CellView cellViewPrefab, StoneView stoneViewPrefab)
        {
            Position = position;
            InitView(position, cellViewPrefab, stoneViewPrefab);
        }

        public void AddOrRemoveStone(CellOccupationState occupationState)
        {
            CellOccupationState = occupationState;
        }

        public void UpdateView()
        {
            stoneView.UpdateView(CellOccupationState);
        }

        private void InitView(Vector2Int position, CellView cellViewPrefab, StoneView stoneViewPrefab)
        {
            cellView = Object.Instantiate(cellViewPrefab, (Vector2)position, Quaternion.identity);
            stoneView = Object.Instantiate(stoneViewPrefab, cellView.transform);
        }
    }
}