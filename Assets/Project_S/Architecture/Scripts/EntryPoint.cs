using UnityEngine;

namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] public CharacterView[] _charactersView;

        private void Start()
        {
            PlayerCharacterData playerData = new PlayerCharacterData
            {
                name = "Player",
                maxHealth = 100,
                currentHealth = 80
            };

            NPCCharacterData npcData = new NPCCharacterData()
            {
                name = "NPC",
                maxHealth = 100,
                currentHealth = 100
            };


            Player player = new Player(playerData);
            NPC npc = new NPC(npcData);

            _charactersView[0].Setup(player);
            _charactersView[1].Setup(npc);

        }
    }
}
