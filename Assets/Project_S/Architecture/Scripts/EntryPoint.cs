using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] public CharacterView[] _charactersView;
        private CharactersService _charactersService;

        private void Start()
        {
            string cat = "Cat";
            string octi = "Octi";

            _charactersService = new CharactersService();

            CharacterData playerCharacterData = CreateTestCharacter(cat, "Player", 120);
            CharacterData npcCharacterData = CreateTestCharacter(octi, "NPC", 100);

            Character player = _charactersService.RegisterCharacters(playerCharacterData);
            Character npc = _charactersService.RegisterCharacters(npcCharacterData);



            _charactersView[0].Setup(player);
            _charactersView[1].Setup(npc);

            string message = _charactersService.TakeDamageCharacter(cat, 130);
            Debug.Log(message);
            message = _charactersService.TakeDamageCharacter(octi, 30);
            Debug.Log(message);
            message = _charactersService.TreatmentCharacter(cat);
            Debug.Log(message);
            message = _charactersService.TreatmentCharacter(octi);
            Debug.Log(message);
            _charactersView[0].Print();
            _charactersView[1].Print();

        }

        private CharacterData CreateTestCharacter(string name, string tag, int health)
        {
            CharacterData characterData;

            if (tag == "Player")
            {
                characterData = new PlayerCharacterData(name, tag, health);
            }
            else if (tag == "NPC")
            {
                characterData = new NPCCharacterData(name, tag, health);
            }
            else
            {
                throw new Exception($"The Tag with the name is missing!");
            }

            return characterData;
        }
    }
}
