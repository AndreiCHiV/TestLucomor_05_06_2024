using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class AddQuestCharacterTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private ScreenDialogueCharacterView _screenDialogueCharacterView;
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "AddQuest";

        public string NameTag => NAMETAG;

        public void Calling(string value)
        {

        }
    }
}
