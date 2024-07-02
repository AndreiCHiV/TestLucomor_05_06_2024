using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class Quest : IReadOnlyQuest
    {
        public event Action<byte> currentQuestChanged;

        private readonly QuestData _questData;
        private byte _currentQuest;

        public Quest(QuestData questData)
        {
            _questData = questData;
            _currentQuest = 1;
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

        public byte CurrentQuest
        {
            get => _currentQuest;
            set
            {
                if (_currentQuest != value)
                {
                    _currentQuest = value;
                    currentQuestChanged?.Invoke(value);
                }
            }
        }

        public string GetMessages()
        {
            string messages = "";

            for (int i = 0; i < CurrentQuest; i++)
            {
                if (i == CurrentQuest - 1)
                {
                    messages += _questData.questMessage[i] + "\n\n<align=\"center\"><b>Конец задния!</b>\n\n";
                    return messages;
                }
                messages += _questData.questMessage[i] + "\n\n<align = \"center\"><b>***</b>\n\n";
            }

            return messages;
        }
    }
}
