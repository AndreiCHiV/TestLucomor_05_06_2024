using System;

namespace Assets.Project_S
{
    public interface IReadOnlyQuest
    {
        event Action ChangedMessageQuest;
        int QuestID { get; }
        string NameQuest { get; }
        bool CompletedQuest { get; }
        string GetMessages();
    }
}
