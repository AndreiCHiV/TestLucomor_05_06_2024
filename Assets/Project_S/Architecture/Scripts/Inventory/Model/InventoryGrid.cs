﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGrid : IReadOnlyInventoryGrid
    {
        public event Action<float> MaxWeigthInventoryChanged;
        public event Action<IReadOnlyInventorySlot> AddInventorySlotChanged;
        public event Action<string> RemoveInventorySlotChanged;
        public event Action<string> OwnerChanged;

        private InventoryGridData _inventoryGridData;

        private Dictionary<string, InventorySlot> _slotsMap = new Dictionary<string, InventorySlot>();

        private DataItems _datamap = new DataItems();// на удаление будет браться из базы


        public InventoryGrid(InventoryGridData inventoryGridData)
        {
            _inventoryGridData = inventoryGridData;
            InitializationInventorySlots(_inventoryGridData.slots);
        }


        public string Owner
        {
            get => _inventoryGridData.owner;
            set
            {
                _inventoryGridData.owner = value;
                OwnerChanged?.Invoke(value);
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
        private void InitializationInventorySlots(List<InventorySlotData> slots)
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
            }
            else if (slotData is ArmorInventorySlotData armorItemData)
            {
                _slotsMap[slotData.itemName] = new ArmorInventorySlot(armorItemData);
            }
            else if (slotData is HealthInventorySlotData healthItemData)
            {
                _slotsMap[slotData.itemName] = new HealthInventorySlot(healthItemData);
            }
            AddInventorySlotChanged?.Invoke(_slotsMap[slotData.itemName]);
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
                    }
                }
            }
            
            _slotsMap[itemName].Amount += amount;
            _slotsMap[itemName].Weigth += _datamap.GetWeightKey(itemName) * amount;
        }

        public void RemoveItems(string itemName, int amount)
        {
            if (!_slotsMap.ContainsKey(itemName))
            {
                Debug.Log($"The Item {itemName} not found in Inventary");
                return;
            }

            int currentAmount = _slotsMap[itemName].Amount - amount;
            float currentWeight = _slotsMap[itemName].Weigth - _datamap.GetWeightKey(itemName) * amount;

            if (currentAmount == 0)
            {
                RemoveInventorySlotChanged?.Invoke(_slotsMap[itemName].Name);
                _slotsMap.Remove(itemName);


                for (int i = 0; i < _inventoryGridData.slots.Count; i++)
                {
                    if (_inventoryGridData.slots[i].itemName == itemName)
                    {
                        _inventoryGridData.slots[i] = null;
                        Debug.Log($"Slot {itemName} removed!");
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
            _slotsMap[itemName].Weigth = currentWeight;
        }

        public List<IReadOnlyInventorySlot> GetInventorySlots()
        {
            List<IReadOnlyInventorySlot> slots = new List<IReadOnlyInventorySlot>();

            foreach (InventorySlotData slotData in _inventoryGridData.slots)
            {
                if (slotData is QuestInventorySlotData questItemData)
                {
                    slots.Add(new QuestInventorySlot(questItemData));
                }
                else if (slotData is ArmorInventorySlotData armorItemData)
                {
                    slots.Add(new ArmorInventorySlot(armorItemData));
                }
                else if (slotData is HealthInventorySlotData healthItemData)
                {
                    slots.Add(new HealthInventorySlot(healthItemData));
                }
            }

            return slots;
        }

        public IReadOnlyInventorySlot GetInventorySlot(string itemName)
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
