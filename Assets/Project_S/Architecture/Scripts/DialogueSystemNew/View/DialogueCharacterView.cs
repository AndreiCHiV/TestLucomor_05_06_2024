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

        [SerializeField] private ImageCharacterView _imageCharacterRigth;
        [SerializeField] private ImageCharacterView _imageCharacterLeft;

        [SerializeField] private DialogueChoisesView _dialogueChoisesView;

        private string _nameLeft;
        private string _nameRigth;

        private float _cooldownNewLetter = 0.02f;

        public bool IsStatusAnswer { get; set; }
        public bool IsPlaying { get; set; }
        public bool CanContinueToNextLine { get; set; }


        public string NameLeft
        {
            get => _nameLeft;
            set => _nameLeft = value;
        }

        public string NameRigth
        {
            get => _nameRigth;
            set => _nameRigth = value;
        }

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
        public void ActiveDialogueCharacter(string value)
        {
            if (NameRigth == value)
            {
                _imageCharacterLeft.DisActiveImage();
                _imageCharacterRigth.ActiveImage();
            }
            else
            {
                _imageCharacterLeft.ActiveImage();
                _imageCharacterRigth.DisActiveImage();
            }
        }

        public void SetImageCharacter(Sprite imageCharacterRigth,Sprite imageCharacterLeft)
        {
            Debug.Log("1");
            _imageCharacterRigth.ImageCharacter = imageCharacterRigth;
            Debug.Log("2");
            _imageCharacterLeft.ImageCharacter = imageCharacterLeft;
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
                if (Input.GetKey(KeyCode.F))
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