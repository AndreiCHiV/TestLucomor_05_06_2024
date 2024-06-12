using System;

namespace Assets.Project_S
{
    [Serializable]
    public abstract class InventorySlotData
    {
        public string itemName;
        public int itemId;
        public int itemAmount;
        public float itemWeigth;

        public InventorySlotData(string name, int amount, float weigth)
        {
            itemName = name;
            itemAmount = amount;
            itemWeigth = weigth;
        }
    }
}
