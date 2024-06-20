using System;
using System.Collections.Generic;

namespace Assets.Project_S
{
    public class DialoguesCharacter : IReadOnlyDialogueCharacter
    {
        private readonly DialogueCharacterData _dialogueData;
        private List<Dialogue> _dialogues = new List<Dialogue>();
        private float _coolDown = 1f;

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

        public float CoolDown
        {
            get => _coolDown;
            set
            {
                _coolDown = value;

                if (value >= 21f || value <= 0f)
                {
                    _coolDown = 1f;
                }
            }
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
