namespace Assets.Project_S
{
    public class ScreenInventoryController
    {
        private InventoryService _service;
        private ScreenInventoryView _view;

        public ScreenInventoryController(InventoryService service, ScreenInventoryView view)
        {
            _view = view;
            _service = service;
        }

        public void OpenInventory(string owner)
        {
            IReadOnlyInventoryGrid inventoryGrid = _service.GetInventoy(owner);
            ScreenInventoryView inventoryView = _view.InventoryView;
        }

    }
}
