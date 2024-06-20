using System;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameCharacter;
        [SerializeField] private TMP_Text _dialogueCharacter;

        public string NameCharacter
        {
            get => _nameCharacter.text;
            set => _nameCharacter.text = value;
        }
        public string DialogueCharacter
        {
            get => _dialogueCharacter.text;
            set => _dialogueCharacter.text = value;
        }

    }
}
