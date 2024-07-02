using UnityEngine;

namespace Assets.Project_S
{
    public class ScreenQuestView : MonoBehaviour
    {
        [SerializeField] private QuestListView _questListView;

        public QuestListView QuestListView => _questListView;
    }
}