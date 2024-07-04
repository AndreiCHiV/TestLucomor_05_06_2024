using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestListController
    {
        private readonly QuestListView _view;
        private List<QuestController> _quests = new List<QuestController>();
        private bool _firstCallQuest;

        public QuestListController(List<IReadOnlyQuestList> quests, QuestListView view, bool firstCallQuest)
        {
            _view = view;
            _firstCallQuest = firstCallQuest;

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

                        view.SetDefaultQuest(firstCallQuest);
                    }
                }
            }
            else
                view.QuestDescription.DescriptionQuest = "\n\n<align=\"center\"><b>Not Quests.</b>";
        }

        public void ChangedAddQuest(string ownerQuest, IReadOnlyQuest quest)
        {
            QuestView questView = _view.AddQuestDisplayView();
            QuestController questController = new QuestController(quest, questView, ownerQuest);

            _quests.Add(questController);

            _view.Quests.Add(questView);

            _view.SetDefaultQuest(_firstCallQuest);
        }

        //private void AddQuestSlot()
        //{
        //foreach (IReadOnlyQuestList questList in quests)
        //{
        //    string ownerQuest = questList.Owner;
        //    questList.AddQuestChanged += ChangedAddQuest;

        //    if (questList.GetQuestList().Count != 0)
        //    {
        //        foreach (IReadOnlyQuest quest in questList.GetQuestList())
        //        {
        //            QuestView questView = view.AddQuestDisplayView();
        //            QuestController questController = new QuestController(quest, questView, ownerQuest);

        //            _quests.Add(questController);

        //            view.Quests.Add(questView);
        //        }

        //        view.SetDefaultQuest(firstCallQuest);
        //    }
        //}
        //}
    }
}
