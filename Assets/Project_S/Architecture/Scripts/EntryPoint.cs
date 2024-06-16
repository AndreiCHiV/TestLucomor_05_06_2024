using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenCharacterView _screenCharacterView;
        [SerializeField] private ScreenInventoryView _screenInventoryView;

        private const string CAT = "Lisa";
        private const string OCTI = "Wise";

        private CharactersService _charactersService;
        private ScreenCharacterController _screenCharacterController;

        private string _activeCharacter;
        private Vector3 _input;

        private InventoryService _inventoryService;
        private ScreenInventoryController _screenInventoryController;


        private void Awake()
        {
            
        }

        private void Start()
        {
            _charactersService = new CharactersService();
            _inventoryService = new InventoryService();

             

            CharacterData characterDataCat = CreateTestCharacter(CAT, "Player", 150);
            _charactersService.RegisterCharacters(characterDataCat);

            CharacterData characterDataOcti = CreateTestCharacter(OCTI, "NPC", 100);
            _charactersService.RegisterCharacters(characterDataOcti);

            InventoryGridData inventroyLisa = CreateTestInventory(CAT, 12);
            _inventoryService.RegisterInventory(inventroyLisa);

            InventoryGridData inventoryOcti = CreateTestInventory(OCTI, 10);
            _inventoryService.RegisterInventory(inventoryOcti);

            _screenCharacterController = new ScreenCharacterController(_charactersService, _screenCharacterView);
            _screenInventoryController = new ScreenInventoryController(_inventoryService, _screenInventoryView);

            _activeCharacter = CAT;
            _screenCharacterController.ActiveCharacter(CAT);
            _screenInventoryController.OpenInventory(CAT);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _screenCharacterController.ActiveCharacter(CAT);
                _screenInventoryController.OpenInventory(CAT);
                _activeCharacter = CAT;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenCharacterController.ActiveCharacter(OCTI);
                _screenInventoryController.OpenInventory(OCTI);
                _activeCharacter = OCTI;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                _inventoryService.AddItems(CAT, "Key", 1);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _inventoryService.AddItems(OCTI, "Hart", 1);
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

            if (!_screenCharacterView.GetCharacterView(_activeCharacter).IsMoving)
            {
                _input.x = Input.GetAxisRaw("Horizontal");
                _input.y = Input.GetAxisRaw("Vertical");
                if (_input != Vector3.zero)
                {
                    _screenCharacterView.GetCharacterView(_activeCharacter).Movement(_input);
                }

                _screenCharacterView.GetCharacterView(_activeCharacter).GetAnimation().SetBool("isMoving", _screenCharacterView.GetCharacterView(_activeCharacter).IsMoving);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(_activeCharacter);
                _screenCharacterView.GetCharacterView(_activeCharacter).Interact();
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
                maxWeigthInventory = maxWeigth,
                IsEmpty = true,
                slots = new List<InventorySlotData>()
                {
                    new QuestInventorySlotData("Key", 1, 0.1f),
                    new ArmorInventorySlotData("Sword", 1, 6f),
                    new HealthInventorySlotData("Herb", 1, 0.1f),
                }
            };

            return inventoryData;
        }

    }
}
