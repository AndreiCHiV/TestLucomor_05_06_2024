using System;

namespace Assets.Project_S
{
    [Serializable]
    public abstract class CharacterData
    {
        public string name;
        public int maxHealth;
        public int currentHealth;
    }

    [Serializable]
    public class PlayerCharacterData : CharacterData
    {

    }

    [Serializable]
    public class NPCCharacterData : CharacterData
    {

    }
}
