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
        [SerializeField] private TMP_Text _ownerInventroy;

        public List<InventorySlotView> Slots => _slots;

        public float MaxWeigthInventory
        {
            get => float.Parse(_maxWeigthInventory.text);
            set => _maxWeigthInventory.text = value.ToString();
        }

        public string OwnerInventory
        {
            get => _ownerInventroy.text;
            set => _ownerInventroy.text = value;

        }

        public InventorySlotView AddInventorySlotView()
        {
            GameObject slotObject = Instantiate(_inventorySlot);
            slotObject.transform.SetParent(GameObject.FindGameObjectWithTag("Inventory").transform, false);
            InventorySlotView inventorySlot = slotObject.GetComponent<InventorySlotView>();

            Slots.Add(inventorySlot);

            return inventorySlot;
        }


        public void RemoveAllSlots()
        {
            foreach (InventorySlotView slotView in _slots)
            {
                Destroy(slotView.gameObject);
            }
            _slots.Clear();
        }
    }
}
