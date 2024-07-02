using System.Collections.Generic;
using UnityEngine;

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
                    QuestController questController = new QuestController(quest, questView, ownerQuest);

                    _quests.Add(questController);

                    view.Quests.Add(questView);
                }
            }


            view.SetDefaultQuest(firstCallQuest);
        }
    }
}
