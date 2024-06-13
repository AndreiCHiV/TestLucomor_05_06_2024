using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGridView : MonoBehaviour
    {
        [SerializeField] private GameObject _inventorySlot;

        [SerializeField] private List<InventorySlotView> _slots = new List<InventorySlotView>();
        [SerializeField] private TMP_Text _maxWeigthInventory;

        public List<InventorySlotView> Slots => _slots;
        public float MaxWeigthInventory
        {
            get => float.Parse(_maxWeigthInventory.text);
            set => _maxWeigthInventory.text = value.ToString();
        }

        public bool FindSlotNameInventoryGridView(string nameSlot)
        {
            foreach (InventorySlotView slot in _slots)
            {
                if (slot.ItemName == nameSlot)
                {
                    return true;
                }
            }
            return false;
        }

        public InventorySlotView GetSlotNameInventoryGridView(string nameSlot)
        {
            foreach (InventorySlotView slotView in _slots)
            {
                if (slotView.ItemName == nameSlot)
                {
                    return slotView;
                }
            }

            return null;
        }

        private void AddInventorySlotView(IReadOnlyInventorySlot slot)
        {
            GameObject slotObject = Instantiate(_inventorySlot);
            slotObject.transform.SetParent(GameObject.FindGameObjectWithTag("Inventory").transform,false);
            InventorySlotView inventorySlot = slotObject.GetComponent<InventorySlotView>();
            
            inventorySlot.ItemName = slot.Name;
            inventorySlot.ItemAmount = slot.Amount;
            inventorySlot.ItemWeight = slot.Weigth;

            _slots.Add(inventorySlot);
        }


        public void InitializeInventoryGridView(IReadOnlyInventoryGrid grid)
        {
            foreach (IReadOnlyInventorySlot slot in grid.GetInventorySlots())
            {
                Debug.Log(slot.Amount);
                AddInventorySlotView(slot);
            }

        }

        public void AddInventoryItemsView(IReadOnlyInventorySlot slot)
        {
            foreach (InventorySlotView slotView in _slots)
            {
                if (slotView.ItemName == slot.Name)
                {
                    slotView.ItemAmount = slot.Amount;
                    slotView.ItemWeight = slot.Weigth;
                    return;
                }
            }

            AddInventorySlotView(slot);
        }

        public void RemoveInventorySlotView(string slotName)
        {
            foreach (InventorySlotView slotView in _slots)
            {
                if (slotView.ItemName == slotName)
                {
                    //Удаление префаба inventory slot c именем slotName;
                    return;
                }
            }
            Debug.Log($"Slot {slotName} not founde");
        }

    }
}
