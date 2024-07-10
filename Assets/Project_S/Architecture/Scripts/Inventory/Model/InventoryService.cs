using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryService
    {
        private readonly Dictionary<string, InventoryGrid> _inventoriesMap = new Dictionary<string, InventoryGrid>();

        public void RegisterInventory(InventoryGridData data)
        {
            InventoryGrid inventoryGrid = new InventoryGrid(data);
            _inventoriesMap[inventoryGrid.Owner] = inventoryGrid;
        }

        public void AddItems(string owner, string name, int amount = 1)
        {
            InventoryGrid inventory = _inventoriesMap[owner];
            inventory.AddItems(name, amount);
        }

        public bool RemoveItems(string owner, string name, int amount = 1)
        {
            InventoryGrid inventory = _inventoriesMap[owner];
            return inventory.RemoveItems(name, amount);
        }

        public IReadOnlyInventoryGrid GetInventoy(string owner)
        {
            return _inventoriesMap[owner];
        }
    }
}
