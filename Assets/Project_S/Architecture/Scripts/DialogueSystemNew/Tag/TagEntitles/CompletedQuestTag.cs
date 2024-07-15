using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class CompletedQuestTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "completedQuest";
        public string NameTag => NAMETAG;

        public void Calling(string valueTag)
        {
            string[] keyTag = valueTag.Split("_");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }

            string name = keyTag[0].Trim();
            string id = keyTag[1].Trim();

            string[] keyTagID = id.Split("-");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }
            int questId = int.Parse(keyTagID[0].Trim());
            int messageId = int.Parse(keyTagID[1].Trim());

            IReadOnlyQuest questNameID = _entryPoint.QuestService.GetCharacterQuest(name, questId);

            if (questNameID != null)
            {
                int[] changeDialogueCharacter = _entryPoint.QuestService.AddCompletedQuest(name, questId, messageId);
                _entryPoint.QuestService.RemoveCurrentQuest(name, questId);
                _entryPoint.CharactersService.ChangeDialogueIDCharacters(changeDialogueCharacter);
            }
            else
                Debug.LogError("Квест не найден!");
        }
    }
}
