using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public interface IReadOnlyInventoryGrid
    {
        event Action<IReadOnlyInventorySlot> AddInventorySlotChanged;
        event Action<string> RemoveInventorySlotChanged;
        

        string Owner { get; }
        float MaxWeigthInventory { get; }
        bool IsEmpty { get; }

        List<IReadOnlyInventorySlot> GetSlots();
        IReadOnlyInventorySlot GetInventorySlot(string itemName);

    }
}
