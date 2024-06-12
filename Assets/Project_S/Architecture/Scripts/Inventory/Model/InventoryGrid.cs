using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGrid : IReadOnlyInventoryGrid
    {
        public event Action<string> ItemOwnerChanged;
        public event Action<float> MaxWeigthInventoryChanged;
        public event Action<InventorySlotData> AddInventorySlot;
        public event Action<string> RemoveInventorySlot;

        private InventoryGridData _inventoryGridData;

        private Dictionary<string, InventorySlot> _slotsMap = new Dictionary<string, InventorySlot>();

        private DataItems _datamap = new DataItems();// на удаление будет браться из базы


        public InventoryGrid(InventoryGridData inventoryGridData)
        {
            _inventoryGridData = inventoryGridData;
            if (_inventoryGridData.slots == null)
            {
                _inventoryGridData.slots = new List<InventorySlotData>();
            }
            else
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

        public float MaxWeigthInventory
        {
            get => _inventoryGridData.maxWeigthInventory;
            set
            {
                if (_inventoryGridData.maxWeigthInventory != value)
                {
                    _inventoryGridData.maxWeigthInventory = value;
                    MaxWeigthInventoryChanged?.Invoke(value);
                }
            }
        }
        private void RegistrationInventorySlots(List<InventorySlotData> slots)
        {
            foreach (InventorySlotData slotData in slots)
            {
                RegistrationInventory(slotData);
            }
        }

        private void RegistrationInventory(InventorySlotData slotData)
        {
            if (slotData is QuestInventorySlotData questItemData)
            {
                _slotsMap[slotData.itemName] = new QuestInventorySlot(questItemData);
                Debug.Log(_slotsMap["Key"].Name);
            }
            else if (slotData is ArmorInventorySlotData armorItemData)
            {
                _slotsMap[slotData.itemName] = new ArmorInventorySlot(armorItemData);
                Debug.Log(_slotsMap["Knife"].Name);
            }
            else if (slotData is HealthInventorySlotData healthItemData)
            {
                _slotsMap[slotData.itemName] = new HealthInventorySlot(healthItemData);
            }
        }

        private void RegistrationInventorySlot(InventorySlotData slotData)
        {
            _inventoryGridData.slots.Add(slotData);
            RegistrationInventory(slotData);
        }

        private InventorySlotData CreateNewSlotType(InventorySlotData slotData)
        {
            InventorySlotData inventorySlotData;

            if (slotData is QuestInventorySlotData)
            {

                inventorySlotData = new QuestInventorySlotData(slotData.itemName, slotData.itemAmount, slotData.itemWeigth);
            }
            else if (slotData is ArmorInventorySlotData)
            {
                inventorySlotData = new ArmorInventorySlotData(slotData.itemName, slotData.itemAmount, slotData.itemWeigth);
            }
            else if (slotData is HealthInventorySlotData)
            {
                inventorySlotData = new HealthInventorySlotData(slotData.itemName, slotData.itemAmount, slotData.itemWeigth);
            }
            else
                throw new Exception("No the type!");

            return inventorySlotData;
        }

        public void AddItems(string itemName, int amount)
        {

            if (!_datamap.KeyContainsInList(itemName))
            {
                throw new Exception($"Item name: {itemName} not found in DataBase!");
            }

            if (!_slotsMap.ContainsKey(itemName))
            {
                foreach (InventorySlotData slotData in _datamap.itemsData)
                {
                    if (slotData.itemName == itemName)
                    {
                        InventorySlotData inventorySlotData = CreateNewSlotType(slotData);
                        RegistrationInventorySlot(inventorySlotData);
                        AddInventorySlot?.Invoke(inventorySlotData);
                    }
                }
            }


            _slotsMap[itemName].Amount += amount;
        }

        public void RemoveItems(string itemName, int amount)
        {
            if (!_slotsMap.ContainsKey(itemName))
            {
                Debug.Log($"The Item {itemName} not found in Inventary");
                return;
            }

            int currentAmount = _slotsMap[itemName].Amount - amount;

            if (currentAmount == 0)
            {
                RemoveInventorySlot?.Invoke(_slotsMap[itemName].Name);
                _slotsMap.Remove(itemName);

                foreach (InventorySlotData slot in _inventoryGridData.slots)//проверка потом на удаление
                {
                    if (slot.itemName == null)
                    {
                        Debug.Log($"Slot {itemName} remove!");
                    }
                }
                return;
            }
            else if (currentAmount < 0)
            {
                Debug.Log("There ara not enough items!");
                return;
            }

            _slotsMap[itemName].Amount = currentAmount;
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

        public InventorySlot GetInventorySlot(string itemName)
        {
            if (!_slotsMap.ContainsKey(itemName))
            {
                throw new Exception($"The Item {itemName} not found in Inventary");
            }
            else
                return _slotsMap[itemName];
        }
    }
}
