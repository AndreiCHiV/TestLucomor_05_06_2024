using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class QuestList : IReadOnlyQuestList
    {
        private readonly QuestListData _data;

        private List<Quest> _quests = new List<Quest>();

        public QuestList(QuestListData data)
        {
            _data = data;

            if (!data.isEmpty)
            {
                data.questDatas = new List<QuestData>();
            }
            else
            {
                Initialize(data);
            }
        }

        public string Owner => _data.owner;

        private void Initialize(QuestListData data)
        {
            foreach (QuestData quest in data.questDatas)
            {
                _quests.Add(new Quest(quest));
            }
        }

        public List<IReadOnlyQuest> GetQuestList()
        {
            List<IReadOnlyQuest> list = new List<IReadOnlyQuest>();

            foreach (IReadOnlyQuest quest in _quests)
            {
                list.Add(quest);
            }

            return list;
        }

        public IReadOnlyQuest GetQuest(int id)
        {
            foreach (Quest quest in _quests)
            {
                if (quest.QuestID == id)
                {
                    return quest;
                }
            }
            
            return null;
        }

        public void AddQuest(QuestData questData)
        {
            Quest quest = new Quest(questData);
            _quests.Add(quest);
        }
    }
}
