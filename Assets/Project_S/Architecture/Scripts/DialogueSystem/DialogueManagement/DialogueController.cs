using Ink.Runtime;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueController : MonoBehaviour
    {
        private DialogueWindow _dialogueWindows;
        private DialogueTag _dialogueTag;

        public Story CurrentStory { get; set; }
        private Coroutine _displayLineCoroutine;

        private void Awake()
        {
            _dialogueTag = GetComponent<DialogueTag>();
            _dialogueWindows = GetComponent<DialogueWindow>();

            _dialogueTag.Init();
            _dialogueWindows.Init();
        }

        private void Start()
        {
            _dialogueWindows.SetActive(false);
        }

        private void Update()
        {
            if (_dialogueWindows.IsStatusAnswer == true || _dialogueWindows.IsPlaying == false || _dialogueWindows.CanContinueToNextLine == false)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                ContinuesStory();
            }

        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {
            CurrentStory = new Story(inkJSON.text);

            _dialogueWindows.SetActive(true);
            ContinuesStory();
        }
        private IEnumerator ExitDialogueMode()
        {
            yield return new WaitForSeconds(_dialogueWindows.CoolDownNewLetter);
            _dialogueWindows.SetActive(false);
            _dialogueWindows.ClearText();
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

            _displayLineCoroutine = StartCoroutine(_dialogueWindows.DisplayLine(CurrentStory));

            try
            {
                _dialogueTag.HandleTags(CurrentStory.currentTags);
            }
            catch (ArgumentException message)
            {
                Debug.LogError(message.Message);
            }
        }

        public void MakeChoice(int choiceIndex)
        {
            _dialogueWindows.MakeChoice();

            CurrentStory.ChooseChoiceIndex(choiceIndex);

            ContinuesStory();
        }

    }
}
