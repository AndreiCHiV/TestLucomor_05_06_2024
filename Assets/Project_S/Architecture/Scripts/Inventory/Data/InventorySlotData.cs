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

    [Serializable]
    public class QuestInventorySlotData : InventorySlotData
    {
        public QuestInventorySlotData(string name, int amount, float weigth) : base(name, amount, weigth)
        {
            itemId = 1;
        }
    }

    public class ArmorInventorySlotData : InventorySlotData
    {
        public ArmorInventorySlotData(string name, int amount, float weigth) : base(name, amount, weigth)
        {
            itemId = 2;
        }
    }
    public class HealthInventorySlotData : InventorySlotData
    {
        public HealthInventorySlotData(string name, int amount, float weigth) : base(name, amount, weigth)
        {
            itemId = 3;
        }
    }
}
