using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventorySlotController
    {
        private InventorySlotView _view;
        public InventorySlotController(IReadOnlyInventorySlot slot, InventorySlotView view)
        {
            _view = view;

            slot.ItemNameChanged += ChangedItemName;
            slot.ItemAmountChanged += ChangedItemAmount;
            slot.ItemWeigthChanged += ChangedItemWeight;

            view.ItemName = slot.Name;
            view.ItemAmount = slot.Amount;
            view.ItemWeigth = slot.Weigth;
        }

        private void ChangedItemWeight(float value)
        {
            _view.ItemWeigth = value;
        }

        private void ChangedItemAmount(int value)
        {
            _view.ItemAmount = value;
        }

        private void ChangedItemName(string value)
        {
            _view.ItemName = value;
        }
    }
}
