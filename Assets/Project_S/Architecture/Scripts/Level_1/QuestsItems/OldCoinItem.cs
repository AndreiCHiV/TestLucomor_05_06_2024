using UnityEngine;

namespace Assets.Project_S
{
    public class OldCoinItem : MonoBehaviour
    {
        [SerializeField] private TextAsset _inkJSON_500000;
        [SerializeField] private TextAsset _inkJSON_500001;

        private const string OLDCOIN = "Bushes";

        public string GetName()
        {
            return OLDCOIN;
        }

        public DialogueData[] InitializationDialogueData()
        {
            DialogueData dialogueDataOldCoinItem_0 = new DialogueData()
            {
                inkJSON = _inkJSON_500000,
                dataDialogueID = 500000
            };
            DialogueData dialogueDataOldCoinItem_1 = new DialogueData()
            {
                inkJSON = _inkJSON_500001,
                dataDialogueID = 500001
            };
            return new DialogueData[]
            {
                dialogueDataOldCoinItem_0,
                dialogueDataOldCoinItem_1
            };
        }
        public DialogueCharacterData InitializationDialogueCharacter()
        {
            return new DialogueCharacterData()
            {
                owner = OLDCOIN
            };
        }
    }
}
