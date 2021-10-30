using Logic;
using UnityEngine;

namespace Views
{
    public class StoneView : MonoBehaviour
    {

        [SerializeField] private SpriteRenderer spriteRenderer;
        
        public void Hide()
        {
            spriteRenderer.enabled = false;
        }

        public void Show(Player player)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = player.Color;
        }
    }
}