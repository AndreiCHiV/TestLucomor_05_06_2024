using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestListController
    {
        private readonly QuestListView _view;
        private List<QuestController> _quests = new List<QuestController>();

        public QuestListController(List<IReadOnlyQuestList> quests, QuestListView view)
        {
            view.RemoveAllQuestsDisplayView();
            _view = view;

            if (quests.Count != 0)
            {
                foreach (IReadOnlyQuestList questList in quests)
                {
                    string ownerQuest = questList.Owner;

                    if (questList.GetQuestList().Count != 0)
                    {
                        foreach (IReadOnlyQuest quest in questList.GetQuestList())
                        {
                            QuestView questView = view.AddQuestDisplayView();
                            QuestController questController = new QuestController(quest, questView, ownerQuest);

                            _quests.Add(questController);

                            view.Quests.Add(questView);
                        }
                        view.SetDefaultQuest();
                    }
                }
            }
            else
            {
                view.QuestDescription.DescriptionQuest = "\n\n<align=\"center\"><b>Not Quests.</b>";
                view.QuestDescription.Owner = "";
            }
        }

        public void ChangedAddQuest(string ownerQuest, IReadOnlyQuest quest)
        {
            QuestView questView = _view.AddQuestDisplayView();
            QuestController questController = new QuestController(quest, questView, ownerQuest);

            _quests.Add(questController);

            _view.Quests.Add(questView);

            _view.SetDefaultQuest();
        }
        public void ChangedRemoveQuest(int questID)
        {
            foreach (QuestController questController in _quests)
            {
                if (questController.GetQuestID() == questID)
                {
                    Debug.Log($"Remove Quest {questController.GetQuestID()}");
                    _quests.Remove(questController);
                    _view.RemoveQuestDisplayView(questID);
                    return;
                }
            }
        }
    }
}
