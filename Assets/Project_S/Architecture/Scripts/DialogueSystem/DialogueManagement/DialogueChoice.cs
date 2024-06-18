using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueChoice:MonoBehaviour
    {
        [SerializeField] private GameObject[] _choices;
        private TextMeshProUGUI[] _choicesText;


        public void Init()
        {
            _choicesText = new TextMeshProUGUI[_choices.Length];

            int index = 0;

            foreach (GameObject choice in _choices)
            {
                _choicesText[index++] = choice.GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        internal bool DisplayChoices(Story story)
        {
            Choice[] currentChoices = story.currentChoices.ToArray();

            if (currentChoices.Length > _choices.Length)
            {
                throw new ArgumentException("Ошибка! Выборов в сценарии больше чем в игре!");
            }

            HideChoices();

            int index = 0;

            foreach (Choice choice in currentChoices)
            {
                _choices[index].SetActive(true);
                _choicesText[index++].text = choice.text;
            }

            return currentChoices.Length > 0;
        }
        internal void HideChoices()
        {
            foreach (GameObject button in _choices)
            {
                button.SetActive(false);
            }
        }
    }
}
