using Ink.Runtime;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueChoisesView : MonoBehaviour
    {
        [SerializeField] private GameObject _choicesPrefab;
        [SerializeField] private List<ChoiceView> _choices = new List<ChoiceView>();
        [SerializeField] private ScreenDialogueCharacterView _screenDialogueCharacterView;

        private ChoiceView _currentChoice;
        private bool _createChoisesDisplay;
        private Vector3 _transformPrefab;
        private int _index;

        public bool CreateChoisesDisplay
        {
            get => _createChoisesDisplay;
            set => _createChoisesDisplay = value;
        }

        public int ChoicesCount
        {
            get => _choices.Count;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeActiveChoiceDown();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeActiveChoiceUp();
            }
            if (Input.GetKeyDown(KeyCode.F) && CreateChoisesDisplay)
            {
                EnterChoise(_currentChoice);
            }
        }

        private void EnterChoise(ChoiceView currentChoice)
        {
            CreateChoisesDisplay = false;
            _screenDialogueCharacterView.MakeChoice(currentChoice.Index);
        }

        private void ChangeActiveChoiceUp()
        {
            for (int i = 0; i < _choices.Count; i++)
            {
                if (_currentChoice.Index == _choices[i].Index)
                {
                    _currentChoice.SetNotActiveChoise();

                    if (i >= 1)
                    {
                        _currentChoice = _choices[i - 1];
                        _currentChoice.SetActiveChoise();
                        return;
                    }
                    else
                    {
                        _currentChoice = _choices[^1];
                        _currentChoice.SetActiveChoise();
                        return;
                    }
                }
            }
        }

        private void ChangeActiveChoiceDown()
        {
            for (int i = 0; i < _choices.Count; i++)
            {
                if (_currentChoice.Index == _choices[i].Index)
                {
                    _currentChoice.SetNotActiveChoise();

                    if (i < _choices.Count - 1)
                    {
                        _currentChoice = _choices[i + 1];
                        _currentChoice.SetActiveChoise();
                        return;
                    }
                    else
                    {
                        _currentChoice = _choices[0];
                        _currentChoice.SetActiveChoise();
                        return;
                    }
                }
            }
        }

        public bool AddChoises(Story story)
        {
            Choice[] currentChoices = story.currentChoices.ToArray();

            if (currentChoices.Length == 0)
            {
                return false;
            }

            foreach (Choice choice in currentChoices)
            {
                ChoiceView choiceView = AddChoiseDisplayView();
                _choices.Add(choiceView);
                choiceView.ChoiseText = choice.text;
                choiceView.Index = choice.index;

                if (choiceView.Index != 0)
                {
                    _index = choiceView.Index;
                    _transformPrefab = _choices[_index - 1].transform.position;
                    _transformPrefab += new Vector3(0f, 75f);
                    choiceView.transform.position = _transformPrefab;
                }

            }

            _choices[^1].SetActiveChoise();
            _currentChoice = _choices[^1];

            CreateChoisesDisplay = true;
            return currentChoices.Length > 0;
        }

        public ChoiceView AddChoiseDisplayView()
        {
            GameObject choiceObject = Instantiate(_choicesPrefab);
            choiceObject.transform.SetParent(GameObject.FindGameObjectWithTag("Choises").transform, false);
            ChoiceView choice = choiceObject.GetComponent<ChoiceView>();
            return choice;
        }

        public void ClearChoises()
        {
            foreach (ChoiceView choice in _choices)
            {
                Destroy(choice.gameObject);
            }
                _choices.Clear();
        }
    }
}
