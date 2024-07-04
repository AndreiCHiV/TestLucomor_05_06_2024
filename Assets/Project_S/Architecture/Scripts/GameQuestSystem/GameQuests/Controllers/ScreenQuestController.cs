using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenQuestController
    {
        private ScreenQuestView _view;
        private QuestService _service;

        private bool _firstCallCharacterQuests = true;
        private bool _firstCallComplitedQuests = true;

        private QuestListController _questListCharacterController;
        private QuestListController _questListCompletedController;

        public ScreenQuestController(QuestService service, ScreenQuestView view)
        {
            _view = view;
            _service = service;

            _service.AddCharacterQuestInViewChanged += ChangedAddCharacterQuestInView;
            _service.AddComplitedQuestInViewChanged += ChangedAddComplitedQuestInView;
        }


        private void ChangedAddCharacterQuestInView(string owner, IReadOnlyQuest quest)
        {
            if (_questListCharacterController != null)
            {
                _questListCharacterController.ChangedAddQuest(owner, quest);
            }
            else
                Debug.Log("CharacterController пустой!");

        }
        private void ChangedAddComplitedQuestInView(string owner, IReadOnlyQuest quest)
        {
            if (_questListCompletedController != null)
            {
                _questListCompletedController.ChangedAddQuest(owner, quest);
            }
            else
                Debug.Log("CompletedController пустой!");
        }

        public void OpenCharacterQuest()
        {
            List<IReadOnlyQuestList> questList = _service.GetAllQuestsCharacters();
            QuestListView questListView = _view.QuestListView;

            _questListCharacterController = new QuestListController(questList, questListView, _firstCallCharacterQuests);

            _firstCallCharacterQuests = false;
        }

        public void OpenCompletedQuest()
        {
            List<IReadOnlyQuestList> questList = _service.GetAllCompletedQuests();
            QuestListView questListView = _view.QuestListView;

            _questListCompletedController = new QuestListController(questList, questListView, _firstCallComplitedQuests);

            _firstCallComplitedQuests = false;
        }

        public void Dispose()
        {
            _service.AddCharacterQuestInViewChanged -= ChangedAddCharacterQuestInView;
            _service.AddComplitedQuestInViewChanged -= ChangedAddComplitedQuestInView;
        }
    }
}
