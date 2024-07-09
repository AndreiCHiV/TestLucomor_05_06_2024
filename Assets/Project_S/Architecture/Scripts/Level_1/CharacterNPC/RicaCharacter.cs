using UnityEngine;

namespace Assets.Project_S
{
    public class RicaCharacter : MonoBehaviour
    {
        [SerializeField] private TextAsset _inkJSON_102000;
        [SerializeField] private TextAsset _inkJSON_102001;
        [SerializeField] private TextAsset _inkJSON_102002;

        private const string RICA = "Rica";

        public string GetName()
        {
            return RICA;
        }

        public DialogueData[] InitializationDialogueData()
        {
            DialogueData dialogueDataRica_0 = new DialogueData()
            {
                inkJSON = _inkJSON_102000,
                dataDialogueID = 102000
            };
            DialogueData dialogueDataRica_1 = new DialogueData()
            {
                inkJSON = _inkJSON_102001,
                dataDialogueID = 102001
            };
            DialogueData dialogueDataRica_2 = new DialogueData()
            {
                inkJSON = _inkJSON_102002,
                dataDialogueID = 102002
            };

            return new DialogueData[] { dialogueDataRica_0, dialogueDataRica_1, dialogueDataRica_2 };
        }

        public DialogueCharacterData InitializationDialogueCharacter()
        {
            return new DialogueCharacterData()
            {
                owner = RICA
            };
        }
    }
}
