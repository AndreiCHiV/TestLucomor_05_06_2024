using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class InventoryGrid : IReadOnlyInventoryGrid
    {
        public event Action<string> ItemOwnerChanged;

        private InventoryGridData _inventoryGridData;

        private Dictionary<string, InventorySlot> _slotsMap = new Dictionary<string, InventorySlot>();

        private DataItems _datamap;

        public InventoryGrid(InventoryGridData inventoryGridData)
        {
            _inventoryGridData = inventoryGridData;


            _datamap = new DataItems();


            RegistrationInventorySlots(_inventoryGridData.slots);
        }

        public string Owner
        {
            get => _inventoryGridData.owner;
            set
            {
                if (_inventoryGridData.owner != value)
                {
                    _inventoryGridData.owner = value;
                    ItemOwnerChanged?.Invoke(value);
                }
            }
        }

        private void RegistrationInventorySlots(List<InventorySlotData> slots)
        {
            foreach (InventorySlotData slotData in slots)
            {
                RegistrationInventorySlot(slotData);
            }
        }

        private void RegistrationInventorySlot(InventorySlotData slotData)
        {
            if (slotData is QuestInventorySlotData questItemData)
            {
                _slotsMap[slotData.itemName] = new QuestInventorySlot(questItemData);
            }
            else if (slotData is ArmorInventorySlotData armorItemData)
            {
                _slotsMap[slotData.itemName] = new ArmorInventorySlot(armorItemData);
            }
            else if (slotData is HealthInventorySlotData healthItemData)
            {
                _slotsMap[slotData.itemName] = new HealthInventorySlot(healthItemData);
            }
        }

        public void AddItemsInSlot(string itemName, int amount)
        {
            if (_slotsMap[itemName] == null)
            {
                foreach (InventorySlotData slotData in _datamap.itemsData)
                {
                    if (slotData.itemName == itemName)
                    {
                        _inventoryGridData.slots.Add(slotData);
                        RegistrationInventorySlot(slotData);
                    }
                }
            }
            else if (_slotsMap[itemName] != null)
            {
                _slotsMap[itemName].AddAmountItems(amount);
            }
            else
                throw new Exception($"Item name: {itemName} not found!");
        }

        public void RemoveItemsInSlot(string itemName, int amount)
        {

        }

        public List<IReadOnlySlot> GetInventorySlots()
        {
            List<IReadOnlySlot> slots = new List<IReadOnlySlot>();

            foreach (IReadOnlySlot slot in _inventoryGridData.slots)
            {
                slots.Add(slot);
            }

            return slots;
        }
    }
}
