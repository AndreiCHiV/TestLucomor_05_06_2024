using UnityEngine;

namespace Assets.Project_S
{
    public class WolfCharacter : MonoBehaviour
    {
        [SerializeField] private TextAsset _inkJSON_103000;
        [SerializeField] private TextAsset _inkJSON_103001;
        [SerializeField] private TextAsset _inkJSON_103002;

        private const string WOLF = "Wolf";

        public string GetName()
        {
            return WOLF;
        }

        public DialogueData[] InitializationDialogueData()
        {
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
            DialogueData dialogueDataWolf_2 = new DialogueData()
            {
                inkJSON = _inkJSON_103002,
                dataDialogueID = 103002
            };

            return new DialogueData[] { dialogueDataWolf_0, dialogueDataWolf_1, dialogueDataWolf_2 };
        }

        public DialogueCharacterData InitializationDialogueCharacter()
        {
            return new DialogueCharacterData()
            {
                owner = WOLF
            };
        }
    }
}
