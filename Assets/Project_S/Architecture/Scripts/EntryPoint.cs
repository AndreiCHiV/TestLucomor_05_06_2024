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

        [SerializeField] private TextAsset _inkJSON_101000;
        [SerializeField] private TextAsset _inkJSON_101001;
        [SerializeField] private TextAsset _inkJSON_102000;
        [SerializeField] private TextAsset _inkJSON_102001;
        [SerializeField] private TextAsset _inkJSON_102002;
        [SerializeField] private TextAsset _inkJSON_103000;
        [SerializeField] private TextAsset _inkJSON_103001;


        private const string CAT = "Lisa";
        private const string WISE = "Wise";
        private const string RICA = "Rica";
        private const string WOLF = "Wolf";

        private ScreenCharacterController _screenCharacterController;
        private ScreenInventoryController _screenInventoryController;
        private ScreenDialogueCharacterController _screenDialogueCharacterController;
        private ScreenQuestController _screenQuestController;

        private string _activeCharacter;
        private Vector3 _input;

        private List<string> questMessageWise_0 = new List<string>()
        {
            "Виз не сидится на попе и она опять сходит с ума! Ей нужно две монеты для её безумных экспериментов.",
            "Волчара сказал что одна монетка валяется где-то неподалёку, чтож надо порыться в траве.",
            "Я пошарилась неподалёку и нашла одну монету.",
            "Одна из монет была у мерзкой девчёнки, как её там... Ааа, не важно, вобщем она теперь у меня!"
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

        public DialogueCharacterService DialogueCharacterService => _dialogueCharacterService;
        public QuestService QuestService => _questService;
        public InventoryService InventoryService => _inventoryService;
        public ScreenDialogueCharacterView ScreenDialogueCharacterView => _screenDialogueCharacterView;
        public string ActiveCharacter => _activeCharacter;

        private void Start()
        {
            _charactersService = new CharactersService();
            _inventoryService = new InventoryService();
            _dialogueCharacterService = new DialogueCharacterService();
            _questService = new QuestService();



            CharacterData characterDataCat = CreateTestCharacter(CAT, "Player", 240, 100000);
            _charactersService.RegisterCharacters(characterDataCat);

            CharacterData characterDataWise = CreateTestCharacter(WISE, "NPC", 90, 101000);
            _charactersService.RegisterCharacters(characterDataWise);

            CharacterData characterDataRica = CreateTestCharacter(RICA, "NPC", 50, 102000);
            _charactersService.RegisterCharacters(characterDataRica);

            CharacterData characterDataWolf = CreateTestCharacter(WOLF, "NPC", 50, 103000);
            _charactersService.RegisterCharacters(characterDataWolf);

            InventoryGridData inventroyLisa = CreateTestInventory(CAT, 12);
            _inventoryService.RegisterInventory(inventroyLisa);

            InventoryGridData inventoryOcti = CreateTestInventory(WISE, 10);
            _inventoryService.RegisterInventory(inventoryOcti);



            DialogueData dialogueDataWise_0 = new DialogueData()
            {
                inkJSON = _inkJSON_101000,
                dataDialogueID = 101000
            };
            DialogueData dialogueDataWise_1 = new DialogueData()
            {
                inkJSON = _inkJSON_101001,
                dataDialogueID = 101001
            };
            DialogueCharacterData dialogueCharacterDataWise = new DialogueCharacterData()
            {
                owner = "Wise"
            };

            DialogueData dialogueDataRica_0 = new DialogueData()
            {
                inkJSON = _inkJSON_102000,
                dataDialogueID = 102000
            };
            DialogueData dialogueDataRica_1 = new DialogueData()
            {
                inkJSON = _inkJSON_102001,
                dataDialogueID = 102001
            };
            DialogueCharacterData dialogueCharacterDataRica = new DialogueCharacterData()
            {
                owner = "Rica"
            };

            DialogueData dialogueDataWolf_0 = new DialogueData()
            {
                inkJSON = _inkJSON_103000,
                dataDialogueID = 103000
            };
            DialogueData dialogueDataWolf_1 = new DialogueData()
            {
                inkJSON = _inkJSON_103001,
                dataDialogueID = 103001
            };
            DialogueCharacterData dialogueCharacterDataWolf = new DialogueCharacterData()
            {
                owner = "Wolf"
            };


            DialogueData[] dialoguesDataRica = new DialogueData[] { dialogueDataRica_0, dialogueDataRica_1 };
            DialogueData[] dialoguesDataWise = new DialogueData[] { dialogueDataWise_0, dialogueDataWise_1 };
            DialogueData[] dialoguesDataWolf = new DialogueData[] { dialogueDataWolf_0, dialogueDataWolf_1 };

            _dialogueCharacterService.RegistrationDialogueCharacter(dialogueCharacterDataWise, dialoguesDataWise);
            _dialogueCharacterService.RegistrationDialogueCharacter(dialogueCharacterDataRica, dialoguesDataRica);
            _dialogueCharacterService.RegistrationDialogueCharacter(dialogueCharacterDataWolf, dialoguesDataWolf);



            QuestData questDataWise_0 = new QuestData()
            {
                questID = 12,
                nameQuest = "Виз опять чё-то надо!",
                questMessage = questMessageWise_0
            };

            //ShowQuestMessage(questDataWise_0);

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

            _questService.RegisterQuests(allquestList);

            _screenCharacterController = new ScreenCharacterController(_charactersService, _screenCharacterView);
            _screenInventoryController = new ScreenInventoryController(_inventoryService, _screenInventoryView);
            _screenDialogueCharacterController = new ScreenDialogueCharacterController(_dialogueCharacterService, _screenDialogueCharacterView);
            _screenQuestController = new ScreenQuestController(_questService, _screenQuestView);

            _activeCharacter = CAT;
            _screenCharacterController.ActiveCharacter(_activeCharacter);
            _screenInventoryController.OpenInventory(_activeCharacter);
            _screenQuestController.OpenCharacterQuest();
        }

        private void ShowQuestMessage(QuestData questDataWise_0)
        {
            foreach (string message in questDataWise_0.questMessage)
            {
                Debug.Log(message);
            }
        }

        private void Update()
        {
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

                    if (character != null && character.Name != "Lisa")
                    {
                        _screenCharacterView.GetCharacterView(_activeCharacter).IsMoving = true;
                        _screenDialogueCharacterController.EnterDialogueCharacter(character, _screenCharacterView.GetCharacterView(_activeCharacter));
                    }
                    else
                        Debug.Log("Not found character!");
                }

            }

            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    _activeCharacter = CAT;
            //    _screenCharacterController.ActiveCharacter(_activeCharacter);
            //    _screenInventoryController.OpenInventory(_activeCharacter);
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    _activeCharacter = OCTI;
            //    _screenCharacterController.ActiveCharacter(_activeCharacter);
            //    _screenInventoryController.OpenInventory(_activeCharacter);
            //}

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

        private CharacterData CreateTestCharacter(string name, string tag, int health, int currentDialogueId)
        {
            CharacterData characterData;

            if (tag == "Player")
            {
                characterData = new PlayerCharacterData(name, tag, health, currentDialogueId);
            }
            else if (tag == "NPC")
            {
                characterData = new NPCCharacterData(name, tag, health, currentDialogueId);
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
