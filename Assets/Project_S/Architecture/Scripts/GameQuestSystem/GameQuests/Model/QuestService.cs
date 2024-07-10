using System;
using System.Collections.Generic;
using UnityEngine;

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

        public int[] ContinueQuest(string owner, string id)
        {
            Debug.Log(owner);
            Debug.Log(id);
            string[] keyTag = id.Split("-");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }
            int questId = int.Parse(keyTag[0].Trim());
            int messageId = int.Parse(keyTag[1].Trim());

            int[] addMessageQuestID = _currentQuestsCharacterMap[owner].ContiueQuset(questId, messageId);

            return addMessageQuestID;
        }

        public void AddQuest(string owner, QuestData data)
        {
            _questsMap[owner].AddQuest(data);
        }

        public void AddQuest(string owner, Quest data)
        {
            _questsMap[owner].AddQuest(data);
        }

        public int[] AddQuestCharacter(string owner, int questId)
        {
            int[] changeDialogueCharacter;
            Quest quest = (Quest)_questsMap[owner].GetQuest(questId);

            if (!_currentQuestsCharacterMap.ContainsKey(owner))
            {
                QuestList questList = new QuestList(owner, quest);
                _currentQuestsCharacterMap.Add(owner, questList);

                changeDialogueCharacter = questList.ContiueQuset(questId, 0);

                AddCharacterQuestInViewChanged?.Invoke(owner, quest);//в последствии можно удалить это добавлене квеста в реальном времени
                return changeDialogueCharacter;
            }

            _currentQuestsCharacterMap[owner].AddQuest(quest);
            changeDialogueCharacter = _currentQuestsCharacterMap[owner].ContiueQuset(questId, 0);
            AddCharacterQuestInViewChanged?.Invoke(owner, quest);
            return changeDialogueCharacter;
        }

        public void AddCompletedQuest(string owner, int questId)
        {
            int[] changeDialogueCharacter;
            Quest quest = (Quest)_currentQuestsCharacterMap[owner].GetQuest(questId);

            if (!_completedQuests.ContainsKey(owner))
            {
                QuestList questList = new QuestList(owner, quest);
                _completedQuests.Add(owner, questList);

                changeDialogueCharacter = questList.ContiueQuset(questId, 0);

                AddComplitedQuestInViewChanged?.Invoke(owner, quest);
                return;
            }
            _completedQuests[owner].AddQuest(quest);
            //changeDialogueCharacter = _completedQuests[owner].ContiueQuset(questId, quest);
            AddCharacterQuestInViewChanged?.Invoke(owner, quest);
            return;
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
        public IReadOnlyQuest GetCharacterQuest(string owner, int id)
        {
            return _currentQuestsCharacterMap[owner].GetQuest(id);
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
