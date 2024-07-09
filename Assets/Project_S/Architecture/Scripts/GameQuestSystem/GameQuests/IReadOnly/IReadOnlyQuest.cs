using System;

namespace Assets.Project_S
{
    public interface IReadOnlyQuest
    {
        int QuestID { get; }
        string NameQuest { get; }
        bool CompletedQuest { get; }
        string GetMessages();
    }
}
