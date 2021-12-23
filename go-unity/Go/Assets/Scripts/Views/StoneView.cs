using Logic;
using UnityEngine;

namespace Views
{
    public class StoneView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void UpdateView(CellOccupationState occupationState)
        {
            spriteRenderer.color = occupationState.Color();
        }
    }
}