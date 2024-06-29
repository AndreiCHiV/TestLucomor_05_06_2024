﻿using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Project_S
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenCharacterView _screenCharacterView;
        [SerializeField] private ScreenInventoryView _screenInventoryView;
        [SerializeField] private ScreenDialogueCharacterView _screenDialogueCharacterView;

        [SerializeField] private TextAsset _inkJSON;


        private const string CAT = "Lisa";
        private const string OCTI = "Wise";

        private ScreenCharacterController _screenCharacterController;
        private ScreenInventoryController _screenInventoryController;
        private ScreenDialogueCharacterController _screenDialogueCharacterController;

        private string _activeCharacter;
        private Vector3 _input;

        private CharactersService _charactersService;
        private InventoryService _inventoryService;
        private DialogueCharacterService _dialogueCharacterService;

        private void Start()
        {
            _charactersService = new CharactersService();
            _inventoryService = new InventoryService();
            _dialogueCharacterService = new DialogueCharacterService();



            CharacterData characterDataCat = CreateTestCharacter(CAT, "Player", 240);
            _charactersService.RegisterCharacters(characterDataCat);

            CharacterData characterDataOcti = CreateTestCharacter(OCTI, "NPC", 90);
            _charactersService.RegisterCharacters(characterDataOcti);

            InventoryGridData inventroyLisa = CreateTestInventory(CAT, 12);
            _inventoryService.RegisterInventory(inventroyLisa);

            InventoryGridData inventoryOcti = CreateTestInventory(OCTI, 10);
            _inventoryService.RegisterInventory(inventoryOcti);



            DialogueData dialogueDataOcti = new DialogueData()
            {
                inkJSON = _inkJSON,
                dataDialogueID = 1
            };

            DialogueCharacterData dialogueCharacterDataOcti = new DialogueCharacterData()
            {
                owner = "Wise"
            };


            _dialogueCharacterService.RegistrationDialogueCharacter(dialogueCharacterDataOcti);
            _dialogueCharacterService.AddDialogue("Wise", dialogueDataOcti);

            _screenCharacterController = new ScreenCharacterController(_charactersService, _screenCharacterView);
            _screenInventoryController = new ScreenInventoryController(_inventoryService, _screenInventoryView);
            _screenDialogueCharacterController = new ScreenDialogueCharacterController(_dialogueCharacterService, _screenDialogueCharacterView);



            _activeCharacter = CAT;
            _screenCharacterController.ActiveCharacter(_activeCharacter);
            _screenInventoryController.OpenInventory(_activeCharacter);
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
