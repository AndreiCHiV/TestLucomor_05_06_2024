using System.Collections.Generic;

namespace Assets.Project_S
{
    public class DialogueCharacterService
    {
        private readonly Dictionary<string, DialoguesCharacter> _dialogueCharacterMap = new Dictionary<string, DialoguesCharacter>();

        public DialoguesCharacter RegistrationDialogueCharacter(DialogueCharacterData dialoguesCharacterData)
        {
            DialoguesCharacter dialoguesCharacter = new DialoguesCharacter(dialoguesCharacterData);
            _dialogueCharacterMap[dialoguesCharacter.Owner] = dialoguesCharacter;
            return dialoguesCharacter;
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
