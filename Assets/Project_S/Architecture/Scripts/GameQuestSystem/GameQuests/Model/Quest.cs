using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class Quest : IReadOnlyQuest
    {
        public event Action ChangedMessageQuest;

        private readonly QuestData _questData;
        private bool _completedQuest;
        private List<string> _messages = new List<string>();

        public Quest(QuestData questData)
        {
            _questData = questData;
        }

        public QuestData QuestData => _questData;

        public bool CompletedQuest
        {
            get => _completedQuest;
            set => _completedQuest = value;
        }

        public int QuestID
        {
            get => _questData.questID;
            set => _questData.questID = value;
        }

        public string NameQuest
        {
            get => _questData.nameQuest;
        }

        public int[] ContinueQuest(int messageId)
        {
            foreach (QuestMessageData quest in _questData.questMessage)
            {
                if (messageId == quest.messageID)
                {
                    _messages.Add(quest.message);
                    _completedQuest = quest.completedQuest;

                    ChangedMessageQuest?.Invoke();

                    return quest.messageChangeDialogueID;
                }
            }
            
            return null;
        }

        public string GetMessages()
        {
            string getMessage = "";

            if (CompletedQuest)
            {
                foreach (string message in _messages)
                {
                    getMessage += message + "\n<align=\"center\"><b>Конец задния!</b>\n";
                }
            }
            else
            {
                foreach (string message in _messages)
                {
                    getMessage += message + "\n<align=\"center\"><b>***</b>\n";
                }
            }
            return getMessage;
        }
    }
}
