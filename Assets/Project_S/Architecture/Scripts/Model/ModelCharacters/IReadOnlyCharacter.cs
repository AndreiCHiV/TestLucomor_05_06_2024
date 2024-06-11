using System;
using UnityEngine;

namespace Assets.Project_S
{
    public interface IReadOnlyCharacter
    {
        event Action<int> MaxHealthChanged;
        event Action<int> CurrentHealthChanged;
        event Action<Vector3> PositionCharacterChanged;

        string Name { get; }
        string TagCharacter { get; }
        int MaxHealth { get; }
        int CurrentHealth { get; }
        Vector3 PositionCharacter { get; }

        void SetPositionCharacter(Vector3 positionCharacter);

    }
}
