using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventoryGridView : MonoBehaviour
    {
        [SerializeField] private List<InventorySlotView> _slots = new List<InventorySlotView>();
        [SerializeField] private TMP_Text _maxWeigthInventory;

        private void AddInventorySlotView(IReadOnlyInventorySlot slot)
        {
            InventorySlotView slotView = new InventorySlotView(slot.Name, slot.Amount, slot.Weigth);
            _slots.Add(slotView);
        }

        public float MaxWeigthInventory
        {
            get => float.Parse(_maxWeigthInventory.text);
            set => _maxWeigthInventory.text = value.ToString();
        }

        public void InitializeInventoryGridView(IReadOnlyInventoryGrid grid)
        {
            foreach (IReadOnlyInventorySlot slot in grid.GetInventorySlots())
            {
                AddInventorySlotView(slot);
                //создание префаба inventory slot view;
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
            //Создание префаба inventory slot view;


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
