using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    [Serializable]
    public class InventoryGridData
    {
        public string owner;
        public List<InventorySlotData> slots;
    }
}
