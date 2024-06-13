using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public interface IReadOnlyInventoryGrid
    {
        event Action<float> MaxWeigthInventoryChanged;
        event Action<IReadOnlyInventorySlot> AddInventorySlotChanged;
        event Action<string> RemoveInventorySlotChanged;

        string Owner { get; }
        float MaxWeigthInventory { get; }

        List<IReadOnlyInventorySlot> GetInventorySlots();
        IReadOnlyInventorySlot GetInventorySlot(string itemName);

    }
}
