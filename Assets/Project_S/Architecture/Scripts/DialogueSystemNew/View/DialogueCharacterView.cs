using Ink.Runtime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project_S
{
    public class DialogueCharacterView : MonoBehaviour
    {
        [SerializeField] private DialogueView _dialogueView;
        [SerializeField] private GameObject _dialogueWindowView;

        [SerializeField] private ImageCharacterView _imageCharacterRight;
        [SerializeField] private ImageCharacterView _imageCharacterLeft;

        [SerializeField] private DialogueChoisesView _dialogueChoisesView;

        private float _cooldownNewLetter = 0.02f;

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
        }

        public void SetNameCharacter(string name)
        {
            _dialogueView.NameCharacter = name;
        }

        public IEnumerator DisplayLine(Story story)
        {
            _dialogueChoisesView.HideChoices();

            string line = story.Continue();

            ClearText();

            CanContinueToNextLine = false;

            bool isAddingRichText = false;

            yield return new WaitForSeconds(0.2f);

            foreach (char letter in line.ToCharArray())
            {
                if (Input.GetKey(KeyCode.Space))
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


            IsStatusAnswer = _dialogueChoisesView.DisplayChoices(story);
        }

        public void SetActive(bool active)
        {
            IsPlaying = active;
            _dialogueWindowView.SetActive(active);
        }

        public void SetText(string text)
        {
            _dialogueView.DialogueCharacter = text;
        }

        public void Add(string text)
        {
            _dialogueView.DialogueCharacter += text;
        }

        public void Add(char letter)
        {
            _dialogueView.DialogueCharacter += letter;
        }

        public void ClearText()
        {
            SetText("");
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

    }
}