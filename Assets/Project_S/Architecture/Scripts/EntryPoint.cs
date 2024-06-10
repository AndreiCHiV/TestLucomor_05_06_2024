using System;
using UnityEngine;


namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenView;

        private const string CAT = "Cat";
        private const string OCTI = "Octi";

        private CharactersService _charactersService;
        private ScreenCharacterController _screenCharacterController;

        private string _activeCharacter;


        private void Start()
        {
            _charactersService = new CharactersService();

            CharacterData characterDataCat = CreateTestCharacter(CAT, "Player", 150);
            _charactersService.RegisterCharacters(characterDataCat);

            CharacterData characterDataOcti = CreateTestCharacter(OCTI, "NPC", 100);
            _charactersService.RegisterCharacters(characterDataOcti);

            _screenCharacterController = new ScreenCharacterController(_charactersService, _screenView);

            _screenCharacterController.ActiveCharacter(CAT);
            _activeCharacter = CAT;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _screenCharacterController.ActiveCharacter(CAT);
                _activeCharacter = CAT;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenCharacterController.ActiveCharacter(OCTI);
                _activeCharacter = OCTI;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                int damage = UnityEngine.Random.Range(0, 20);
                string takeDamage = _charactersService.TakeDamageCharacter(_activeCharacter, damage);
                Debug.Log(takeDamage);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                string healthCharacter = _charactersService.TreatmentCharacter(_activeCharacter);
                Debug.Log(healthCharacter);
            }



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
