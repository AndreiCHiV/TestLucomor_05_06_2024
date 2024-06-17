using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGridController : IDisposable
    {
        private InventoryGridView _view;
        IReadOnlyInventoryGrid _grid;
        private readonly List<InventorySlotController> _inventorySlotControllers = new List<InventorySlotController>();

        public InventoryGridController(IReadOnlyInventoryGrid grid, InventoryGridView view)
        {
            _view = view;
            _grid = grid;

            grid.AddInventorySlotChanged += ChangedAddInventorySlot;
            grid.RemoveInventorySlotChanged += ChangedRemoveInventorySlot;

            view.MaxWeigthInventory = grid.MaxWeigthInventory;
            view.OwnerInventory = grid.Owner;

            if (grid.IsEmpty)
            {
                view.RemoveAllSlots();
                foreach (IReadOnlyInventorySlot slot in grid.GetSlots())
                {
                    ChangedAddInventorySlot(slot);
                }
            }

        }

        private void ChangedAddInventorySlot(IReadOnlyInventorySlot value)
        {
            InventorySlotView slotView = _view.AddInventorySlotView();

            _inventorySlotControllers.Add(new InventorySlotController(value, slotView));

            _view.Slots.Add(slotView);
        }

        private void ChangedRemoveInventorySlot(string value)
        {

        }

        public void Dispose()
        {
            _grid.AddInventorySlotChanged -= ChangedAddInventorySlot;
            _grid.RemoveInventorySlotChanged -= ChangedRemoveInventorySlot;
        }
    }
}
