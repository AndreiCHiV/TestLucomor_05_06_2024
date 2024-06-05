using System;

namespace Assets.Project_S
{
    public interface IReadOnlyCharacter
    {
        event Action<int> MaxHealthChanged;
        event Action<int> CurrentHealthChanged;

        string Name { get; }
        int MaxHealth { get; }
        int CurrentHelth { get; }
    }
}
