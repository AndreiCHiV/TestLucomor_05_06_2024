using System;

namespace Assets.Project_S
{
    public abstract class InventorySlot : IReadOnlySlot
    {
        public event Action<string> ItemNameChanged;
        public event Action<int> ItemIdChanged;
        public event Action<int> ItemAmountChanged;
        public event Action<float> ItemWeigthChanged;

        private readonly InventorySlotData _slotData;

        public InventorySlot(InventorySlotData slotData)
        {
            _slotData = slotData;
        }

        public string Name
        {
            get => _slotData.itemName;
            set
            {
                if (_slotData.itemName != value)
                {
                    _slotData.itemName = value;
                    ItemNameChanged?.Invoke(value);
                }
            }
        }

        public int Id
        {
            get => _slotData.itemId;
            set
            {
                if (_slotData.itemId != value)
                {
                    _slotData.itemId = value;
                    ItemIdChanged?.Invoke(value);
                }
            }
        }
        public int Amount
        {
            get => _slotData.itemAmount;
            set
            {
                if (_slotData.itemAmount != value)
                {
                    _slotData.itemAmount = value;
                    ItemWeigthChanged?.Invoke(value);
                }
            }
        }

        public float Weigth
        {
            get => _slotData.itemWeigth;
            set
            {
                if (_slotData.itemWeigth != value)
                {
                    _slotData.itemWeigth = value;
                    ItemWeigthChanged?.Invoke(value);
                }
            }
        }


        public void AddWeigthItems(float itemWeight)
        {
            Weigth += itemWeight;
        }
        
        public void AddAmountItems(int itemAmount)
        {
            Amount += itemAmount;
        }

    }
}
