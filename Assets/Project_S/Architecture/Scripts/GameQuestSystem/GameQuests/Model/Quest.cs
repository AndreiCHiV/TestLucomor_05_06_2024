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
        private bool _failedQuest;
        private List<string> _messages = new List<string>();

        public Quest(QuestData questData)
        {
            _questData = questData;
        }

        public QuestData QuestData => _questData;

        public bool CompletedQuest => _completedQuest;

        public bool FailedQuest => _failedQuest;

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
                    _failedQuest = quest.failedQuest;

                    ChangedMessageQuest?.Invoke();

                    return quest.messageChangeDialogueID;
                }
            }

            return null;
        }

        public string GetMessages()
        {
            string getMessage = "";

            Debug.Log(CompletedQuest);
            Debug.Log(FailedQuest);

            if (CompletedQuest)
            {
                for (int i = 0; i < _messages.Count; i++)
                {
                    if (i == _messages.Count - 1)
                    {
                        getMessage += _messages[i] + "\n\n<align=\"center\"><color=green><b>Задание выполнено!</b></color>";
                        return getMessage;
                    }

                    getMessage += _messages[i] + "\n<align=\"center\"><b>***</b>\n";
                }
            }
            else if (FailedQuest)
            {
                for (int i = 0; i < _messages.Count; i++)
                {
                    if (i == _messages.Count - 1)
                    {
                        getMessage += _messages[i] + "\n\n<align=\"center\"><color=red><b>Задание провалено!</b></color>";
                        return getMessage;
                    }

                    getMessage += _messages[i] + "\n<align=\"center\"><b>***</b>\n";
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
