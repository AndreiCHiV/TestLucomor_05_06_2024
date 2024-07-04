using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public interface IReadOnlyQuestList
    {
        event Action<int> AddQuestChanged;
        string Owner { get; }
        List<IReadOnlyQuest> GetQuestList();
    }
}
