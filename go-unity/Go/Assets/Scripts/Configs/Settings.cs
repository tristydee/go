using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Configs/Settings")]
    public class Settings : ScriptableObject
    {
        public Vector2Int BoardSize;
        public float DelayBetweenMoves;
    }
}