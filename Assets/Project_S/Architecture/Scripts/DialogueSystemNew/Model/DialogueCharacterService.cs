using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueCharacterService
    {
        private readonly Dictionary<string, DialoguesCharacter> _dialogueCharacterMap = new Dictionary<string, DialoguesCharacter>();

        public DialoguesCharacter RegistrationDialogueCharacter(DialogueCharacterData dialoguesCharacterData, DialogueData dialogueData)
        {
            DialoguesCharacter dialoguesCharacter = new DialoguesCharacter(dialoguesCharacterData);
            _dialogueCharacterMap[dialoguesCharacter.Owner] = dialoguesCharacter;
            AddDialogue(dialoguesCharacterData.owner, dialogueData);
            return dialoguesCharacter;
        }
        public void RegistrationDialogueCharacter(DialogueCharacterData dialoguesCharacterData, DialogueData[] dialoguesData)
        {
            DialoguesCharacter dialoguesCharacter = new DialoguesCharacter(dialoguesCharacterData);
            _dialogueCharacterMap[dialoguesCharacter.Owner] = dialoguesCharacter;

            foreach (DialogueData dialogueData in dialoguesData)
            {
                AddDialogue(dialoguesCharacterData.owner, dialogueData);
                //Debug.Log($"Диалог {dialogueData.dataDialogueID} базу диалогов {dialoguesCharacterData.owner} добавлен!");
            }
        }

        public void AddDialogue(string owner, DialogueData dialogueData)
        {
            _dialogueCharacterMap[owner].AddDialogueStory(dialogueData);
        }

        public IReadOnlyDialogueCharacter GetDialoguesCharacter(string owner)
        {
            return _dialogueCharacterMap[owner];
        }
        public IReadOnlyDialogue GetDialogueCharacterId(string owner, int dialogueId)
        {
            return _dialogueCharacterMap[owner].GetDialogueStory(dialogueId);
        }

    }
}
