using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class ContinueQuestTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "continueQuest";
        public string NameTag => NAMETAG;

        public void Calling(string valueTag)
        {
            string[] keyTag = valueTag.Split("_");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }

            string name = keyTag[0].Trim();
            string dialogueId = keyTag[1].Trim();


            int[] changeDialogueCharacter = _entryPoint.QuestService.ContinueQuest(name, dialogueId);
            _entryPoint.CharactersService.ChangeDialogueIDCharacters(changeDialogueCharacter);
        }
    }
}
