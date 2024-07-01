using UnityEngine;

namespace Assets.Project_S
{
    public class QuestViewService : MonoBehaviour
    {
        [SerializeField] private QuestListView _questListView;

        public QuestListView QuestListView => _questListView;
    }
}