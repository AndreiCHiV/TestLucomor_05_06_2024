using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestListView : MonoBehaviour
    {
        [SerializeField] private GameObject _questPrefab;

        [SerializeField] private List<QuestView> _quests = new List<QuestView>();

        [SerializeField] private QuestDescriptionView _questDescriptionView;

        private QuestView _currentQuest;

        public List<QuestView> Quests
        {
            get => _quests;
            set => _quests = value;
        }

        public QuestDescriptionView QuestDescription => _questDescriptionView;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChangeActiveQuestDown();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeActiveQuestUp();
            }
        }

        private void ShowQuests()
        {
            foreach (var quset in _quests)
            {
                Debug.Log(quset.ViewMessage);
            }
        }

        public QuestView AddQuestDisplayView()
        {
            GameObject questObject = Instantiate(_questPrefab);
            questObject.transform.SetParent(GameObject.FindGameObjectWithTag("Quest").transform, false);
            QuestView quest = questObject.GetComponent<QuestView>();
            return quest;
        }

        public void SetSelectedQuest(int id)
        {
            foreach (QuestView quest in Quests)
            {
                if (quest.QuestId == id)
                {
                    _questDescriptionView.DescriptionQuest = quest.ViewMessage;
                    _currentQuest = quest;
                }
            }
        }

        public void SetDefaultQuest(bool firstCall)
        {
            if (firstCall == true)
            {
                if (Quests.Count != 0)
                {
                    SetQuestDescriptionInDisplay(Quests[0]);
                    Quests[0].SetActiveSlotQuest();
                    _currentQuest = Quests[0];
                }
                else
                    return;
            }
            else
            {
                SetQuestDescriptionInDisplay(_currentQuest);
                _currentQuest.SetActiveSlotQuest();
            }
        }

        public void ChangeActiveQuestDown()
        {
            for (int i = 0; i < Quests.Count; i++)
            {
                if (_currentQuest.NameQuest == Quests[i].NameQuest)
                {
                    _currentQuest.SetNotActiveSlotQuest();

                    if (i < Quests.Count - 1)
                    {
                        _currentQuest = Quests[i + 1];
                        _currentQuest.SetActiveSlotQuest();
                        SetQuestDescriptionInDisplay(_currentQuest);
                        return;
                    }
                    else
                    {
                        _currentQuest = Quests[0];
                        _currentQuest.SetActiveSlotQuest();
                        SetQuestDescriptionInDisplay(_currentQuest);
                        return;
                    }
                }

            }
        }
        private void ChangeActiveQuestUp()
        {
            for (int i = 0; i < Quests.Count; i++)
            {
                if (_currentQuest.NameQuest == Quests[i].NameQuest)
                {
                    _currentQuest.SetNotActiveSlotQuest();

                    if (i >= 1)
                    {
                        _currentQuest = Quests[i - 1];
                        _currentQuest.SetActiveSlotQuest();
                        SetQuestDescriptionInDisplay(_currentQuest);
                        return;
                    }
                    else
                    {
                        _currentQuest = Quests[^1];
                        _currentQuest.SetActiveSlotQuest();
                        SetQuestDescriptionInDisplay(_currentQuest);
                        return;
                    }
                }

            }
        }

        private void SetQuestDescriptionInDisplay(QuestView currentQuest)
        {
            _questDescriptionView.DescriptionQuest = currentQuest.ViewMessage;
            _questDescriptionView.Owner = currentQuest.OwnerQuest;
        }

    }
}