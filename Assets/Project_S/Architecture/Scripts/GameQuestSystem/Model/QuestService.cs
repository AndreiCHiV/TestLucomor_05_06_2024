using System.Collections.Generic;

namespace Assets.Project_S
{
    public class QuestService
    {
        private readonly Dictionary<string, QuestList> _questMap = new Dictionary<string, QuestList>();

        public void RegisterQuest(QuestListData questListData)
        {
            QuestList questList = new QuestList(questListData);
            _questMap[questList.Owner] = questList;
        }

        public IReadOnlyQuestList GetQuestList(string owner)
        {
            return _questMap[owner];
        }

        public IReadOnlyQuest GetQuest(string owner, int id)
        {
            return _questMap[owner].GetQuest(id);
        }

        public void AddQuest(string owner, QuestData data)
        {
            _questMap[owner].AddQuest(data);
        }

    }
}
