using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class Quest : IReadOnlyQuest
    {
        public event Action<byte> currentQuestChanged;

        private readonly QuestData _questData;
        private byte _currentValueQuest;
        private byte _completedValueQuest;

        public Quest(QuestData questData)
        {
            _questData = questData;
            _currentValueQuest = 0;
            _completedValueQuest = Convert.ToByte(questData.questMessage.Count - 1);
        }

        public QuestData QuestData => _questData;

        public int QuestID
        {
            get => _questData.questID;
            set => _questData.questID = value;
        }

        public string NameQuest
        {
            get => _questData.nameQuest;
        }

        public byte ComplitedQuest
        {
            get => _completedValueQuest;
            set => _completedValueQuest = value;
        }

        public byte CurrentQuest
        {
            get => _currentValueQuest;
            set
            {
                if (_currentValueQuest != value)
                {
                    _currentValueQuest = value;
                    currentQuestChanged?.Invoke(value);
                }
            }
        }

        public string GetMessages()
        {
            string messages = "";

            for (int i = 0; i <= CurrentQuest; i++)
            {
                if (i == _completedValueQuest)
                {
                    messages += _questData.questMessage[i] + "\n\n<align=\"center\"><b>Конец задния!</b>\n\n";
                    return messages;
                }
                messages += _questData.questMessage[i] + "\n\n<align=\"center\"><b>***</b>\n\n";
            }

            return messages;
        }
    }
}
