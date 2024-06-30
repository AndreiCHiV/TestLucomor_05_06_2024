using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    [Serializable]
    public class QuestListData
    {
        public string owner;
        public bool isEmpty;
        public List<QuestData> questDatas;
    }
}
