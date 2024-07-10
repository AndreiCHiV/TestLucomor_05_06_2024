using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class RemoveItemTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "removeItem";

        public string NameTag => NAMETAG;

        public void Calling(string valueTag)
        {
            string[] keyTag = valueTag.Split("_");
            bool isCompleted;

            if (keyTag.Length != 4)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }

            string nameItem = keyTag[0].Trim();
            int amountItem = int.Parse(keyTag[1].Trim());
            string name = keyTag[2].Trim();
            int dialogueId = int.Parse(keyTag[3].Trim());

            isCompleted = _entryPoint.InventoryService.RemoveItems(_entryPoint.ActiveCharacter, nameItem, amountItem);

            if (isCompleted == false)
            {
                IReadOnlyDialogue dialogueNameID = _entryPoint.DialogueCharacterService.GetDialogueCharacterId(_entryPoint.GetPlayerNameCharacter(), 100000);

                if (dialogueNameID != null)
                {
                    _entryPoint.ScreenDialogueCharacterView.EnterDialogueMode(dialogueNameID.GetDialogue());
                }
                else
                    Debug.LogError("Диалог не найден!");
            }
            else
            {
                IReadOnlyDialogue dialogueNameID = _entryPoint.DialogueCharacterService.GetDialogueCharacterId(name, dialogueId);

                if (dialogueNameID != null)
                {
                    _entryPoint.ScreenDialogueCharacterView.EnterDialogueMode(dialogueNameID.GetDialogue());
                }
                else
                    Debug.LogError("Диалог не найден!");
            }
        }
    }
}
