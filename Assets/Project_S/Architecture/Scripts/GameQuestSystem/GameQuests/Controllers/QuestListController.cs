using System.Collections.Generic;

namespace Assets.Project_S
{
    public class QuestListController
    {
        private readonly QuestListView _view;
        private List<QuestController> _quests = new List<QuestController>();

        public QuestListController(List<IReadOnlyQuestList> quests, QuestListView view, bool firstCallQuest)
        {


            _view = view;

            foreach (IReadOnlyQuestList questList in quests)
            {
                string ownerQuest = questList.Owner;

                foreach (IReadOnlyQuest quest in questList.GetQuestList())
                {
                    QuestView questView = view.AddQuestDisplayView();
                    _quests.Add(new QuestController(quest, questView, ownerQuest));
                }
            }

            view.SetDefaultQuest(firstCallQuest);
        }
    }
}
