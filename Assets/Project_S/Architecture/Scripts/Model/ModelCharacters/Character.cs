using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class Character
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
            set
            {
                if (_characterData.maxHealth != value)
                {
                    _characterData.maxHealth = value;
                    MaxHealthChanged?.Invoke(_characterData.maxHealth);
                }
            }
        }
        public int CurrentHelth
        {
            get => _characterData.currentHealth;
            set
            {
                if(_characterData.currentHealth != value)
                {
                    _characterData.currentHealth = value;
                    CurrentHealthChanged?.Invoke(value);
                }
                else if (_characterData.maxHealth <= _characterData.currentHealth)
                {
                    _characterData.currentHealth = _characterData.maxHealth;
                    CurrentHealthChanged?.Invoke(_characterData.maxHealth);
                }
                else if (_characterData.currentHealth <= 0)
                {
                    _characterData.currentHealth = 0;
                    CharacterIsDead();
                    CurrentHealthChanged?.Invoke(_characterData.currentHealth);
                }
            }
        }

        private void CharacterIsDead()
        {
            Debug.Log($"{Name} is dead!");
        }
    }
}
