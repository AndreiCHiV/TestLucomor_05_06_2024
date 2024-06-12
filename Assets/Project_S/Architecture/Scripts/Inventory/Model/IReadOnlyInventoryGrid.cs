using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    interface IReadOnlyInventoryGrid
    {
        event Action<string> ItemOwnerChanged;
        event Action<float> MaxWeigthInventoryChanged;
        event Action<InventorySlotData> AddInventorySlot;
        event Action<string> RemoveInventorySlot;

        string Owner { get; }
        float MaxWeigthInventory { get; }

        List<IReadOnlySlot> GetInventorySlots();
    }
}
