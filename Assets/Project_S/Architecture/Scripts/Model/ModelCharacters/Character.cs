﻿using System;
using System.Collections;
using UnityEngine;

namespace Assets.Project_S
{
    public abstract class Character : IReadOnlyCharacter
    {
        public event Action<int> MaxHealthChanged;
        public event Action<int> CurrentHealthChanged;
        public event Action<Vector2> PositionCharacterChanged;

        protected CharacterData _characterData;

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
            get => _characterData.PositionCharacterData;
            set
            {
                if (_characterData.PositionCharacterData != value)
                {
                    _characterData.PositionCharacterData = value;
                    PositionCharacterChanged?.Invoke(_characterData.PositionCharacterData);
                }
            }
        }

        public bool IsMoving
        {
            get => _characterData.isMoving;
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

        //public IEnumerator Movement(Vector3 targetPos)
        //{
        //    Debug.Log(targetPos);

        //    _characterData.isMoving = true;
        //    while ((targetPos - PositionCharacter).sqrMagnitude > Mathf.Epsilon)
        //    {
        //        PositionCharacter = Vector3.MoveTowards(PositionCharacter, targetPos, _characterData.moveSpeed * Time.deltaTime);
        //        Debug.Log(PositionCharacter);

        //        yield return null;
        //    }

        //    PositionCharacter = targetPos;
        //    _characterData.isMoving = false;
        //}

    }
}
