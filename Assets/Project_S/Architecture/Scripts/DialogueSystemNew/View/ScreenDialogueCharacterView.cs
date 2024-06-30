using Ink.Runtime;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenDialogueCharacterView : MonoBehaviour
    {
        [SerializeField] private DialogueCharacterView _dialogueCharacterView;
        [SerializeField] private DialogueCharacterTag _tagCharacter;

        private Coroutine _displayLineCoroutine;

        public Story CurrentStory { get; set; }
        public CharacterView IsMovingCharacter { get; set; }

        public DialogueCharacterView DialogueCharacterView
        {
            get => _dialogueCharacterView;
        }


        private void Start()
        {
            _tagCharacter.InitializeTags();
        }

        private void Update()
        {
            if (_dialogueCharacterView.IsStatusAnswer == true || _dialogueCharacterView.IsPlaying == false || _dialogueCharacterView.CanContinueToNextLine == false)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                ContinuesStory();
            }
        }

        public void SetName(string nameRigth, string nameLeft)
        {
            _dialogueCharacterView.NameRigth = nameRigth;
            _dialogueCharacterView.NameLeft = nameLeft;
        }

        public void Init()
        {
            _dialogueCharacterView.Init();
        }

        public void SetImageCharacter(Sprite imageCharacterRigth, Sprite imageCharacterLeft)
        {
            _dialogueCharacterView.SetImageCharacter(imageCharacterRigth, imageCharacterLeft);
        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {

            CurrentStory = new Story(inkJSON.text);

            _dialogueCharacterView.SetActive(true);
            ContinuesStory();
        }

        private IEnumerator ExitDialogueMode()
        {
            yield return new WaitForSeconds(_dialogueCharacterView.CoolDownNewLetter);
            _dialogueCharacterView.SetActive(false);
            _dialogueCharacterView.ClearText();
            IsMovingCharacter.IsMoving = false;
        }

        private void ContinuesStory()
        {
            if (CurrentStory.canContinue == false)
            {
                StartCoroutine(ExitDialogueMode());
                return;
            }

            if (_displayLineCoroutine != null)
            {
                StopCoroutine(_displayLineCoroutine);
            }

            _displayLineCoroutine = StartCoroutine(_dialogueCharacterView.DisplayLine(CurrentStory));

            try
            {
                _tagCharacter.HandleTags(CurrentStory.currentTags);
            }
            catch (ArgumentException message)
            {
                Debug.LogError(message.Message);
            }
        }

        public void MakeChoice(int choiceIndex)
        {
            _dialogueCharacterView.MakeChoice();

            CurrentStory.ChooseChoiceIndex(choiceIndex);

            ContinuesStory();
        }

    }
}
