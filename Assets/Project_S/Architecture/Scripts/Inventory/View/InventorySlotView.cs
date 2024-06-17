using System;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private TMP_Text _itemAmount;
        [SerializeField] private TMP_Text _itmeWeigth;

        public InventorySlotView(string name,int amount,float weigth)
        {
            _itemName.text = name;
            _itemAmount.text = amount.ToString();
            _itmeWeigth.text = weigth.ToString();
        }

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

        public float ItemWeigth
        {
            get => float.Parse(_itmeWeigth.text);
            set => _itmeWeigth.text = value.ToString();
        }
    }
}
