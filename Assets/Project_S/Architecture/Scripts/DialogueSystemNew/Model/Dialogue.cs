using System;
using UnityEngine;

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

        public TextAsset GetDialogue()
        {
            return _data.inkJSON;
        }
    }
}
