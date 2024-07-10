using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestController
    {
        private readonly QuestView _view;
        private readonly IReadOnlyQuest _data;

        public QuestController(IReadOnlyQuest data, QuestView view, string ownerQuest)
        {
            _view = view;
            _data = data;

            data.ChangedMessageQuest += MessageQuestChanged;

            view.NameQuest = data.NameQuest;
            view.OwnerQuest = ownerQuest;
            view.QuestId = data.QuestID;
            view.ViewMessage = data.GetMessages();
        }

        private void MessageQuestChanged()
        {
            _view.ViewMessage = _data.GetMessages();

        }

        public void Dispose()
        {
            _data.ChangedMessageQuest -= MessageQuestChanged;
        }
    }
}
