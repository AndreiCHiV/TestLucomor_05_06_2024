using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Project_S
{
    public class QuestListView : MonoBehaviour
    {
        [SerializeField] private GameObject _quest;

        [SerializeField] private List<QuestView> _quests = new List<QuestView>();

        [SerializeField] private QuestDescriptionView _questDescriptionView;

        private QuestView currentQuest;

        public List<QuestView> Quests
        {
            get => _quests;
            set => _quests = value;
        }


        public QuestView AddQuestDisplayView()
        {
            GameObject questObject = Instantiate(_quest);
            questObject.transform.SetParent(GameObject.FindGameObjectWithTag("Quest").transform, false);
            QuestView quest = questObject.GetComponent<QuestView>();

            return quest;
        }

        public void SetSelectedQuest(int id)
        {
            foreach (QuestView quest in Quests)
            {
                if (quest.QuestId == id)
                {
                    _questDescriptionView.DescriptionQuest = quest.ViewMessage;
                    currentQuest = quest;
                }
            }
        }

        public void SetDefaultQuest(bool firstCall)
        {
            if (firstCall == true)
            {
                if (Quests[0] != null)
                {
                    _questDescriptionView.DescriptionQuest = Quests[0].ViewMessage;
                    _questDescriptionView.Owner = Quests[0].OwnerQuest;
                    currentQuest = Quests[0];
                }
                else
                    return;
            }
            else
            {
                _questDescriptionView.DescriptionQuest = currentQuest.ViewMessage;
                _questDescriptionView.Owner = currentQuest.OwnerQuest;
            }

        }
    }
}