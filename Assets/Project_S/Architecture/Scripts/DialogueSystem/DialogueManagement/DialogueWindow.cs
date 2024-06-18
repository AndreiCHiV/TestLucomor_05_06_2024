using Ink.Runtime;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueWindow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _displayName;
        [SerializeField] private TextMeshProUGUI _displayText;

        [SerializeField] private GameObject _displayWindow;

        [SerializeField, Range(0, 20f)] private float _cooldownNewLetter;

        private DialogueChoice _dialogueChoice;

        public bool IsStatusAnswer { get; set; }
        public bool IsPlaying { get; set; }
        public bool CanContinueToNextLine { get; set; }

        public float CoolDownNewLetter
        {
            get => _cooldownNewLetter;
            set => _cooldownNewLetter = CheckCoolDown(value);
        }

        private float CheckCoolDown(float value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Значене задержки между буквами было отрицательно!");
            }

            return value;
        }

        public void Init()
        {
            IsStatusAnswer = false;
            CanContinueToNextLine = false;

            _dialogueChoice = GetComponent<DialogueChoice>();
            _dialogueChoice.Init();
        }

        public void SetActive(bool active)
        {
            IsPlaying = active;
            _displayWindow.SetActive(active);
        }

        public void SetText(string text)
        {
            _displayText.text = text;
        }

        public void Add(string text)
        {
            _displayText.text += text;
        }

        public void Add(char letter)
        {
            _displayText.text += letter;
        }

        public void ClearText()
        {
            SetText("");
        }

        public void SetName(string namePerson)
        {
            _displayName.text = namePerson;
        }

        public void SetCoolDown(float cooldown)
        {
            CoolDownNewLetter = cooldown;
        }

        public void MakeChoice()
        {
            if (CanContinueToNextLine == false)
            {
                return;
            }

            IsStatusAnswer = false;
        }

        public IEnumerator DisplayLine(Story story)
        {
            _dialogueChoice.HideChoices();

            string line = story.Continue();

            ClearText();

            CanContinueToNextLine = false;

            bool isAddingRichText = false;

            yield return new WaitForSeconds(0.001f);

            foreach (char letter in line)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SetText(line);
                    break;
                }

                isAddingRichText = letter == '<' || isAddingRichText;

                if (letter == '>')
                {
                    isAddingRichText = false;
                }

                Add(letter);

                if (isAddingRichText == false)
                {
                    yield return new WaitForSeconds(_cooldownNewLetter);
                }
            }

            CanContinueToNextLine = true;


            IsStatusAnswer = _dialogueChoice.DisplayChoices(story);
        }
    }
}
