using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenInventoryController
    {
        private readonly InventoryService _service;
        private readonly ScreenInventoryView _view;

        private InventoryGridController _inventoryGridController;

        public ScreenInventoryController(InventoryService service, ScreenInventoryView view)
        {
            _view = view;
            _service = service;
        }

        public void OpenInventory(string owner)
        {
            if (_inventoryGridController != null)
            {
                _inventoryGridController.Dispose();
            }

            IReadOnlyInventoryGrid inventoryGrid = _service.GetInventoy(owner);
            InventoryGridView inventoryView = _view.InventoryGridView;

            _inventoryGridController = new InventoryGridController(inventoryGrid, inventoryView);

        }


    }
}
