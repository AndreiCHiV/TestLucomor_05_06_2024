using System;

namespace Assets.Project_S
{
    public class Character : IReadOnlyCharacter
    {
        public event Action<int> MaxHealthChanged;
        public event Action<int> CurrentHealthChanged;

        protected CharacterData _characterData;

        public Character(CharacterData characterData)
        {
            _characterData = characterData;
        }

        public string Name
        {
            get => _characterData.name;
            set => _characterData.name = value;
        }
        public int MaxHealth
        {
            get => _characterData.maxHealth;
            set => _characterData.maxHealth = value;
        }
        public int CurrentHelth
        {
            get => _characterData.currenHealth;
            set
            {
                if (_characterData.maxHealth <= _characterData.currenHealth)
                    _characterData.currenHealth = _characterData.maxHealth;
                else
                    _characterData.currenHealth = value;

            }


        }
    }
}
