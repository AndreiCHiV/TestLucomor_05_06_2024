using System;
using System.Collections;
using UnityEngine;

namespace Assets.Project_S
{
    public abstract class Character : IReadOnlyCharacter
    {
        public event Action<int> MaxHealthChanged;
        public event Action<int> CurrentHealthChanged;
        public event Action<Vector3> PositionCharacterChanged;

        protected CharacterData _characterData;
        protected Vector3 _positionCharacter;

        public Character(CharacterData characterData)
        {
            _characterData = characterData;
        }

        public string Name
        {
            get => _characterData.characterName;
            set => _characterData.characterName = value;
        }

        public string TagCharacter
        {
            get => _characterData.characterTag;
            set => _characterData.characterTag = value;
        }

        public Vector3 PositionCharacter
        {
            get => _positionCharacter;
            set
            {
                if (_positionCharacter != value)
                {
                    _positionCharacter = value;

                    _characterData.positionCharacter_X = value.x;
                    _characterData.positionCharacter_Y = value.y;
                    _characterData.positionCharacter_Z = value.z;

                    //Debug.Log(_positionCharacter);

                    PositionCharacterChanged?.Invoke(_positionCharacter);
                }
            }
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


        public int CurrentHealth
        {
            get => _characterData.currentHealth;
            set
            {
                if (_characterData.currentHealth != value)
                {
                    _characterData.currentHealth = value;
                    CurrentHealthChanged?.Invoke(value);
                }
                if (_characterData.maxHealth <= _characterData.currentHealth)
                {
                    _characterData.currentHealth = _characterData.maxHealth;
                    CurrentHealthChanged?.Invoke(_characterData.maxHealth);
                }
                if (_characterData.currentHealth <= 0)
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



        public void SetPositionCharacter(Vector3 positionCharacter)
        {
            PositionCharacter = positionCharacter;
        }






        public string TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            return $"The Character received the damage amount of {damage} units. The Health: {CurrentHealth}";
        }

        public string Treatment()
        {
            CurrentHealth += 10;

            return $"The character has been cured by 10 units.The Health: {CurrentHealth}";
        }
    }
}
