using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGrid : IReadOnlyInventoryGrid
    {

        public event Action<IReadOnlyInventorySlot> AddInventorySlotChanged;
        public event Action<string> RemoveInventorySlotChanged;


        private InventoryGridData _inventoryGridData;


        private List<InventorySlot> _slotsMap = new List<InventorySlot>();

        private DataItems _datamap = new DataItems();// на удаление будет браться из базы


        public InventoryGrid(InventoryGridData inventoryGridData)
        {
            _inventoryGridData = inventoryGridData;

            if (!_inventoryGridData.IsEmpty)
            {
                _inventoryGridData.slots = new List<InventorySlotData>();
            }
            else
            {
                foreach (InventorySlotData slotData in inventoryGridData.slots)
                {
                    CreateNewSlot(slotData);
                }
            }
        }

        public string Owner => _inventoryGridData.owner;

        public float MaxWeigthInventory => _inventoryGridData.maxWeigthInventory;

        public bool IsEmpty
        {
            get => _inventoryGridData.IsEmpty;
            set => _inventoryGridData.IsEmpty = value;
        }


        private bool IsSlotinInventoryGrid(string name)
        {
            foreach (InventorySlot slot in _slotsMap)
            {
                if (slot.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private InventorySlot GetSlot(string name)
        {
            foreach (InventorySlot slot in _slotsMap)
            {
                if (slot.Name == name)
                {
                    return slot;
                }
            }
            return null;
        }


        private void CreateNewSlot(InventorySlotData slotData)
        {
            InventorySlot slot;

            if (slotData is QuestInventorySlotData)
            {
                slot = new QuestInventorySlot((QuestInventorySlotData)slotData);
            }
            else if (slotData is ArmorInventorySlotData)
            {
                slot = new ArmorInventorySlot((ArmorInventorySlotData)slotData);
            }
            else if (slotData is HealthInventorySlotData)
            {
                slot = new HealthInventorySlot((HealthInventorySlotData)slotData);
            }
            else
            {
                throw new Exception("No the type!");
            }
            _slotsMap.Add(slot);
            AddInventorySlotChanged?.Invoke(slot);
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

        public List<IReadOnlyInventorySlot> GetSlots()
        {
            List<IReadOnlyInventorySlot> slots = new List<IReadOnlyInventorySlot>();

            foreach (InventorySlot slot in _slotsMap)
            {
                IReadOnlyInventorySlot slotIReadOnly;

                if (slot is QuestInventorySlot)
                {
                    slotIReadOnly = (QuestInventorySlot)slot;
                }
                else if (slot is ArmorInventorySlot)
                {
                    slotIReadOnly = (ArmorInventorySlot)slot;
                }
                else if (slot is HealthInventorySlot)
                {
                    slotIReadOnly = (HealthInventorySlot)slot;
                }
                else
                {
                    throw new Exception("No the type!");
                }

                slots.Add(slotIReadOnly);
            }

            return slots;
        }

        public IReadOnlyInventorySlot GetInventorySlot(string itemName)
        {
            foreach (IReadOnlyInventorySlot slot in _slotsMap)
            {
                if (slot.Name == itemName)
                {
                    return slot;
                }
            }
            throw new Exception("No the slot!");
        }


        public void CreateNewSlotView(string name)
        {
            InventorySlotData slotData;

            foreach (InventorySlotData slotDataMap in _datamap.itemsData)
            {
                if (slotDataMap.itemName == name)
                {
                    slotData = CreateNewSlotType(slotDataMap);
                    CreateNewSlot(slotData);
                    return;
                }
            }
        }


        public void AddItems(string itemName, int amount)
        {
            if (!_datamap.KeyContainsInList(itemName))
            {
                throw new Exception($"Item name: {itemName} not found in DataBase!");
            }

            if (!IsEmpty)
            {
                IsEmpty = true;
            }

            if (!IsSlotinInventoryGrid(itemName))
            {
                CreateNewSlotView(itemName);
            }

            foreach (InventorySlot slot in _slotsMap)
            {
                if (slot.Name == itemName)
                {
                    slot.Amount += amount;
                    slot.Weigth += _datamap.GetWeightKey(itemName) * amount;
                }
            }
        }

        public void RemoveItems(string itemName, int amount)
        {
            InventorySlot slotName = GetSlot(itemName);

            if (slotName != null)
            {
                int currentAmount;
                float currentWeigth;

                currentAmount = slotName.Amount - amount;
                currentWeigth = slotName.Weigth - _datamap.GetWeightKey(itemName) * amount;

                if (currentAmount == 0)
                {
                    RemoveInventorySlotChanged?.Invoke(itemName);
                    Debug.Log($"_Delet_Slot_{slotName.Name}");
                    bool slotNameRemove = _slotsMap.Remove(slotName);
                    Debug.Log($"Remove {slotName.Name} is {slotNameRemove}!");
                    IsEmpty = false;

                    return;
                }
                else if (currentAmount < 0)
                {
                    Debug.Log("There ara not enough items!");
                    return;
                }

                slotName.Amount = currentAmount;
                slotName.Weigth = currentWeigth;
            }
            else
            {
                Debug.Log($"The Item {itemName} not found in Inventary");
                return;
            }
        }
    }
}
