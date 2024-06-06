using System;

namespace Assets.Project_S
{
    public interface IReadOnlyCharacter
    {
        event Action<int> MaxHealthChanged;
        event Action<int> CurrentHealthChanged;

        string Name { get; }
        string TagCharacter { get; }
        int MaxHealth { get; }
        int CurrentHealth { get; }

    }
}
