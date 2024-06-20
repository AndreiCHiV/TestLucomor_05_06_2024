using System;

namespace Assets.Project_S
{
    public class Dialogue : IReadOnlyDialogue
    {
        private readonly DialogueData _data;

        public Dialogue(DialogueData data)
        {
            _data = data;
        }

        public int DialogueId
        {
            get => _data.dataDialogueID;
        }

        public DialogueData GetDialogue()
        {
            return _data;
        }
    }
}
