using System.Collections;
using UnityEngine;

namespace Assets.Project_S
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private TextAsset _inkJSON_100000;

        private const string PLAYER = "Lisa";

        public string GetName()
        {
            return PLAYER;
        }

        public DialogueData[] InitializationDialogueData()
        {
            DialogueData dialogueDataPlayer_0 = new DialogueData()
            {
                inkJSON = _inkJSON_100000,
                dataDialogueID = 100000
            };

            return new DialogueData[]
            {
                dialogueDataPlayer_0
            };
        }

        public DialogueCharacterData InitializationDialogueCharacter()
        {
            return new DialogueCharacterData()
            {
                owner = PLAYER
            };
        }

    }
}