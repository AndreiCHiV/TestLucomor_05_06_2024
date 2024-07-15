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

            if (data.CompletedQuest || data.FailedQuest)
            {
                data.ChangedMessageQuest -= MessageQuestChanged;
            }
        }

        private void MessageQuestChanged()
        {
            _view.ViewMessage = _data.GetMessages();
        }

        public int GetQuestID()
        {
            return _data.QuestID;
        }

        public void Dispose()
        {
            _data.ChangedMessageQuest -= MessageQuestChanged;
        }
    }
}
