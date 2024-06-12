using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    [Serializable]
    public class InventoryGridData
    {
        public string owner;
        public float maxWeigthInventory;
        public List<InventorySlotData> slots;
    }
}
