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

        //Контроль кнопок QuestList
        [SerializeField] private OpenCurrentAndFinishQuests _openCurrentAndFinishQuests;

        //Character Data
        [SerializeField] private WiseCharacter _wiseCharacter;
        [SerializeField] private RicaCharacter _ricaCharacter;
        [SerializeField] private WolfCharacter _wolfCharacter;
        [SerializeField] private PlayerCharacter _playerCharacter;

        //Item Data on the Field
        [SerializeField] private OldCoinItem _oldCoinItem;

        private ScreenCharacterController _screenCharacterController;
        private ScreenInventoryController _screenInventoryController;
        private ScreenDialogueCharacterController _screenDialogueCharacterController;
        private ScreenQuestController _screenQuestController;


        private string _activeCharacter;
        private Vector3 _input;
        private bool isEndMove;


        private CharactersService _charactersService;
        private InventoryService _inventoryService;
        private DialogueCharacterService _dialogueCharacterService;
        private QuestService _questService;

        public CharactersService CharactersService => _charactersService;
        public InventoryService InventoryService => _inventoryService;
        public DialogueCharacterService DialogueCharacterService => _dialogueCharacterService;
        public QuestService QuestService => _questService;

        public ScreenDialogueCharacterView ScreenDialogueCharacterView => _screenDialogueCharacterView;
        public string ActiveCharacter => _activeCharacter;


        private void Start()
        {
            _charactersService = new CharactersService();
            _inventoryService = new InventoryService();
            _dialogueCharacterService = new DialogueCharacterService();
            _questService = new QuestService();


            CharacterData characterDataCat = CreateTestCharacter(_playerCharacter.GetName(), "Player", 100, 240, 100000);
            _charactersService.RegisterCharacters(characterDataCat);

            CharacterData characterDataWise = CreateTestCharacter(_wiseCharacter.GetName(), "NPC", 101, 90, 101000);
            _charactersService.RegisterCharacters(characterDataWise);

            CharacterData characterDataRica = CreateTestCharacter(_ricaCharacter.GetName(), "NPC", 102, 50, 102000);
            _charactersService.RegisterCharacters(characterDataRica);

            CharacterData characterDataWolf = CreateTestCharacter(_wolfCharacter.GetName(), "NPC", 103, 50, 103000);
            _charactersService.RegisterCharacters(characterDataWolf);

            CharacterData characterDataOldCoin = CreateTestCharacter(_oldCoinItem.GetName(), "NPC", 500, 50, 500000);
            _charactersService.RegisterCharacters(characterDataOldCoin);

            InventoryGridData inventroyLisa = CreateTestInventory(_playerCharacter.GetName(), 12);
            _inventoryService.RegisterInventory(inventroyLisa);

            InventoryGridData inventoryOcti = CreateTestInventory(_wiseCharacter.GetName(), 10);
            _inventoryService.RegisterInventory(inventoryOcti);


            _dialogueCharacterService.RegistrationDialogueCharacter(_wiseCharacter.InitializationDialogueCharacter(), _wiseCharacter.InitializationDialogueData());
            _dialogueCharacterService.RegistrationDialogueCharacter(_ricaCharacter.InitializationDialogueCharacter(), _ricaCharacter.InitializationDialogueData());
            _dialogueCharacterService.RegistrationDialogueCharacter(_wolfCharacter.InitializationDialogueCharacter(), _wolfCharacter.InitializationDialogueData());
            _dialogueCharacterService.RegistrationDialogueCharacter(_oldCoinItem.InitializationDialogueCharacter(), _oldCoinItem.InitializationDialogueData());
            _dialogueCharacterService.RegistrationDialogueCharacter(_playerCharacter.InitializationDialogueCharacter(), _playerCharacter.InitializationDialogueData());


            List<QuestListData> allquestList = new List<QuestListData>()
            {
                _wiseCharacter.InitializationQuests()
            };

            _questService.RegisterQuests(allquestList);

            _screenCharacterController = new ScreenCharacterController(_charactersService, _screenCharacterView);
            _screenInventoryController = new ScreenInventoryController(_inventoryService, _screenInventoryView);
            _screenDialogueCharacterController = new ScreenDialogueCharacterController(_dialogueCharacterService, _screenDialogueCharacterView);
            _screenQuestController = new ScreenQuestController(_questService, _screenQuestView);

            _activeCharacter = _playerCharacter.GetName();
            _screenCharacterController.ActiveCharacter(_activeCharacter);
            _screenInventoryController.OpenInventory(_activeCharacter);
        }

        private void ShowQuestMessage(QuestData questDataWise_0)
        {
            foreach (var message in questDataWise_0.questMessage)
            {
                Debug.Log(message.message);
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

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (_screenCharacterView.GetCharacterView(_activeCharacter).IsPause == false)
                    {
                        _screenQuestView.gameObject.SetActive(true);
                        _screenQuestController.OpenCharacterQuest();
                        _openCurrentAndFinishQuests.ActiveDefaultListQuests();
                        _screenCharacterView.GetCharacterView(_activeCharacter).IsPause = true;
                        return;
                    }
                    if (_screenCharacterView.GetCharacterView(_activeCharacter).IsPause == true)
                    {
                        _screenQuestView.gameObject.SetActive(false);
                        _screenCharacterView.GetCharacterView(_activeCharacter).IsPause = false;
                        return;
                    }
                }

                if (Input.GetKeyDown(KeyCode.F) && !_screenCharacterView.GetCharacterView(_activeCharacter).IsPause)
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


            if (Input.GetKeyDown(KeyCode.D) && _screenCharacterView.GetCharacterView(_activeCharacter).IsPause)
            {
                OpenCurrentAndFinishQuests();
            }
            if (Input.GetKeyDown(KeyCode.A) && _screenCharacterView.GetCharacterView(_activeCharacter).IsPause)
            {
                OpenCurrentAndFinishQuests();
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

        private CharacterData CreateTestCharacter(string name, string tag, int id, int health, int currentDialogueId)
        {
            CharacterData characterData;

            if (tag == "Player")
            {
                characterData = new PlayerCharacterData(name, tag, id, health, currentDialogueId);
            }
            else if (tag == "NPC")
            {
                characterData = new NPCCharacterData(name, tag, id, health, currentDialogueId);
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
        private void OpenCurrentAndFinishQuests()
        {
            //Можно перенесети в OpenCurrentAndFinishQuests
            if (_openCurrentAndFinishQuests.ActiveListQuest)
            {
                _screenQuestController.OpenCompletedQuest();
                _openCurrentAndFinishQuests.ChangeActiveListQuests();
            }
            else
            {
                _screenQuestController.OpenCharacterQuest();
                _openCurrentAndFinishQuests.ChangeActiveListQuests();
            }
        }

        public string GetPlayerNameCharacter()
        {
            return _playerCharacter.GetName();
        }

    }
}
