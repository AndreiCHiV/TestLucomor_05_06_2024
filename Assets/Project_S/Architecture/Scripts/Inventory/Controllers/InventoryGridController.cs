using System;

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

            view.MaxWeigthInventory = grid.MaxWeigthInventory;

            view.InitializeInventoryGridView(grid);
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
