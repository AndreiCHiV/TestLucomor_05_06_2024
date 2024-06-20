using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class DialoguesCharacter : IReadOnlyDialogueCharacter
    {
        private readonly DialogueCharacterData _dialogueData;
        private List<Dialogue> _dialogues = new List<Dialogue>();

        public DialoguesCharacter(DialogueCharacterData dialogueData)
        {
            _dialogueData = dialogueData;
            InitializeDialogueCharacter();

        }
        public string Owner
        {
            get => _dialogueData.owner;
            set => _dialogueData.owner = value;
        }

        private void InitializeDialogueCharacter()
        {
            foreach (DialogueData dialogueData in _dialogueData.dialogueDatas)
            {
                _dialogues.Add(new Dialogue(dialogueData));
            }
        }

        public IReadOnlyDialogue GetDialogueStory(int dataDialogueID)
        {
            foreach (Dialogue dialogue in _dialogues)
            {
                if (dialogue.DialogueId == dataDialogueID)
                {
                    return dialogue;
                }
            }

            throw new ArgumentException("Not Dialogue in Character");
        }
    }
}
