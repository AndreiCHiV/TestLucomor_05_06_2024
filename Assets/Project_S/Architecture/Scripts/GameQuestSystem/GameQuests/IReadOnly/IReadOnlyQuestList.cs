using System.Collections.Generic;

namespace Assets.Project_S
{
    public interface IReadOnlyQuestList
    {
        string Owner { get; }
        List<IReadOnlyQuest> GetQuestList();
    }
}
