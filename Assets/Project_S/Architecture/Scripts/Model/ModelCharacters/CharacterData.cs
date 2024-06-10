using System;
using UnityEngine;

namespace Assets.Project_S
{
    [Serializable]
    public abstract class CharacterData
    {
        public string characterName;
        public string characterTag;
        public int maxHealth;
        public int currentHealth;

        public float positionCharacter_X;
        public float positionCharacter_Y;
        public float positionCharacter_Z;

        private Vector3 _positionCharacter = new Vector3();

        public CharacterData(string name, string tag, int health)
        {
            characterName = name;
            characterTag = tag;
            maxHealth = health;
            currentHealth = health;
        }

        public Vector3 PositionCharacterData
        {
            get
            {
                _positionCharacter.Set(positionCharacter_X, positionCharacter_Y, positionCharacter_Z);
                return _positionCharacter;
            }
            set
            {
                positionCharacter_X = value.x;
                positionCharacter_Y = value.y;
                positionCharacter_Z = value.z;
            }
        }
    }

    [Serializable]
    public class PlayerCharacterData : CharacterData
    {
        public PlayerCharacterData(string name, string tag, int health) : base(name, tag, health) { }
    }

    [Serializable]
    public class NPCCharacterData : CharacterData
    {
        public NPCCharacterData(string name, string tag, int health) : base(name, tag, health) { }
    }
}
