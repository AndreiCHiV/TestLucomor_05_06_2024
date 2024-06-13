using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGridController
    {
        private InventoryGridView _view;

        public InventoryGridController(IReadOnlyInventoryGrid grid, InventoryGridView view)
        {
            _view = view;

            grid.MaxWeigthInventoryChanged += ChangedMaxWeigthInventory;
            grid.AddInventorySlotChanged += ChangedAddInventorySlot;
            grid.RemoveInventorySlotChanged += ChangedRemoveInventorySlot;
            grid.OwnerChanged += ChangedOwner;

            view.MaxWeigthInventory = grid.MaxWeigthInventory;

            Debug.Log(grid.GetInventorySlots());

            foreach (IReadOnlyInventorySlot slot in grid.GetInventorySlots())
            {
                Debug.Log(slot.Name);
                if (view.FindSlotNameInventoryGridView(slot.Name))
                {
                    new InventorySlotController(slot, view.GetSlotNameInventoryGridView(slot.Name));
                }
            }

            view.InitializeInventoryGridView(grid);
        }

        private void ChangedOwner(string value)
        {
            
        }

        private void ChangedAddInventorySlot(IReadOnlyInventorySlot slot)
        {
            _view.AddInventoryItemsView(slot);
        }
        private void ChangedRemoveInventorySlot(string itemName)
        {
            _view.RemoveInventorySlotView(itemName);
        }

        private void ChangedMaxWeigthInventory(float value)
        {
            _view.MaxWeigthInventory = value;
        }

    }
}
