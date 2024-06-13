using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGridView : MonoBehaviour
    {
        [SerializeField] private List<InventorySlotView> _slots = new List<InventorySlotView>();

        public void InitializeInventoryGridView(IReadOnlyInventoryGrid readOnlyInventoryGrid)
        {
        }

        public void AddInventorySlotView(IReadOnlySlot slot)
        {

        }

        public void RemoveInventorySlotView(IReadOnlySlot slot)
        {

        }
        
    }
}
