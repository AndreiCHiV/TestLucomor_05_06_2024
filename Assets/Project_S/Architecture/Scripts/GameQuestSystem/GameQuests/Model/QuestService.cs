using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class QuestService
    {
        public event Action<string, IReadOnlyQuest> AddCharacterQuestInViewChanged;
        public event Action<string, IReadOnlyQuest> AddComplitedQuestInViewChanged;

        private readonly Dictionary<string, QuestList> _questsMap = new Dictionary<string, QuestList>();
        private readonly Dictionary<string, QuestList> _currentQuestsCharacterMap = new Dictionary<string, QuestList>();
        private readonly Dictionary<string, QuestList> _completedQuests = new Dictionary<string, QuestList>();

        public void RegisterQuests(List<QuestListData> questsListData)
        {
            foreach (QuestListData questListData in questsListData)
            {
                QuestList questList = new QuestList(questListData);
                _questsMap[questList.Owner] = questList;
            }
        }

        public void RegisterQuestsCharacter(List<QuestListData> questsListCharacterData)
        {
            foreach (QuestListData questListCharacterData in questsListCharacterData)
            {
                QuestList questList = new QuestList(questListCharacterData);
                _currentQuestsCharacterMap[questList.Owner] = questList;
            }
        }
        public void RegisterCompletedQuests(List<QuestListData> completedQuests)
        {
            foreach (QuestListData completedQuestListData in completedQuests)
            {
                QuestList questList = new QuestList(completedQuestListData);
                _completedQuests[questList.Owner] = questList;
            }
        }

        public void AddQuest(string owner, QuestData data)
        {
            _questsMap[owner].AddQuest(data);
        }

        public void AddQuest(string owner, Quest data)
        {
            _questsMap[owner].AddQuest(data);
        }

        public void AddQuestCharacter(string owner, int questId)
        {
            Quest questList = (Quest)_questsMap[owner].GetQuest(questId);
            _currentQuestsCharacterMap[owner].AddQuest(questList);
            AddCharacterQuestInViewChanged?.Invoke(owner, questList);
        }

        public void AddCompletedQuest(string owner, int questId)
        {
            Quest questList = (Quest)_currentQuestsCharacterMap[owner].GetQuest(questId);
            _currentQuestsCharacterMap[owner].AddQuest(questList);
            AddComplitedQuestInViewChanged?.Invoke(owner, questList);
        }

        public void RemoveQuest(string owner, int questId)
        {
            QuestList ownerQuestList = _questsMap[owner];
            ownerQuestList.RemoveQuest(questId);
        }

        public void RemoveCurrentQuest(string owner, int questId)
        {
            QuestList ownerQuestList = _currentQuestsCharacterMap[owner];
            ownerQuestList.RemoveQuest(questId);
        }

        public IReadOnlyQuest GetQuest(string owner, int id)
        {
            return _questsMap[owner].GetQuest(id);
        }

        public List<IReadOnlyQuestList> GetAllQuestsCharacters()
        {
            List<IReadOnlyQuestList> questList = new List<IReadOnlyQuestList>();

            foreach (var quest in _currentQuestsCharacterMap)
            {
                questList.Add(quest.Value);
            }

            return questList;
        }

        public List<IReadOnlyQuestList> GetAllCompletedQuests()
        {
            List<IReadOnlyQuestList> questList = new List<IReadOnlyQuestList>();

            foreach (var quest in _completedQuests)
            {
                questList.Add(quest.Value);
            }

            return questList;
        }

    }
}
