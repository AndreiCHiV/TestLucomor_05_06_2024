using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    [Serializable]
    public class QuestData
    {
        public int questID;
        public string nameQuest;
        public List<string> questMessage;

        public QuestData(int id, List<string> message)
        {
            questMessage = message;
            questID = id;
        }
    }
}
