using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenQuestController
    {
        private ScreenQuestView _view;
        private QuestService _service;

        private QuestListController _questListCharacterController;
        private QuestListController _questListCompletedController;

        public ScreenQuestController(QuestService service, ScreenQuestView view)
        {
            _view = view;
            _service = service;
        }

        public void OpenCharacterQuest()
        {
            List<IReadOnlyQuestList> questList = _service.GetAllQuestsCharacters();
            QuestListView questListView = _view.QuestListView;

            _questListCharacterController = new QuestListController(questList, questListView);
        }

        public void OpenCompletedQuest()
        {
            List<IReadOnlyQuestList> questList = _service.GetAllCompletedQuests();
            QuestListView questListView = _view.QuestListView;

            _questListCompletedController = new QuestListController(questList, questListView);
        }
    }
}
