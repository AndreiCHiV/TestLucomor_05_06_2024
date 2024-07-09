using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class AddQuestTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "addQuest";
        public string NameTag
        {
            get => NAMETAG;
        }

        public void Calling(string valueTag)
        {
            string[] keyTag = valueTag.Split("_");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }

            string name = keyTag[0].Trim();
            int id = int.Parse(keyTag[1].Trim());

            IReadOnlyQuest questNameID = _entryPoint.QuestService.GetQuest(name, id);

            if (questNameID != null)
            {
                int[] changeDialogueCharacter = _entryPoint.QuestService.AddQuestCharacter(name, id);
                _entryPoint.QuestService.RemoveQuest(name, id);
                _entryPoint.CharactersService.ChangeDialogueIDCharacters(changeDialogueCharacter);
            }
            else
                Debug.LogError("Квест не найден!");
        }
    }
}
