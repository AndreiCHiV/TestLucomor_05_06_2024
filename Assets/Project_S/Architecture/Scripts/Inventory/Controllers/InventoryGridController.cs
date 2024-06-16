using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGridController
    {
        private InventoryGridView _view;
        private List<InventorySlotController> _inventorySlotControllers = new List<InventorySlotController>();

        public InventoryGridController(IReadOnlyInventoryGrid grid, InventoryGridView view)
        {
            view.RemoveAllSlots();

            _view = view;

            grid.AddInventorySlotChanged += ChangedAddInventorySlot;
            grid.RemoveInventorySlotChanged += ChangedRemoveInventorySlot;

            view.MaxWeigthInventory = grid.MaxWeigthInventory;
            view.OwnerInventory = grid.Owner;

            if (grid.IsEmpty)
            {
                foreach (IReadOnlyInventorySlot slot in grid.GetSlots())
                {
                    InventorySlotView slotView = AddInventorySlot(slot);
                    _inventorySlotControllers.Add(new InventorySlotController(slot, slotView));
                }
            }
        }

        private InventorySlotView AddInventorySlot(IReadOnlyInventorySlot value)
        {
            InventorySlotView slotView = _view.AddInventorySlotView();           

            return slotView;
        }

        private InventorySlotView ChangedAddInventorySlot(IReadOnlyInventorySlot value)
        {
            InventorySlotView slotView = _view.AddInventorySlotView();

            _inventorySlotControllers.Add(new InventorySlotController(value, slotView));

            return slotView;
        }

        private void ChangedRemoveInventorySlot(string value)
        {
            
        }

    }
}
