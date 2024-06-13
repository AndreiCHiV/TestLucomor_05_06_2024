using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenInventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryGridView _inventoryGridView;

        public InventoryGridView InventoryGridView
        {
            get => _inventoryGridView;
        }
    }
}
