using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    [Serializable]
    public class QuestData
    {
        public int questID;
        public string nameQuest;
        public List<QuestMessageData> questMessage;

        //public QuestData(int id, string name, List<QuestMessageData> message)
        //{
        //    questMessage = message;
        //    questID = id;
        //    nameQuest = name;
        //}
    }
}
