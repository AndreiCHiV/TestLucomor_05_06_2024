using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenQuestController
    {
        private ScreenQuestView _view;
        private QuestService _service;

        private bool _firstCall = true;

        private QuestListController _questListController;

        public ScreenQuestController(QuestService service, ScreenQuestView view)
        {
            _view = view;
            _service = service;
        }

        public void OpenQuest()
        {
            List<IReadOnlyQuestList> questList = _service.GetAllQuestsCharacters();
            QuestListView questListView = _view.QuestListView;

            _questListController = new QuestListController(questList, questListView, _firstCall);

            _firstCall = false;
        }
    }
}
