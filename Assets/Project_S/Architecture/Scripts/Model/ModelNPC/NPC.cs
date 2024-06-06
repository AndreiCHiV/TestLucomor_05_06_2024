using UnityEngine;

namespace Assets.Project_S
{
    public class NPC : Character, IReadOnlyNPC
    {
        private NPCCharacterData _NPCCharacterData;

        public NPC(NPCCharacterData characterData) : base(characterData) 
        {
            _NPCCharacterData = (NPCCharacterData)_characterData;
        }
    }
}
