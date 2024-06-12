using System.Collections.Generic;

namespace Assets.Project_S
{
    public class DataItems
    {
        public List<InventorySlotData> itemsData;

        public DataItems()
        {
            itemsData = new List<InventorySlotData>()
            {
                new QuestInventorySlotData("Key", 0, 0.1f),
                new QuestInventorySlotData("Hart", 0, 0.8f),
                new ArmorInventorySlotData("Sword", 0, 6f),
                new ArmorInventorySlotData("Knife", 0, 0.7f),
                new HealthInventorySlotData("Herb", 0, 0.1f),
            };
        }

        public bool KeyContainsInList(string key)
        {
            foreach (InventorySlotData keyList in itemsData)
            {
                if (keyList.itemName == key)
                    return true;
            }
            return false;
        }
    }
}
