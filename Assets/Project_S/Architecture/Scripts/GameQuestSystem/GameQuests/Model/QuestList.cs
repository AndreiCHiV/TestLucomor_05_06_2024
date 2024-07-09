using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestList : IReadOnlyQuestList
    {
        public event Action<int> AddQuestChanged;

        private readonly QuestListData _data;

        private List<Quest> _quests = new List<Quest>();

        public QuestList(QuestListData data)
        {
            _data = data;
            Initialize(data);
        }
        public QuestList(string owner, Quest quest)
        {
            _data = new QuestListData();
            _data.owner = owner;
            _data.questDatas = new List<QuestData>();
            _data.questDatas.Add(quest.QuestData);
            _quests.Add(quest);
        }

        public string Owner => _data.owner;

        private void Initialize(QuestListData data)
        {
            foreach (QuestData quest in data.questDatas)
            {
                _quests.Add(new Quest(quest));
            }
        }

        public int[] ContiueQuset(int questId, int messageId)
        {
            foreach (Quest quest in _quests)
            {
                if (quest.QuestID == questId)
                {
                    return quest.ContinueQuest(messageId);
                }
            }
            return null;
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
            AddQuest(quest);
        }

        public void AddQuest(Quest quest)
        {
            _quests.Add(quest);
            AddQuestChanged?.Invoke(quest.QuestID);
        }

        internal void RemoveQuest(int questId)
        {
            foreach (Quest quest in _quests)
            {
                if (quest.QuestID == questId)
                {
                    _quests.Remove(quest);
                    return;
                }
            }
        }
    }
}
