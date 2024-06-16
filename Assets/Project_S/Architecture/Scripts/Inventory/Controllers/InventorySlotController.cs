﻿using System;
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
            view.ItemWeight = slot.Weigth;
        }

        private void ChangedItemWeight(float value)
        {
            _view.ItemWeight = value;
        }

        private void ChangedItemAmount(int value)
        {
            _view.ItemAmount = value;
            Debug.Log(value);
        }

        private void ChangedItemName(string value)
        {
            _view.ItemName = value;
            Debug.Log(value);
        }
    }
}