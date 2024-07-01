using System;

namespace Assets.Project_S
{
    public class QuestController
    {
        private readonly QuestView _view;

        public QuestController(IReadOnlyQuest data, QuestView view, string ownerQuest)
        {
            data.currentQuestChanged += ChangedCurrentQuest;

            _view = view;

            view.NameQuest = data.NameQuest;
            view.OwnerQuest = ownerQuest;
            view.QuestId = data.QuestID;
            view.ViewMessage = data.GetMessages();
        }

        private void ChangedCurrentQuest(byte value)
        {
            _view.CurrentQuest = value;
        }
    }
}
