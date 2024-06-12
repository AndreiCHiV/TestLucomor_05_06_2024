using System;

namespace Assets.Project_S
{
    [Serializable]
    public class QuestInventorySlotData : InventorySlotData
    {
        public QuestInventorySlotData(string name, int amount, float weigth) : base(name, amount, weigth)
        {
            itemId = 0;
        }
    }
}
