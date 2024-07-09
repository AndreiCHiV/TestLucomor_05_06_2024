using System;

namespace Assets.Project_S
{
    [Serializable]
    public abstract class CharacterData
    {
        public string characterName;
        public string characterTag;
        public int characterID;

        public int maxHealth;
        public int currentHealth;

        public int currentDialogueID;

        public float positionCharacter_X;
        public float positionCharacter_Y;
        public float positionCharacter_Z;

        public CharacterData(string name, string tag,int id, int health, int currentDialogueId)
        {
            characterName = name;
            characterTag = tag;
            characterID = id;
            maxHealth = health;
            currentHealth = health;
            currentDialogueID = currentDialogueId;
        }

        
    }

    [Serializable]
    public class PlayerCharacterData : CharacterData
    {
        public PlayerCharacterData(string name, string tag, int id, int health, int currentDialogueId) : base(name, tag, id, health, currentDialogueId) { }
    }

    [Serializable]
    public class NPCCharacterData : CharacterData
    {
        public NPCCharacterData(string name, string tag, int id, int health,int currentDialogueId) : base(name, tag, id, health, currentDialogueId) { }
    }
}
