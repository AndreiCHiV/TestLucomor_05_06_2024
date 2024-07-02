using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenCharacterView _screenCharacterView;
        [SerializeField] private ScreenInventoryView _screenInventoryView;
        [SerializeField] private ScreenDialogueCharacterView _screenDialogueCharacterView;
        [SerializeField] private ScreenQuestView _screenQuestView;

        [SerializeField] private TextAsset _inkJSON;


        private const string CAT = "Lisa";
        private const string OCTI = "Wise";

        private ScreenCharacterController _screenCharacterController;
        private ScreenInventoryController _screenInventoryController;
        private ScreenDialogueCharacterController _screenDialogueCharacterController;
        private ScreenQuestController _screenQuestController;

        private string _activeCharacter;
        private Vector3 _input;

        private List<string> questMessageWise_0 = new List<string>()
        {
            "Виз не сидится на попе и она опять сходит с ума! Ей нужно крыло фенекса для её безумных экспериментов."
        };
        private List<string> questMessageWise_1 = new List<string>()
        {
            "Виз просто спятила!"
        };
        private List<string> questMessageWise_2 = new List<string>()
        {
            "Эксперимент провалился, Виз в психушке!"
        };

        private CharactersService _charactersService;
        private InventoryService _inventoryService;
        private DialogueCharacterService _dialogueCharacterService;
        private QuestService _questService;

        private void Start()
        {
            _charactersService = new CharactersService();
            _inventoryService = new InventoryService();
            _dialogueCharacterService = new DialogueCharacterService();
            _questService = new QuestService();



            CharacterData characterDataCat = CreateTestCharacter(CAT, "Player", 240);
            _charactersService.RegisterCharacters(characterDataCat);

            CharacterData characterDataOcti = CreateTestCharacter(OCTI, "NPC", 90);
            _charactersService.RegisterCharacters(characterDataOcti);

            InventoryGridData inventroyLisa = CreateTestInventory(CAT, 12);
            _inventoryService.RegisterInventory(inventroyLisa);

            InventoryGridData inventoryOcti = CreateTestInventory(OCTI, 10);
            _inventoryService.RegisterInventory(inventoryOcti);



            DialogueData dialogueDataWise = new DialogueData()
            {
                inkJSON = _inkJSON,
                dataDialogueID = 1
            };

            DialogueCharacterData dialogueCharacterDataWise = new DialogueCharacterData()
            {
                owner = "Wise"
            };


            _dialogueCharacterService.RegistrationDialogueCharacter(dialogueCharacterDataWise);
            _dialogueCharacterService.AddDialogue("Wise", dialogueDataWise);


            QuestData questDataWise_0 = new QuestData()
            {
                questID = 0,
                nameQuest = "Виз опять чё-то надо!",
                questMessage = questMessageWise_0
            };
            QuestData questDataWise_1 = new QuestData()
            {
                questID = 1,
                nameQuest = "С Виз что-то не так!",
                questMessage = questMessageWise_1
            };
            QuestData questDataWise_2 = new QuestData()
            {
                questID = 2,
                nameQuest = "Эксперимент Виз.",
                questMessage = questMessageWise_2
            };

            QuestListData dataWise = new QuestListData()
            {
                isEmpty = true,
                owner = "Wise",
                questDatas = new List<QuestData>()
                {
                    questDataWise_0,
                    questDataWise_1,
                    questDataWise_2
                }
            };

            List<QuestListData> allquestList = new List<QuestListData>()
            {
                dataWise
            };

            _questService.RegisterQuestsCharacter(allquestList);

            _screenCharacterController = new ScreenCharacterController(_charactersService, _screenCharacterView);
            _screenInventoryController = new ScreenInventoryController(_inventoryService, _screenInventoryView);
            _screenDialogueCharacterController = new ScreenDialogueCharacterController(_dialogueCharacterService, _screenDialogueCharacterView);
            _screenQuestController = new ScreenQuestController(_questService, _screenQuestView);


            _activeCharacter = CAT;
            _screenCharacterController.ActiveCharacter(_activeCharacter);
            _screenInventoryController.OpenInventory(_activeCharacter);
            _screenQuestController.OpenQuest();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _activeCharacter = CAT;
                _screenCharacterController.ActiveCharacter(_activeCharacter);
                _screenInventoryController.OpenInventory(_activeCharacter);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _activeCharacter = OCTI;
                _screenCharacterController.ActiveCharacter(_activeCharacter);
                _screenInventoryController.OpenInventory(_activeCharacter);
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

                if (Input.GetKeyDown(KeyCode.F))
                {

                    CharacterView character = _screenCharacterView.GetCharacterView(_activeCharacter).Interact();

                    if (character != null)
                    {
                        _screenCharacterView.GetCharacterView(_activeCharacter).IsMoving = true;
                        _screenDialogueCharacterController.EnterDialogueCharacter(character, _screenCharacterView.GetCharacterView(_activeCharacter));
                    }
                    else
                        Debug.Log("Not found character!");
                }
            }





            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    IReadOnlyInventoryGrid inventoryCAT = _inventoryService.GetInventoy(CAT);
            //    IReadOnlyInventoryGrid inventoryOCTI = _inventoryService.GetInventoy(OCTI);
            //    List<IReadOnlyInventorySlot> list_C = inventoryCAT.GetSlots();
            //    List<IReadOnlyInventorySlot> list_O = inventoryOCTI.GetSlots();

            //    foreach (var item in list_C)
            //    {
            //        Debug.Log(item.Name);
            //        Debug.Log(item.Amount);
            //        Debug.Log(item.Weigth);
            //    }
            //    foreach (var item in list_O)
            //    {
            //        Debug.Log(item.Name);
            //        Debug.Log(item.Amount);
            //        Debug.Log(item.Weigth);
            //    }
            //}

            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    int damage = UnityEngine.Random.Range(0, 20);
            //    string takeDamage = _charactersService.TakeDamageCharacter(_activeCharacter, damage);
            //    Debug.Log(takeDamage);
            //}
            //if (Input.GetKeyDown(KeyCode.R))
            //{
            //    string healthCharacter = _charactersService.TreatmentCharacter(_activeCharacter);
            //    Debug.Log(healthCharacter);
            //}

            //if (Input.GetKeyDown(KeyCode.Z))
            //{
            //    _inventoryService.AddItems(CAT, "Key", 1);
            //    _inventoryService.AddItems(OCTI, "Hart", 1);
            //}



            //if (Input.GetKeyDown(KeyCode.X))
            //{
            //    _inventoryService.RemoveItems(CAT, "Key", 1);
            //}

            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    _inventoryService.RemoveItems(OCTI, "Hart", 1);
            //}

            //if (Input.GetKeyDown(KeyCode.V))
            //{
            //    _inventoryService.RemoveItems(CAT, "Knife", 1);
            //}

            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    _inventoryService.RemoveItems(OCTI, "Knife", 1);
            //}

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
