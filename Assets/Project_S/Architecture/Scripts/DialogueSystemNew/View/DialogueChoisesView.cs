using Ink.Runtime;
using System;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class DialogueChoisesView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _choices;
        [SerializeField] private TMP_Text[] _choicesText;


        public void HideChoices()
        {
            foreach (GameObject chois in _choices)
            {
                chois.SetActive(false);
            }
        }

        public bool DisplayChoices(Story story)
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
    }
}
