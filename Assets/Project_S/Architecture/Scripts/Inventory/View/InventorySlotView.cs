using System;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private TMP_Text _itemAmount;
        [SerializeField] private TMP_Text _itmeWeight;

        public string ItemName
        {
            get => _itemName.text;
            set => _itemName.text = value;
        }

        public int ItemAmount
        {
            get => Convert.ToInt32(_itemAmount.text);
            set => _itemAmount.text = value.ToString();
        }

        public int ItemWeight
        {
            get => Convert.ToInt32(_itmeWeight.text);
            set => _itmeWeight.text = value.ToString();
        }
    }
}
