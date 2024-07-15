using UnityEngine;

namespace Assets.Project_S
{
    public class OpenCurrentAndFinishQuests : MonoBehaviour
    {
        [SerializeField] private ListQusetView _currentQuest;
        [SerializeField] private ListQusetView _finishedQuest;

        private bool _activeListQuest;

        public bool ActiveListQuest => _activeListQuest;

        public void ActiveDefaultListQuests()
        {
            _currentQuest.SetActiveSlotQuest();
            _finishedQuest.SetNotActiveSlotQuest();
            _activeListQuest = true;
        }

        public void ChangeActiveListQuests()
        {
            if (_activeListQuest)
            {
                _currentQuest.SetNotActiveSlotQuest();
                _finishedQuest.SetActiveSlotQuest();
                _activeListQuest = false;
            }
            else
            {
                _currentQuest.SetActiveSlotQuest();
                _finishedQuest.SetNotActiveSlotQuest();
                _activeListQuest = true;
            }
        }
    }
}