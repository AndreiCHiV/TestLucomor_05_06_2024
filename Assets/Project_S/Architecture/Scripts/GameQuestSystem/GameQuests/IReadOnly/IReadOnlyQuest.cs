using System;

namespace Assets.Project_S
{
    public interface IReadOnlyQuest
    {
        event Action<byte> currentQuestChanged;

        int QuestID { get; }
        byte CurrentQuest { get; }
        string NameQuest { get; }

        string GetMessages();
    }
}
