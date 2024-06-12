using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    interface IReadOnlyInventoryGrid
    {
        event Action<string> ItemOwnerChanged;

        string Owner { get; }

        List<IReadOnlySlot> GetInventorySlots();
    }
}
