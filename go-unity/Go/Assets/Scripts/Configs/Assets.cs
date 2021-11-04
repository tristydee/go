using UnityEngine;
using Views;

namespace Configs
{
    [CreateAssetMenu(fileName = "Assets", menuName = "ScriptableObjects/Configs/Assets")]
    public class Assets : ScriptableObject
    {
        public CellView CellPrefab;
        public StoneView StonePrefab;
    }
}