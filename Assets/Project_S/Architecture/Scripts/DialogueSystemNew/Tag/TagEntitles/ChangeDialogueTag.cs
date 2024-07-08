using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class ChangeDialogueTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "changeDialogue";
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

            IReadOnlyDialogue dialogueNameID = _entryPoint.DialogueCharacterService.GetDialogueCharacterId(name, id);
            //IReadOnlyQuest questNameID = _entryPoint.QuestService.GetQuest(name, id);

            if (dialogueNameID != null)
            {
                _entryPoint.ScreenDialogueCharacterView.EnterDialogueMode(dialogueNameID.GetDialogue());

                //if (questNameID.CurrentQuest == 0)
                //{
                //    _screenDialogueCharacterView.EnterDialogueMode(dialogueNameID.GetDialogue());
                //    return;
                //}
                //if (questNameID.CurrentQuest == questNameID.ComplitedQuest)
                //{
                //    _screenDialogueCharacterView.EnterDialogueMode(dialogueNameID.GetDialogue());
                //    return;
                //}
                //if (questNameID.CurrentQuest != 0 && questNameID.CurrentQuest != questNameID.ComplitedQuest)
                //{
                //    _screenDialogueCharacterView.EnterDialogueMode(dialogueNameID.GetDialogue());
                //    return;
                //}
            }
            else
                Debug.LogError("Диалог не найден!");
        }
    }
}