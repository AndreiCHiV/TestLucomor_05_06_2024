using System;
using UnityEngine;


namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenCharacterView _screenView;

        private const string CAT = "Lisa";
        private const string OCTI = "Wise";

        private CharactersService _charactersService;
        private ScreenCharacterController _screenCharacterController;

        private string _activeCharacter;
        private Vector3 _input;

        private InventoryService _inventoryService;




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

            _inventoryService = new InventoryService();
            InventoryGridData inventroyLisa = CreateTestInventory(CAT, 12);
            _inventoryService.RegisterInventory(inventroyLisa);


            InventoryGridData inventoryOcti = CreateTestInventory(OCTI, 10);
            _inventoryService.RegisterInventory(inventoryOcti);


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





            if (Input.GetKeyDown(KeyCode.Z))
            {
                _inventoryService.AddItems(CAT, "Key", 2);
                int amount = _inventoryService.GetInventoy(CAT).GetInventorySlot("Key").Amount;
                Debug.Log(amount);

                _inventoryService.AddItems(OCTI, "Knife", 5);
                amount = _inventoryService.GetInventoy(OCTI).GetInventorySlot("Knife").Amount;
                Debug.Log(amount);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _inventoryService.RemoveItems(CAT, "Key", 1);
                _inventoryService.RemoveItems(OCTI, "Knife", 2);

                try
                {
                    int amount = _inventoryService.GetInventoy(CAT).GetInventorySlot("Key").Amount;
                    Debug.Log(amount);
                    amount = _inventoryService.GetInventoy(OCTI).GetInventorySlot("Knife").Amount;
                    Debug.Log(amount);

                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }

            }










            if (!_screenView.GetCharacterView(_activeCharacter).IsMoving)
            {
                _input.x = Input.GetAxisRaw("Horizontal");
                _input.y = Input.GetAxisRaw("Vertical");
                if (_input != Vector3.zero)
                {
                    _screenView.GetCharacterView(_activeCharacter).Movement(_input);
                }

                _screenView.GetCharacterView(_activeCharacter).GetAnimation().SetBool("isMoving", _screenView.GetCharacterView(_activeCharacter).IsMoving);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(_activeCharacter);
                _screenView.GetCharacterView(_activeCharacter).Interact();
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

        private InventoryGridData CreateTestInventory(string name, float maxWeigth)
        {
            InventoryGridData inventoryData = new InventoryGridData()
            {
                owner = name,
                maxWeigthInventory = maxWeigth
            };

            return inventoryData;
        }

    }
}
